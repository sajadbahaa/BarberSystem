using AutoMapper;
using DataLayer.Entities;
using Dtos.Services;
using Dtos.SpeclisysDtos;
using Repositary;

namespace BussinesLayer
{
    public  class ServicesDetilasService
    {
        readonly ServicsRepo _repo;
        readonly IMapper _mapper;
        public ServicesDetilasService(ServicsRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<findServicesDtos?> FindByIDAsync(short ID)
        {
            return _mapper.Map<findServicesDtos>(await _repo.GetByIdAsync(ID));
        }
        public async Task<List<findServicesDtos>?> FindAllServicesAsync()
        {
            return _mapper.Map<List<findServicesDtos>>(await _repo.GetAllAsync());
        }

        public async Task<List<findServicesDetialsDtos>?> FindAllServicesDetilasAsync()
        {
            var query = await _repo.GetAllFilterAsync();

            return _mapper.Map<List<findServicesDetialsDtos>>(query);
        }

        public async Task<bool> UpdateAsync(updateServiceDtos dto)
        {
            var entity = _mapper.Map<Servics>(dto);

            return await _repo.UpdateAsync(entity);
        }
        public async Task<bool> ActivateeAsync(short ID)
        {
            return await _repo.ActivateAsync(ID);
        }
        public async Task<bool> DeleteAsync(short ID)
        {
            return await _repo.DeleteAsync(ID);
        }

        
    
    
    }
}
