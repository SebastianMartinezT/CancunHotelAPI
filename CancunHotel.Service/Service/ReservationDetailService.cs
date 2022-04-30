using AutoMapper;
using CancunHotel.DTO;
using CancunHotel.Models;
using CancunHotel.Models.Context;
using CancunHotel.Service.Repository.UnitOfWork;
using CancunHotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancunHotel.Service
{
    public class ReservationDetailService : IReservationDetailService
    {
        private IUnitOfWork _unitofwork;

        public ReservationDetailService()
        {
            
            _unitofwork = new UnitOfWorks(new Context());
        }

        /// <summary>
        ///  Method in charge to get the reservation
        /// </summary>
        /// <param name="idReservation"> reservation id</param>
        public IEnumerable<reservationdetailDTO> GetReservationDetail(int idReservation)
        {
            return Mapper.Map<IEnumerable<reservationdetailDTO>>(_unitofwork.ReservationDetail.Get(x=> x.IdDetail== idReservation, null));
        }
        /// <summary>
        ///  Method in charge to make a reservation
        /// </summary>
        /// <param name="reservationDTO"> Object with the information</param>
        public string Insert(reservationdetailDTO reservationDTO,roomsDTO rooms)
        {
            var result = "";
            rooms roomMap = Mapper.Map<rooms>(rooms);
            reservationdetail reservation = new reservationdetail();
            //rooms rooms = new rooms();
            var date = DateTime.Now;
            DateTime ArrivalDay;
            if (!DateTime.TryParseExact(reservationDTO.ArrivalDay.ToString(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out ArrivalDay))
            {               
                result = "Incorrect Date Format";
            }
            else
            {
                reservation.ArrivalDay = ArrivalDay;
            }
            DateTime DepartureDay;
            if (!DateTime.TryParseExact(reservationDTO.DepartureDay.ToString(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out DepartureDay))
            {
                result = "Incorrect Date Format";
            }
            else
            {
                reservation.DepartureDay = DepartureDay;
            }
            reservation.RoomId = reservationDTO.RoomId;
            TimeSpan dateDifsStay = DepartureDay - ArrivalDay;
            TimeSpan dateDifsReservation = ArrivalDay - date;

            if (dateDifsReservation.Days > 30)
            {
                result = "the date for the reservation is greater than 30 days";
            }
            else
            {
                if (dateDifsStay.Days > 3)
                {
                    result = "the stay is greater than 3 days";

                }
                else
                {
                    reservation.StateReservation = 3;
                    reservation.Name = reservationDTO.Name;
                    reservation.LastName= reservationDTO.LastName;
                    reservation.Mail = reservationDTO.Mail;
                    _unitofwork.ReservationDetail.Insert(reservation);
                    roomMap.State = 3;
                    _unitofwork.Rooms.Update(roomMap);
                    _unitofwork.Complete();
                    result = "successful";
                }
            }
            return result;
        }

        /// <summary>
        ///  Method in charge to update the reservation
        /// </summary>
        /// <param name="reservationDTO"> Object with the information</param>
        public string Update(reservationdetailDTO reservationDTO)
        {
            var reservationFound = _unitofwork.ReservationDetail.Get(x => x.IdDetail == reservationDTO.IdDetail).FirstOrDefault();                
            string result = "";
            if (reservationFound != null)
            {
                DateTime DepartureDay;
                if (!DateTime.TryParseExact(reservationDTO.DepartureDay.ToString(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.AdjustToUniversal, out DepartureDay))
                {
                    result = "Incorrect Date Format";
                }
                else
                {
                    reservationFound.DepartureDay = DepartureDay;
                }
                reservationFound.LastName = reservationDTO.LastName;
                reservationFound.Name = reservationDTO.Name;
                reservationFound.Mail = reservationDTO.Mail;

                _unitofwork.ReservationDetail.Update(reservationFound);
                _unitofwork.Complete();
                result = "successful";
            }
            else
            {
                result = "that reservation doesn´t exist";
            }
                       
            return result;
        }

        /// <summary>
        ///  Method in charge to cancel the reservation
        /// </summary>
        /// <param name="reservationDTO"> Object with the information</param>
        public string Cancel(reservationdetailDTO reservationDTO)
        {
            var reservationFound = _unitofwork.ReservationDetail.Get(x => x.IdDetail == reservationDTO.IdDetail).FirstOrDefault();
            var roomFound = _unitofwork.Rooms.Get(x => x.IdRoom == reservationFound.RoomId).FirstOrDefault();
            string result = "";
            if (reservationFound != null)
            {

                reservationFound.StateReservation = 4;
                roomFound.State = 1;

                _unitofwork.ReservationDetail.Update(reservationFound);
                _unitofwork.Rooms.Update(roomFound);
                _unitofwork.Complete();
                result = "successful";
            }
            else
            {
                result = "that reservation doesn´t exist";
            }
            return result;
        }
    }
}
