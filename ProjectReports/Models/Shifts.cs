namespace ProjectReports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shifts
    {
        public int ID { get; set; }

        public int FristWorker { get; set; }

        public int? SecondWorker { get; set; }

        [Required]
        [StringLength(11)]
        public string TimeRange { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
