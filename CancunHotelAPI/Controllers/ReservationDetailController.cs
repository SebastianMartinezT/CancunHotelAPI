using AutoMapper;
using CancunHotel.DTO;
using CancunHotel.Models.Context;
using CancunHotel.Service;
using CancunHotel.Service.Repository;
using CancunHotel.Service.Service;
using CancunHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
namespace CancunHotelAPI.Controllers
{
    /// <summary>
    /// Reservation Detail Controller
    /// </summary>
    ///  
    [RoutePrefix("api/ReservationDetail")]
    public class ReservationDetailController : ApiController
    {
        IReservationDetailService _reservation;
        IRoomsService _rooms;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReservationDetailController()
        {
            _reservation = new ReservationDetailService();
            _rooms = new RoomsService();
        }

        /// <summary>
        /// Make a reservation
        /// </summary>
        /// <remarks>
        /// ArrivalDay and DepartureDay has the format dd-MM-yyyy
        /// </remarks>        
        /// <param name="obj">Reservation object with the information</param>
        /// <response code="200">Update successful</response>
        /// <returns></returns>
        [HttpPost]
        [Route("MakeReservation")]
        public IHttpActionResult MakeReservation(reservationdetailDTO obj)
        {
            try
            {
                var result = "";
                var room = _rooms.GetAllRooms().Where(x => x.IdRoom == obj.RoomId && x.State == 1).ToList();

                
                if (room.Count > 0)
                {
                    roomsDTO roomMap = new roomsDTO();
                    roomMap.IdRoom = room[0].IdRoom;
                    roomMap.State = room[0].State;
                    roomMap.RoomNumber = room[0].RoomNumber;

                    result = _reservation.Insert(obj, roomMap);
                }
                else
                {
                    result = "that room is not available";
                }
                return Ok(result);                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get Reservation Detail
        /// </summary>
        /// <param name="idReservation">Reservation ID to search</param>
        /// <returns></returns>
        [Route("GetReservationDetail")]
        [HttpGet]
        public IHttpActionResult GetReservationDetail(int idReservation)
        {   
            
            try
            {
                var result = _reservation.GetReservationDetail(idReservation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Method in charge to update the reservation
        /// </summary>
        /// <remarks>
        /// ArrivalDay and DepartureDay has the format dd-MM-yyyy
        /// </remarks>        
        /// <param name="obj">Reservation Object with the information updated</param>
        /// <returns>Tru if the update was successful</returns>
        /// <response code="200">Update successful</response>
        /// <response code="400">The construction of the object syntax is poorly constructed</response>
        /// <response code="500">Internal Server Error. There is an unhandled exception in the code</response>
        [Route("UpdateReservationDetail")]
        [HttpPut]                
        public IHttpActionResult Update(reservationdetailDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result=_reservation.Update(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Method in charge to Cancel the reservation
        /// </summary>       
        /// <param name="obj">Reservation Object with the information updated</param>
        /// <returns>Tru if the update was successful</returns>
        /// <response code="200">Update successful</response>
        /// <response code="400">The construction of the object syntax is poorly constructed</response>
        /// <response code="500">Internal Server Error. There is an unhandled exception in the code</response>
        [Route("CancelReservationDetail")]
        [HttpPut]
        public IHttpActionResult Cancel(reservationdetailDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _reservation.Cancel(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
        
    