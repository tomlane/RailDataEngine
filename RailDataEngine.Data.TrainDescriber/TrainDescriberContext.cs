using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Domain.Entity.TrainDescriber.Berth;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Data.TrainDescriber
{
    public class TrainDescriberContext : ContextBase, ITrainDescriberContext
    {
        public DbSet<BerthMessage> BerthMessages { get; set; }
        public DbSet<SignalMessage> SignalMessages { get; set; }

    public TrainDescriberContext(string connectionString)
        : base(connectionString)
    {
        Database.SetInitializer<TrainDescriberContext>(new NullDatabaseInitializer<TrainDescriberContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        const string schema = "TrainDescriberMessages";

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<BerthMessage>().ToTable("BerthMessage", schema);
        modelBuilder.Entity<SignalMessage>().ToTable("SignalMessage", schema);
    }
    }
}
