using AutoMapper;
using CancunHotel.DTO;
using CancunHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.AppService
{
    public class MappingProfile : Profile
    {
        #region Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MappingProfile()
        {


            CreateMap<rooms, roomsDTO>().ReverseMap();            
            CreateMap<roomsDTO, rooms>().ReverseMap();            
            CreateMap<reservationdetail, reservationdetailDTO>().ReverseMap();            

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método de inicio.
        /// </summary>
        public void Iniciar()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();
            });
        }

        #endregion
    }
}
