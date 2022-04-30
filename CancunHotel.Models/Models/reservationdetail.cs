namespace CancunHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reservationdetail")]
    public partial class reservationdetail
    {
        [Key]
        public int IdDetail { get; set; }

        public int? RoomId { get; set; }

        public DateTime? ArrivalDay { get; set; }

        public DateTime? DepartureDay { get; set; }

        public int? StateReservation { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }

        public virtual rooms rooms { get; set; }

        public virtual states states { get; set; }
    }
}
