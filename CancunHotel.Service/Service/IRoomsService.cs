using CancunHotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service
{
    public interface IRoomsService
    {
        IEnumerable<roomsDTO> GetAllRooms();
    }
}
