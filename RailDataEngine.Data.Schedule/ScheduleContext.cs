using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Gateway.Entity.Schedule;

namespace RailDataEngine.Data.Schedule
{
    public class ScheduleContext : ContextBase, IScheduleContext
    {
        public DbSet<RecordEntity> ScheduleRecords { get; set; }
        public DbSet<AssociationEntity> AssociationRecords { get; set; }
        public DbSet<TiplocEntity> TipLocs { get; set; }
        public DbSet<HeaderEntity> ScheduleHeaders { get; set; }
        

    public ScheduleContext(string connectionString)
        : base(connectionString)
    {
        Database.SetInitializer<ScheduleContext>(new NullDatabaseInitializer<ScheduleContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        const string schema = "Schedule";

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<RecordEntity>().ToTable("Schedule", schema);
        modelBuilder.Entity<AssociationEntity>().ToTable("Association", schema);
        modelBuilder.Entity<TiplocEntity>().ToTable("Tiploc", schema);
        modelBuilder.Entity<HeaderEntity>().ToTable("Meta", schema);
    }
}

}
