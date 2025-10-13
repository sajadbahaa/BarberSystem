using AutoMapper;
using DataLayer.Entities;
using Dtos.ApplicationsDtos;
using Repositary;

namespace BussinesLayer
{
    public class BarberApplicationService
    {
        readonly IMapper _mapper;
        readonly BarberAplicationRepo _repo;
        readonly TempBarberServicesRepo _tempBarberServicesRepo;
        readonly ApplicationsHistoryRepo _applicationsHistoryRepo;  
        public BarberApplicationService(BarberAplicationRepo repo
            , TempBarberServicesRepo tempBarberServicesRepo,IMapper mapper,
            ApplicationsHistoryRepo applicationsHistoryRepo
            )
        {
            _repo = repo;
            _tempBarberServicesRepo = tempBarberServicesRepo;
            _mapper = mapper;
            _applicationsHistoryRepo = applicationsHistoryRepo;

        }
        // add Application includes add Application and Collectino of servies.

        // 
        ///<summery>
        ///addApplicationAsync 
        /// add application includes add full info of applcation and adding Collectino of Service in tempBarberServices.
        /// 
        public async Task<bool> addApplicationAsync(addApplicationDtos dto)
        {
            await _repo.BeginTransactionAsync();
            // add Application.
            var enApp = _mapper.Map<BarberApplications>(dto);
            int ApplicationID = await _repo.AddCustomAsync(enApp);
            if (ApplicationID == 0) 
            {
                await _repo.RollbackAsync();
                return false;
            }

            // add Services 
            if (dto.addTempBarberServiceDtos.Count == 0)
            {
                await _repo.RollbackAsync();
                return false;

            }

            var enServices = dto.addTempBarberServiceDtos.Select(x => new TempBarberServices { ApplicationID = ApplicationID, Price = x.Price, Duration = x.Duration }).ToList();
            if (!await _tempBarberServicesRepo.AddRangeCustomAsync(enServices))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }


        // 
        ///<summery>
        ///update Application 
        ///update Applicatoin with Status Draft. 
        ///not adding In Applicaion History.
        public async Task<bool> UpdateApplicationWithDraftStatusAsync(updateApplicationDtos dto)
        {
            await _repo.BeginTransactionAsync();
            // update Application.
            if (!await _repo.UpdateApplicationWithStatusDraftAsync(_mapper.Map<BarberApplications>(dto)))
            {
                await _repo.RollbackAsync();
                return false;
            }
            // Remove Temp Services.
            if (!await _tempBarberServicesRepo.DeleteRangeAsync(dto.ServicesToDelete))
            {
                await _repo.RollbackAsync();
                return false;
            }
            // update Temp Services.

            var enTempBarberServices = _mapper.Map<List<TempBarberServices>>(dto.ServicesUpdate);
            if (!await _tempBarberServicesRepo.UpdateTempBarberServicesAsync(enTempBarberServices))
            {
                await _repo.RollbackAsync();
                return false;
            }

            await _repo.CommitAsync();
            return true;

        }
        ///<summery>
        ///update Application 
        ///accept update application with status Rejected to edit application.
        ///update application status into Draft
        ///not adding In Applicaion History.
        public async Task<bool> UpdateApplicationIntoPendingStatusAsync(updateApplicationDtos dto)
        {
            await _repo.BeginTransactionAsync();
       // update Application.
            if (!await _repo.UpdateApplicationWithStatusDraftAsync(_mapper.Map<BarberApplications>(dto))) 
            {
                await _repo.RollbackAsync();
                return false;
            }
        // Remove Temp Services.
        if (!await _tempBarberServicesRepo.DeleteRangeAsync(dto.ServicesToDelete))
            {
                await _repo.RollbackAsync();
                return false;
            }
            // update Temp Services.

            var enTempBarberServices = _mapper.Map<List<TempBarberServices>>(dto.ServicesUpdate);
        if (!await _tempBarberServicesRepo.UpdateTempBarberServicesAsync(enTempBarberServices))
            {
                await _repo.RollbackAsync();
                return false;
            }
        
        await _repo.CommitAsync();
            return true;
        
        }


        // Update Application Status into Approval Application 
        /// <summary>
        /// Send Pending Barber into Application Into Admin.
        /// in this case after pending barber review his application it will send into admin.
        /// and status will change into PendingApproval.
        /// </summary>

        public async Task<bool> SendApplicationIntoAdminWithStatusDraftAsync(int ApplicationID)
        {
            return await _repo.UpdateApplicationToPendingApprovalAsync(ApplicationID);
        }


        // Update Application Status into  Rejected 
        // ///
        /// <summary>
        /// this method 
        /// admin does reject applicaton 
        /// add into table History Application status and reason.
        /// </summary>
                public async Task<bool> UpdateAdminApplicationIntoIntoRejectedStatusAsync(RejectedOrCanceledApplicarionDtos dto)
        {
                await _repo.BeginTransactionAsync();

          // update Application Status into Rejected.
            if (!await _repo.UpdateApplicationToRejecteddAsync(dto.ApplicatinoID,dto.Reason ))
            {
                await _repo.RollbackAsync();
                return false;
            }

            // add recordd in application History? 

            var entity = new ApplicationsHistory { ApplicationID = dto.ApplicatinoID, Notes = dto.Reason, UserID = dto.UserID,Status = DataLayer.Entities.EnumClasses.enApplicationStatus.Rejected };
            if (await _applicationsHistoryRepo.AddCustomAsync(entity)==default)
            {
                await _repo.RollbackAsync();
                return false;

            }
            await _repo.CommitAsync();
            return true;
        }


        // Update Application Status into  Approval 
        // ///
        /// <summary>
        /// this method 
        /// admin does Accept applicaton 
        /// </summary>
        public async Task<bool> UpdateAdminApplicationIntoIntoAcceptStatusAsync(updateApplicationDtos dto)
        {
            throw new NotImplementedException();

        }

        // Cancel Application By Pending Barber.
        // ///
        /// <summary>
        /// this method 
        /// application status convert into Canceld 
        /// add application History 
        /// you can not edit on application any more.
        /// </summary>
        public async Task<bool> CancelApplicationByPendingBarberAsync(RejectedOrCanceledApplicarionDtos dto)
        {
            await _repo.BeginTransactionAsync();

            // update Application Status into Rejected.
            if (!await _repo.UpdateApplicationToCanceledAsync(dto.ApplicatinoID, dto.Reason))
            {
                await _repo.RollbackAsync();
                return false;
            }

            // add recordd in application History? 

            var entity = new ApplicationsHistory { ApplicationID = dto.ApplicatinoID, Notes = dto.Reason, UserID = dto.UserID, Status = DataLayer.Entities.EnumClasses.enApplicationStatus.Canceled };
            if (await _applicationsHistoryRepo.AddCustomAsync(entity) == default)
            {
                await _repo.RollbackAsync();
                return false;

            }
            await _repo.CommitAsync();
            return true;
        }

        //----------------------------# Search #-------------------------------

        ///<summary>
        ///Find Applicatino Info 
        ///
        /// </summary
        public async Task<findApplicationDtos> GetApplicationInfoByID(int ApplicationID)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Find All Applicatino Info 
        ///
        /// </summary
        public async Task<List<findApplicationDtos>> GetAllApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetAllTempPendingServicesAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<findTempBarberServiceGeneralDtos>> GetAllTempPendingServicesAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetAllTempPendingServicesByTempIDAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<findTempBarberServiceGeneralDtos> GetTempPendingServicesByTempIDAsync(int TempID)
        {
            throw new NotImplementedException();
        }
     

        /// <summary>
        /// GetAllApplicationsHistotyAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<findApplicationHistotyDtos>> GetAllApplicationsHistotyAsync()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// GetAllApplicationsHistoryByHistoryIDAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<findApplicationHistotyDtos> GetApplicationsHistoryByHistoryIDAsync(int HistoryID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetAllApplicationHistotyGroupByApplicationAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<List<findApplicationHistoyByApplicationIDDtos>> GetAllApplicationHistotyGroupByApplicationAsync()
        {
            throw new NotImplementedException();
        }

        









    }
}
