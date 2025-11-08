using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using Dtos.AppointmentDtos;
using Dtos.PeopleDtos;
using Dtos.RatingsDtos;
using Dtos.Services;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class RatingsService
    {
        readonly RatingRepo _repo;
        readonly BarbersRepo _barbersRepo;
        readonly IMapper _mapper;
        public RatingsService(RatingRepo repo, IMapper mapper, BarbersRepo barbersRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _barbersRepo = barbersRepo;
        }

        ///<summary>
        ///add RatingID Includes
        ///* check appointment first time + apoointment Status == Completed.
        ///* add rating
        ///* get avg rating for barber id
        ///* update RatingID for Barber.
        /// </summary>
        public async Task<bool> AddRatingAsync( addRatingDtos dto)
        {
            await _repo.BeginTransactionAsync();
            if (!await _repo.IsAppointmentValidAsync(dto.AppointmentID))
            {
                await _repo.RollbackAsync();
                return false;
            }

            // add rating 
            if (await _repo.AddCustomAsync(_mapper.Map<Ratings>(dto))==0)
            {
                await _repo.RollbackAsync();
                return false;
            }

            // get data 
            decimal rate = (decimal)await _repo.GetBarberRatingsBarberIDAsync(dto.BarberID) ;
            
            if (!await _barbersRepo.updateRatingAsync(dto.BarberID,rate))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }


        ///<summary>
        /// Update Ratings Includes :-
        /// update rating. successs
        ///* get avg rating for barber id
        ///* update RatingID for Barber.
        /// </summary>

        public async Task<bool> UpdateRatingAsync(updateRatingDtos dto )
        {
            await _repo.BeginTransactionAsync();

            // add rating 
            if (!await _repo.UpdateAsync(_mapper.Map<Ratings>(dto)) )
            {
                await _repo.RollbackAsync();
                return false;
            }

            // get data 
            decimal rate = (decimal)await _repo.GetBarberRatingsBarberIDAsync(dto.BarberID);

            if (!await _barbersRepo.updateRatingAsync(dto.BarberID, rate))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }

        ///  <summary>
        ///  delete RatingID.
        ///* get avg rating for barber id
        ///* update RatingID for Barber.
        ///* </summary>

        public async Task<bool> DeleteAsync(deleteRatingDtos dto)
        {
            await _repo.BeginTransactionAsync();




            var res = await _repo.DeleteAsync(dto.RatingID);
            if (!res)
            {
                await _repo.RollbackAsync();
                return false;
            }


            decimal rate = (decimal)await _repo.GetBarberRatingsBarberIDAsync(dto.BarberID, dto.RatingID);

            if (!await _barbersRepo.updateRatingAsync(dto.BarberID, rate))
            {
                await _repo.RollbackAsync();
                return false;
            }



            // get data 

            await _repo.CommitAsync();
            return true;
        }
        //public async Task<List<findRatingDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        //{
        //    return _mapper.Map<List<findRatingDtos>>(await _repo.GetAllWithPaginationAsync(pageNumber, pageSize));
        //}

        public async Task<List<findRatingDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repo.GetAllWithPagination(pageNumber, pageSize) // IQueryable<T>
                .ProjectTo<findRatingDtos>(_mapper.ConfigurationProvider) // Project to DTO
                .ToListAsync();

            // تنفيذ الاستعلام داخل SQL
        }
        public async Task<findRatingDtos?> FindByIDV1Async(int ID)
        {
            return await _repo.GetByID().Where(x => x.RatingID == ID)
                .ProjectTo<findRatingDtos?>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
        public async Task<findRatingDtos?> GetRatingByIDAsync(int RatingID)
        {
            return _mapper.Map<findRatingDtos>(await _repo.GetByIdAsync(RatingID));
        }
        public async Task<List<findRatingDtos>?> GetAllRatingsAsync()
        {
            return _mapper.Map<List<findRatingDtos>>(await _repo.GetAllAsync());
        }

    }
}
