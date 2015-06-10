namespace ReportLogRun
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReportLogModel : DbContext
    {
        public ReportLogModel()
            : base("name=ReportLogModelContext")
        {
        }

        public virtual DbSet<ReportLog> ReportLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
