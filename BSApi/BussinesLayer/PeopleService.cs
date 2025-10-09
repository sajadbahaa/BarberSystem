using AutoMapper;
using DataLayer.Entities;
using Dtos.PeopleDtos;
using Repositary;
using System.Runtime.InteropServices;

namespace BussinesLayer
{
    public class PeopleService
    {
        readonly PeopleRepo _repo;
        readonly IMapper _mapper;
        public PeopleService(PeopleRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<FindPeopleDtos?> FindByIDAsync(int ID)
        {
            return  _mapper.Map<FindPeopleDtos>( await _repo.GetByIdAsync(ID));
        }

        public async Task<FindPeopleDtos?> FindByNameAsync(string firstName,string secondName,string LastName)
        {
            return _mapper.Map<FindPeopleDtos>(await _repo.GetByNameAsync(firstName,secondName,LastName));
        }

        //public async Task<FindPeopleDtos?> FindByEmailAsync(string Email)
        //{
        //    return _mapper.Map<FindPeopleDtos>(await _repo.GetByEmaliAsync(Email));
        //}
        public async Task<FindPeopleDtos?> FindByPhoneAsync(string Phone)
        {
            return _mapper.Map<FindPeopleDtos>(await _repo.GetByPhoneAsync(Phone));
        }

        public async Task<List<FindPeopleDtos>?> FindAllPeopleAsync()
        {
            return _mapper.Map<List<FindPeopleDtos>>(await _repo.GetAllAsync());
        }
        public async Task<List<FindPeopleDtos>?> FindAllPeopleActiveAsync()
        {
            return _mapper.Map<List<FindPeopleDtos>>(await _repo.GetAllFilterAsync());
        }


        public async Task<int> AddAsync(AddPeopleDtos dto) 
        {
            if (await _repo.PhoneExist(dto.Phone))
                return 0;

            var person = _mapper.Map<People>(dto);

            return await _repo.AddCustomAsync(person); 
        }

        public async Task<bool> UpdateAsync(UpdatePeopleDtos dto)
        {
            var person = _mapper.Map<People>(dto);

            return await _repo.UpdateAsync(person);
        }

        public async Task<bool> ActivateeAsync(int ID)
        {
            return await _repo.ActivateAsync(ID);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _repo.DeleteAsync(ID);
        }




    }
}
