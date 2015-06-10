namespace d3poll.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportLog
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime Stamp { get; set; }
    }
}
