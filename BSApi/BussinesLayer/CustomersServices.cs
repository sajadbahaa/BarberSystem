using AutoMapper;
using DataLayer.Entities;
using Dtos.BarbersDtos;
using Dtos.CustomerDtos;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BussinesLayer
{
    public  class CustomersServices
    {
        readonly CustomerRepo _repo;
        readonly PeopleRepo _peopleRepo;
        readonly UserRepo _userRepo;

        readonly IMapper _mapper;

        public CustomersServices(CustomerRepo repo,IMapper mapper, PeopleRepo peopleRepo, UserRepo userRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _peopleRepo = peopleRepo;
            _userRepo = userRepo;
        
        }
        public async Task<findCustomerDtos?> GetCustomerByIDAsync(int BarberID)
        {
            return _mapper.Map<findCustomerDtos>(await _repo.GetByIdAsync(id: BarberID));
        }
        public async Task<List<findCustomerDtos>?> GetAllCustomersAsync()
        {
            return _mapper.Map<List<findCustomerDtos>>(await _repo.GetAllFilterAsync());
        }

        public async Task<findCustomerDtos?> GetByUserIdAsync(int userID)
        {
            return _mapper.Map<findCustomerDtos>(await _repo.GetByUserIdAsync(userID));

        }

        // update Barber Info.
        public async Task<bool> UpdateCustomerAsync(int UserID,updateCustomerPersonDto dto)
        {
            dto.userID = UserID;
            int personID = await _repo.GetPersonIdByUserIDAsync(UserID);

            if (personID == 0) { return false; }

            dto.peopleDtos.PersonID = personID;
            return await _peopleRepo.UpdateAsync(_mapper.Map<People>(dto.peopleDtos));
        }

        public async Task<int> AddCustomerAsync( addCustomerPersonDto dto)
        {
            await _repo.BeginTransactionAsync();



            if (await _userRepo.UsernameOrEmailUsedAsync(dto.user.UserName, dto.user.Email))
            {
                await _repo.RollbackAsync();
                return 0;
            }

            // 2 add User

            var user =
                await _userRepo.AddUserAsync(_mapper.Map<AppUser>(dto.user), dto.user.PasswordHash);

            if (user == null)
            {
                await _repo.RollbackAsync();
                return 0;
            }
            // 3 : add Role

            var res = await _userRepo.AssignRoleAsync(user, "Customer");

            if (res == false)
            {
                await _repo.RollbackAsync();
                return 0;
            }


            // add person.
            int personID = await _peopleRepo.AddCustomAsync(_mapper.Map<People>(dto.peopleDtos));


            if (personID == 0) { await _repo.RollbackAsync(); return 0; }




            dto.personID = personID;

            dto.UserID = user.Id;
            
            // add user and get user id .

            // add customer success.

            int customerID = await _repo.AddCustomAsync(_mapper.Map<Customers>(dto));

            if (customerID == 0) { await _repo.RollbackAsync(); return 0; }

            //throw NotImplementedException.ReferenceEquals();
            await _repo.CommitAsync();
            return customerID;

        }




        // 
    }
}
