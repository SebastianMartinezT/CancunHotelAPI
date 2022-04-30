using CancunHotel.Models;
using CancunHotel.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.Repository.UnitOfWork
{
    public class UnitOfWorks: IUnitOfWork
    {
        private Context _db;
        private DbContextTransaction dbtransaction;

        public IRepository<rooms> Rooms { get; set; }
        public IRepository<reservationdetail> ReservationDetail { get; set; }

        public UnitOfWorks(Context db)
        {
            _db = db;
            Rooms = new Repository<rooms>(db);
            ReservationDetail = new Repository<reservationdetail>(db);
        }

        public void Complete()
        {
            _db.SaveChanges();
        }
    }
}
