namespace CancunHotel.DTO
{
    using System;

    public partial class reservationdetailDTO
    {        
        public int IdDetail { get; set; }

        public int? RoomId { get; set; }

        public string ArrivalDay { get; set; }

        public string DepartureDay { get; set; }

        public int? StateReservation { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
    }
}
