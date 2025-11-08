using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using Dtos.AppointmentDtos;
using Dtos.BarbersDtos;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class BarberServiceServices
    {
        readonly BarbersServiceRepo _repo;
        readonly IMapper _mapper;
        public BarberServiceServices(BarbersServiceRepo repo, IMapper mapper) 
        { 
            _repo = repo;
            _mapper = mapper; 
        }
        public  async Task<int> AddBarberServiceAsync(addBarberServiceDto dto,int userID)
        {
            int barberID = await _repo.getBarberIDByUserID(userID);
            if (barberID==default)
            {
                return 0;
            }
            dto.BarberID = barberID;

            var o = _mapper.Map<BarberServices>(dto);

            return await _repo.AddCustomAsync(o);
        }
        public async Task<bool> UpdateAsync(updateBarberServiceDto dto)
        {
            return await _repo.UpdateAsync(_mapper.Map<BarberServices>(dto));
        }

        public async Task<findBarberServiceDto?> FindBarberServiceByIDAsync(int BarberServiceID)
        {
            return  _mapper.Map<findBarberServiceDto>(await _repo.GetByIdAsync(BarberServiceID));
        }

        public async Task<List<findBarberServiceDto>?> FindAllBarberServiceAsync(int ?BarberServiceID = null)
        {
            return _mapper.Map<List<findBarberServiceDto>>(await _repo.GetAllAsync());
        }

        //public async Task<List<findBarberServiceDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        //{
        //    return _mapper.Map<List<findBarberServiceDto>>(await _repo.GetAllWithPaginationAsync(pageNumber, pageSize));
        //}

        public async Task<List<findBarberServiceDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repo.GetAllWithPagination(pageNumber, pageSize) // IQueryable<T>
                .ProjectTo<findBarberServiceDto>(_mapper.ConfigurationProvider) // Project to DTO
                .ToListAsync(); // تنفيذ الاستعلام داخل SQL
        }

        public async Task<findBarberServiceDto?> FindByIDV1Async(int ID)
        {
            return await _repo.GetByID().Where(x => x.BarberServiceID == ID)
                .ProjectTo<findBarberServiceDto?>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

    }
}
