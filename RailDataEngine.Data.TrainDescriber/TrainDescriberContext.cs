using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Gateway.Entity.TrainDescriber.Berth;
using RailDataEngine.Gateway.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Data.TrainDescriber
{
    public class TrainDescriberContext : ContextBase, ITrainDescriberContext
    {
        public DbSet<BerthMessageEntity> BerthMessages { get; set; }
        public DbSet<SignalMessageEntity> SignalMessages { get; set; }

    public TrainDescriberContext(string connectionString)
        : base(connectionString)
    {
        Database.SetInitializer<TrainDescriberContext>(new NullDatabaseInitializer<TrainDescriberContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        const string schema = "TrainDescriberMessages";

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<BerthMessageEntity>().ToTable("BerthMessage", schema);
        modelBuilder.Entity<SignalMessageEntity>().ToTable("SignalMessage", schema);
    }
    }
}
