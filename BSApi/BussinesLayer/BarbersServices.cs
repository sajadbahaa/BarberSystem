using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using Dtos.AppointmentDtos;
using Dtos.BarbersDtos;
using Dtos.CustomerDtos;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class BarbersServices
    {
        readonly BarbersRepo _repo;
        readonly PeopleRepo _peopleRepo;
        readonly IMapper _mapper;

        public BarbersServices(BarbersRepo repo,IMapper mapper, PeopleRepo peopleRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _peopleRepo = peopleRepo;
        }
        public async Task<List<string>> GetMyServices(int UserID)
        {
            return await _repo.GetMyServices(UserID);
        }
        public async Task<List<findBarberDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repo.GetAllWithPagination(pageNumber, pageSize) // IQueryable<T>
                .ProjectTo<findBarberDtos>(_mapper.ConfigurationProvider) // Project to DTO
                .ToListAsync(); // تنفيذ الاستعلام داخل SQL
        }

        public async Task<findBarberDtos?> FindByIDV1Async(int ID)
        {
            return await _repo.GetByID().Where(x => x.BarberID == ID)
                .ProjectTo<findBarberDtos?>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }
        public async Task<findBarberDtos?> GetBarberByIDAsync(int BarberID)
        {
            return _mapper.Map<findBarberDtos>(await _repo.GetByIdAsync(id: BarberID));
        }
        public async Task<List<findBarberDtos>?> GetAllBarbersAsync()
        {
            return _mapper.Map<List<findBarberDtos>>(await _repo.GetAllFilterAsync());
        }

        public async Task<findBarberDtos?> GetByUserIdAsync(int userID)
        {
            return _mapper.Map<findBarberDtos>(await _repo.GetByUserIdAsync(userID));

        }

        // update Barber Info.
        public async Task<bool> UpdateBarberInfo(int UserID,updateBarberPersonDto dto)
        {
            await _repo.BeginTransactionAsync();
             if (!await _peopleRepo.UpdateAsync(_mapper.Map<People>(dto.peopleDtos)))
            {
                await _repo.RollbackAsync();
                return false;
            }
            if (!await _repo.UpdateBarberInfoAsync(_mapper.Map<Barbers>(dto), UserID))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }

    }
}
