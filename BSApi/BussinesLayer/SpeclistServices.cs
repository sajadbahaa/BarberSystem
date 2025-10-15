using AutoMapper;
using DataLayer.Entities;
using Dtos.PeopleDtos;
using Dtos.Services;
using Dtos.SpeclisysDtos;
using Microsoft.EntityFrameworkCore;
using RepLayer.Services;
using Repositary;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class SpeclistServices
    {
        readonly SpeclitsRepo _repo;
        readonly ServicsRepo  _servicsRepo;
        readonly ServiceDetilasRepo _serviceDetilasRepo;
        
        readonly IMapper _mapper;
        public SpeclistServices(SpeclitsRepo repo, IMapper mapper, ServicsRepo servicsRepo, ServiceDetilasRepo serviceDetilasRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _servicsRepo = servicsRepo;
            _serviceDetilasRepo = serviceDetilasRepo;
        }
        public async Task<findSpecliystDtos?> FindByIDAsync(short ID)
        {
            return _mapper.Map<findSpecliystDtos>(await _repo.GetByIdAsync(ID));
        }
        public async Task<List<findSpecliystDtos>?> FindAllSpeclistAsync()
        {
            return _mapper.Map<List<findSpecliystDtos>>(await _repo.GetAllAsync());
        }
        public async Task<List<findSpecliystDtos>?> FindAllSpecliystActiveAsync()
        {
            return _mapper.Map<List<findSpecliystDtos>>(await _repo.GetAllFilterAsync());
        }
        public async Task<List<findServicesBySpeclityDtos>?> GetServicesBySpeclityName(string speclityName)
        {
            return await _serviceDetilasRepo.GetServicesBySpeciltyName(speclityName);
        }

        public async Task<List<string>?> GetAllSpeclityNamesAsync()
        {
            return await _repo.GetAllSpeclityNamesAsync();
        }

        // add 
        private async Task<List<short>?> _AddServicesAsync(List<addServicesDtos> dto)
        {
            var services = dto.Select(x => _mapper.Map<Servics>(x)).ToList();
            return await _servicsRepo.AddRangeAsync(services)!=null?services.Select(x=>x.ServiceID).ToList():default;
        }
        public async Task<bool> AddSpeclistAsync( addSpeclistNewDtos dto)
        {
            // validation if speclist name not exits
           

            await _repo.BeginTransactionAsync();

            if (await _repo.IsExistAsync(dto.SpecilityName))
            {
                await _repo.RollbackAsync(); return false;
            }

            short specilstID = await _repo.AddCustomAsync(_mapper.Map<Speclitys>(dto));
            if (specilstID == 0) { await _repo.RollbackAsync(); return false; }

            // add Services add

            List<short> ?ServicesIDs = await _AddServicesAsync(dto.addServicesDtos);

            if (ServicesIDs == null) {await  _repo.RollbackAsync(); return false; }


            // link speclize with Services.
           var entitys = _mapper.Map<List<ServicesDetials>>(ServicesIDs.Select(x => new ServicesDetials {ServiceID = x,SpecilityID=specilstID}).ToList());
           bool result =  await _serviceDetilasRepo.AddRangeCustomAsync(entitys);
            if (!result) { await _repo.RollbackAsync(); return false; }
            await _repo.CommitAsync();
            return true;
        }

        public async Task<bool> AddSpeclistAsync(addSpeclistDtos dto)
        {
            // validation if speclist name not exits


            await _repo.BeginTransactionAsync();


            // add Services add
            var servicesNames = dto.addServicesDtos.Select(x => x.ServiceName).ToList();
            if (await _servicsRepo.IsExistAsync(servicesNames))
            {
                await _repo.RollbackAsync(); 
                return false;
            }

            List<short>? ServicesIDs = await _AddServicesAsync(dto.addServicesDtos);

            if (ServicesIDs == null) { await _repo.RollbackAsync(); return false; }


            // link speclize with Services.
            

            var entitys = _mapper.Map<List<ServicesDetials>>(ServicesIDs.Select(x => new ServicesDetials { ServiceID = x, SpecilityID = dto.SpeclizeID }).ToList());
            
            bool result = await _serviceDetilasRepo.AddRangeCustomAsync(entitys);
            if (!result) { await _repo.RollbackAsync(); return false; }
            await _repo.CommitAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(updateSpeclistDtos dto)
        {
            var entity = _mapper.Map<Speclitys>(dto);

            return await _repo.UpdateAsync(entity);
        }
        public async Task<bool> ActivateeAsync(short ID)
        {

            await _repo.BeginTransactionAsync();
            if (!await _servicsRepo.ActivateAllAsync(ID))
            {
                await _repo.RollbackAsync();
                return false;
            }

            if (!await _repo.ActivateAsync(ID))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(short ID)
        {
            await _repo.BeginTransactionAsync();
            
            if (!await _servicsRepo.DeleteAllAsync(ID))
            {
                await _repo.RollbackAsync();
                return false;
            }

            if (!await _repo.DeleteAsync(ID))
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return  true;
        }


    }
}
