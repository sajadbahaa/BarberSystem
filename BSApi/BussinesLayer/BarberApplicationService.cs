using AutoMapper;
using DataLayer.Entities;
using Dtos.ApplicationsDtos;
using Repositary;
using System;
using static System.Net.Mime.MediaTypeNames;

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

            if (await _repo.HasUserApplicationActive(dto.UserID))
            {
                await _repo.RollbackAsync();
                return false;
            }
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

            var enServices = dto.addTempBarberServiceDtos
                .Select(x => new TempBarberServices { ApplicationID = ApplicationID,ServiceDetilasID= x.ServiceDetilasID, Price = x.Price, Duration = x.Duration }).ToList();
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
        public async Task<bool> UpdateApplicationWithDraftStatusAsync(updateFullApplicationDtos dto)
        {
            await _repo.BeginTransactionAsync();
            // update Application.
            if (!await _repo.UpdateApplicationWithStatusDraftAsync(_mapper.Map<BarberApplications>(dto.UpdateApplicationDtos)))
            {
                await _repo.RollbackAsync();
                return false;
            }
            // Remove Temp Services.

            if (!dto.ServicesToDelete.Contains(0))
            {
                if (!await _tempBarberServicesRepo.DeleteRangeAsync(dto.ServicesToDelete))
                {
                    await _repo.RollbackAsync();
                    return false;
                }
            }

            // Update Temp Services if any
            if (!dto.ServicesUpdate.Any(x=>x.TempServiceID==0))
            {
                var enTempBarberServices = _mapper.Map<List<TempBarberServices>>(dto.ServicesUpdate);

                if (!await _tempBarberServicesRepo.UpdateTempBarberServicesAsync(enTempBarberServices))
                {
                    await _repo.RollbackAsync();
                    return false;
                }
            }
            if (!dto.AddTempBarberServiceDtos.Any(x=>x.ServiceDetilasID==0))
            {
                var enServices = dto.AddTempBarberServiceDtos
                             .Select(x => new TempBarberServices { ApplicationID = dto.UpdateApplicationDtos.ApplicationID, 
                                 ServiceDetilasID = x.ServiceDetilasID,
                                 Price = x.Price, Duration = x.Duration }).ToList();
                if (!await _tempBarberServicesRepo.AddRangeCustomAsync(enServices))
                {
                    await _repo.RollbackAsync();
                    return false;
                }
            }

            await _repo.CommitAsync();
            return true;

        }
        ///<summery>
        ///update Application 
        ///accept update application with status Rejected to edit application.
        ///update application status into Draft
        ///not adding In Applicaion History.
        //public async Task<bool> UpdateApplicationWithStatusRejectedAsync(updateFullApplicationDtos dto)
        //{
        //    await _repo.BeginTransactionAsync();
        //    // update Application.

        //    var res = await _repo.UpdateApplicationWithStatusRejectedAsync(_mapper.Map<BarberApplications>(dto.updateApplicationDtos));
        //    if (!res.Item1) 
        //    {
        //        await _repo.RollbackAsync();
        //        return false;
        //    }
        //    // Remove Temp Services.

        //    if (dto.ServicesToDelete!=null) 
        //    {
        //        if (!await _tempBarberServicesRepo.DeleteRangeAsync(dto.ServicesToDelete))
        //        {
        //            await _repo.RollbackAsync();
        //            return false;
        //        }

        //    }
        //    // update Temp Services.

        //    if (dto.ServicesUpdate.Count>0)
        //    {
        //        var enTempBarberServices = _mapper.Map<List<TempBarberServices>>(dto.ServicesUpdate);


        //        if (!await _tempBarberServicesRepo.UpdateTempBarberServicesAsync(enTempBarberServices))
        //        {
        //            await _repo.RollbackAsync();
        //            return false;
        //        }
        //    }

        //    var entity = new ApplicationsHistory { ApplicationID = dto.updateApplicationDtos.ApplicationID, 
        //        Notes = dto.Note,
        //        UserID = res.Item2, Status = DataLayer.Entities.EnumClasses.enApplicationStatus.PendingApproval };
        //    if (await _applicationsHistoryRepo.AddCustomAsync(entity) == default)
        //    {
        //        await _repo.RollbackAsync();
        //        return false;
        //    }

        //    await _repo.CommitAsync();
        //    return true;

        //}


        // Update Application Status into Approval Application 
        /// <summary>
        /// Send Pending Barber into Application Into Admin.
        /// in this case after pending barber review his application it will send into admin.
        /// and status will change into PendingApproval.
        /// </summary>

        public async Task<bool> UpdateApplicationWithStatusRejectedAsync(updateFullApplicationRejectedDtos dto)
        {
            await _repo.BeginTransactionAsync();

            // Update Application if present
                var res = await _repo.UpdateApplicationWithStatusRejectedAsync(
                    _mapper.Map<BarberApplications>(dto.UpdateApplicationDtos)
                );

                if (!res.Item1)
                {
                    await _repo.RollbackAsync();
                    return false;
                }

          
                // Update Temp Services if any
                if (!dto.ServicesUpdate.Any(x=>x.TempServiceID==0))
                {
                    var enTempBarberServices = _mapper.Map<List<TempBarberServices>>(dto.ServicesUpdate);

                    if (!await _tempBarberServicesRepo.UpdateTempBarberServicesAsync(enTempBarberServices))
                    {
                        await _repo.RollbackAsync();
                        return false;
                    }
                }

                // Add to history
                var entity = new ApplicationsHistory
                {
                    ApplicationID = dto.UpdateApplicationDtos.ApplicationID,
                    Notes = dto.Note,
                    UserID = res.Item2,
                    Status = DataLayer.Entities.EnumClasses.enApplicationStatus.Draft
                };

                if (await _applicationsHistoryRepo.AddCustomAsync(entity) == default)
                {
                    await _repo.RollbackAsync();
                    return false;
                }
        
            await _repo.CommitAsync();
            return true;
        }


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
        public async Task<bool> UpdateAdminApplicationIntoIntoAcceptStatusAsync(updateFullApplicationDtos dto)
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
        ///Find Applicatino Info BY ID
        ///
        /// </summary
        public async Task<findApplicationDtos?> GetApplicationInfoByID(int ApplicationID)
        {
            return _mapper.Map<findApplicationDtos>(await _repo.GetByIdAsync(ApplicationID));
        }


        ///<summary>
        ///Find All Applicatino Info 
        ///
        /// </summary
        public async Task<List<findApplicationDtos>?> GetAllApplicationsAsync()
        {
            return _mapper.Map<List<findApplicationDtos>>(await _repo.GetAllAsync());
        }

        /// <summary>
        /// GetAllTempPendingServicesAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<findTempBarberServiceGeneralDtos>> GetAllTempPendingServicesAsync()
        {
            return _mapper.Map<List<findTempBarberServiceGeneralDtos>>(await _tempBarberServicesRepo.GetAllAsync());
        }

        /// <summary>
        /// GetAllTempPendingServicesByTempIDAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<findTempBarberServiceGeneralDtos> GetTempPendingServicesByTempIDAsync(int TempID)
        {
            return _mapper.Map<findTempBarberServiceGeneralDtos>(await _tempBarberServicesRepo.GetByIdAsync(TempID));
        }


        /// <summary>
        /// GetAllApplicationsHistotyAsync
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<findApplicationHistotyDtos>> GetAllApplicationsHistotyAsync()
        {
            return _mapper.Map<List<findApplicationHistotyDtos>>(await _applicationsHistoryRepo.GetAllFilterAsync());
        }



        /// <summary>
        /// GetAllApplicationsHistoryByHistoryIDAsync
        /// </summary>
        /// <returns></returns>
                public async Task<findApplicationHistotyDtos> GetApplicationsHistoryByHistoryIDAsync(int HistoryID)
        {
            return _mapper.Map<findApplicationHistotyDtos>(await _applicationsHistoryRepo.GetByIdAsync(HistoryID));
        }

        /// <summary>
        /// GetAllApplicationHistotyGroupByApplicationAsync
        /// </summary>
        /// <returns></returns>
        //public async Task<List<findApplicationHistoyByApplicationIDDtos>> GetAllApplicationHistotyGroupByApplicationAsync()
        //{
        //    throw new NotImplementedException();
        //}

        









    }
}
