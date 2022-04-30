
using AutoMapper;
using CancunHotel.DTO;
using CancunHotel.Models.Context;
using CancunHotel.Service.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service
{
    public class RoomsService : IRoomsService
    {        
        private IUnitOfWork _unitofwork;

        public RoomsService()
        {            
            _unitofwork = new UnitOfWorks(new Context());
        }

        public IEnumerable<roomsDTO> GetAllRooms()
        {            
            return Mapper.Map<IEnumerable<roomsDTO>>(_unitofwork.Rooms.Get(null,null));
        }
    }
}
