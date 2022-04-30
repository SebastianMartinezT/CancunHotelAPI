using CancunHotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.Service
{
    public interface IReservationDetailService
    {
        IEnumerable<reservationdetailDTO> GetReservationDetail(int idReservation);
        string Update(reservationdetailDTO reservationDTO);
        string Cancel(reservationdetailDTO reservationDTO);
        string Insert(reservationdetailDTO reservationDTO, roomsDTO roomss);
    }
}
