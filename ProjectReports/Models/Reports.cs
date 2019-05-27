namespace ProjectReports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reports
    {
        public int ID { get; set; }

        public int ShiftID { get; set; }

        [Required]
        [StringLength(11)]
        public string IncidentNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string ContentIncident { get; set; }

        [Required]
        [StringLength(500)]
        public string ActionToken { get; set; }

        [Required]
        [StringLength(11)]
        public string DeviceNumber { get; set; }

        [Required]
        [StringLength(11)]
        public string DeviceName { get; set; }

        public int ActionTime { get; set; }
    }
}
