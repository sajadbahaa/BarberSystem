using AutoMapper;
using DataLayer.Entities;
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
    public  class BarbersServices
    {
        readonly BarbersRepo _repo;
        readonly IMapper _mapper;

        public BarbersServices(BarbersRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
    }
}
