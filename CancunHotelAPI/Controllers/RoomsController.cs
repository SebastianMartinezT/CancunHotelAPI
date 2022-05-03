using CancunHotel.Models.Context;
using CancunHotel.Service;
using CancunHotel.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CancunHotelAPI.Controllers
{ 
    /// <summary>
    /// Rooms Controller
    /// </summary>
    ///         
    [RoutePrefix("api/Rooms")]
    public class RoomsController : ApiController
    {
        RoomsService _rooms;

        /// <summary>
        /// Constructor
        /// </summary>
        public RoomsController()
        {
            _rooms = new RoomsService();
        }


        /// <summary>
        /// Get Rooms
        /// </summary>
        /// <returns></returns>
        [Route("GetRooms")]
        public IHttpActionResult GetRooms()
        {
            //var ass = await _repository.GetAllRooms();
            try
            {
                var result = _rooms.GetAllRooms();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }
        /// <summary>
        /// Get Availability Rooms
        /// </summary>
        /// <returns></returns>
        [Route("GetAvailabilityRooms")]
        public IHttpActionResult GetAvailabilityRooms()
        {
            //var ass = await _repository.GetAllRooms();
            try
            {
                var result = _rooms.GetAllRooms().Where(x=>x.State==1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
    

}