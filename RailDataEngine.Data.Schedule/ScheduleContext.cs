using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Data.Schedule
{
    public class ScheduleContext : ContextBase, IScheduleContext
    {
        public DbSet<Record> ScheduleRecords { get; set; }
        public DbSet<Association> AssociationRecords { get; set; }
        public DbSet<Tiploc> TipLocs { get; set; }
        public DbSet<Header> ScheduleHeaders { get; set; }
        public DbSet<Location> ScheduleLocations { get; set; } 
        

    public ScheduleContext(string connectionString)
        : base(connectionString)
    {
        Database.SetInitializer<ScheduleContext>(new NullDatabaseInitializer<ScheduleContext>());
        Configuration.AutoDetectChangesEnabled = false;
        Configuration.ValidateOnSaveEnabled = false;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        const string schema = "Schedules";

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<Record>().ToTable("Schedule", schema);
        modelBuilder.Entity<Association>().ToTable("Association", schema);
        modelBuilder.Entity<Tiploc>().ToTable("Tiploc", schema);
        modelBuilder.Entity<Header>().ToTable("Meta", schema);
        modelBuilder.Entity<Location>().ToTable("Location", schema);

        modelBuilder.Entity<Record>().HasMany(r => r.Locations).WithOptional().WillCascadeOnDelete();
    }
}

}
