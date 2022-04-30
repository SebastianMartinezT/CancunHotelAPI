using CancunHotel.DTO;
using CancunHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service.Repository
{
    public interface IRepository<TEntity>
    {
        //Task<List<roomsDTO>> GetAllRooms();
        void Insert(TEntity entity);
        
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderby=null);

        //Task<List<reservationdetail>> GetAllReservationAsync();

        //void ActualizarDestinatarioAlerta(alertDestino destino);

        //void InsertarDestinatarioAlerta(alertDestino destino);
    }
}
