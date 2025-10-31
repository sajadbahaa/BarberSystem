using AutoMapper;
using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using Dtos.AppointmentDtos;
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
                public AppoitmentServices(AppointmentsRepo repo
            , TempBarberServicesRepo tempBarberServicesRepo, IMapper mapper,
            ApplicationsHistoryRepo applicationsHistoryRepo
            )
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<findAppointmentDtos?> FindAppointmentDtos(int appointmentID)
        {
            return _mapper.Map<findAppointmentDtos>(await _repo.GetByIdAsync(appointmentID));
        }

        public async Task<List<findAppointmentDtos>?> FindAllAppointmentsDtos()
        {
            return _mapper.Map<List<findAppointmentDtos>>(await _repo.GetAllAsync());
        }

public async Task<int> AddAsync(addAppointmentDtos dto)
        {
            
            var res = _mapper.Map<Appointments>(dto);
            if (!await _repo.HascustomerIDAppointmentAsync(res.CustomerID, res.StartDate, res.EndDate))
            {
                return 0;
            }

            return await _repo.AddCustomAsync(res);
        }

        public async Task<bool> UpdateAsync(updateAppointmentDtos dto)
        {
            return await _repo.UpdateAsync(_mapper.Map<Appointments>(dto));
        }



        public async Task<bool> UpdateAppointmentToPendingApprovalAsync(int AppoointmentID)
        {
            return
            await _repo.UpdateAppointmentToPendingApprovalAsync(AppoointmentID);
        }


        public async Task<bool> UpdateAppointmentToCompletedAsync(int AppointmentID)
        {
            return await _repo.UpdateAppointmentToCompletedAsync(AppointmentID);

        }

        public async Task<bool> UpdateAppointmentToCanceledAsync(int AppointmentID)
        {
            return await _repo.UpdateAppointmentToCanceledAsync(AppointmentID);
        }


    }
}
