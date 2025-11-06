using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using Dtos.AppointmentDtos;
using Dtos.UsersDtos;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class AppoitmentServices
    {
        readonly IMapper _mapper;
        readonly AppointmentsRepo _repo;
        readonly CustomerRepo _customerRepo;
                public AppoitmentServices(AppointmentsRepo repo
            , TempBarberServicesRepo tempBarberServicesRepo, IMapper mapper,
            ApplicationsHistoryRepo applicationsHistoryRepo,
            CustomerRepo customerRepo
            )
        {
            _repo = repo;
            _mapper = mapper;
            _customerRepo = customerRepo;

        }

        public async Task<findAppointmentDtos?> FindAppointmentDtos(int appointmentID)
        {
            return _mapper.Map<findAppointmentDtos>(await _repo.GetByIdAsync(appointmentID));
        }

        public async Task<List<findAppointmentDtos>?> FindAllAppointmentsDtos()
        {
            return _mapper.Map<List<findAppointmentDtos>>(await _repo.GetAllAsync());
        }

    public async Task<int> AddAsync(addAppointmentDtos dto,int userID)
        {
            // check user id is it a customer .

            if (! await _customerRepo.IsCustomerSameUserIDAsync(userID, dto.CustomerID))
            {
                return 0;
            }

            
            var res = _mapper.Map<Appointments>(dto);
            if (!await _repo.HascustomerIDAppointmentAsync(res.CustomerID, res.StartDate, res.EndDate))
            {
                return 0;
            }

            return await _repo.AddCustomAsync(res);
        }

        public async Task<bool> UpdateAsync(updateAppointmentDtos dto,int userID)
        {

            if (!await _customerRepo.IsCustomerSameUserIDAsync(userID, dto.CustomerID))
            {
                return false;
            }

            return await _repo.UpdateAsync(_mapper.Map<Appointments>(dto));
        }



        public async Task<bool> UpdateAppointmentToPendingApprovalAsync(int userID,int AppoointmentID)
        {
            if ( !await _repo.IsAppointmentOwnedByBarberAsync(userID,AppoointmentID))
            {
                return false;
            }
            return
            await _repo.UpdateAppointmentToPendingApprovalAsync(AppoointmentID);
        }


        public async Task<bool> UpdateAppointmentToCompletedAsync(int userID,int AppointmentID)
        {
            if (!await _repo.IsAppointmentOwnedByBarberAsync(userID, AppointmentID))
            {
                return false;
            }
            return await _repo.UpdateAppointmentToCompletedAsync(AppointmentID);

        }

        public async Task<bool> UpdateAppointmentToCanceledAsync(int userID, int AppointmentID)
        {
            if (!await _repo.IsAppointmentOwnedByBarberAsync(userID, AppointmentID))
            {
                return false;
            }
            return await _repo.UpdateAppointmentToCanceledAsync(AppointmentID);
        }

        //public  async Task<List<findAppointmentDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        //{
        //    return _mapper.Map<List<findAppointmentDtos>>(await _repo.GetAllWithPaginationAsync(pageNumber,pageSize));
        //}

        public async Task<List<findAppointmentDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repo.GetAllWithPagination(pageNumber, pageSize) // IQueryable<T>
                .ProjectTo<findAppointmentDtos>(_mapper.ConfigurationProvider) // Project to DTO
                .ToListAsync();

            // تنفيذ الاستعلام داخل SQL
        }

    }
}
