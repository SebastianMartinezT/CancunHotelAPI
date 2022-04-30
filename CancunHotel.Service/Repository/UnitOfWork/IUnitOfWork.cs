using CancunHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<rooms> Rooms { get; }
        IRepository<reservationdetail> ReservationDetail { get; }

        void Complete();
    }
}
