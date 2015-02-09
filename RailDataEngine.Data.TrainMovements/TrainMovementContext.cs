using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Data.TrainMovements
{
    public class TrainMovementContext : ContextBase, ITrainMovementContext
    {
        public DbSet<TrainMovement> Movements { get; set; } 
        public DbSet<TrainActivation> Activations { get; set; } 
        public DbSet<TrainCancellation> Cancellations { get; set; } 

        public TrainMovementContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<TrainMovementContext>(new NullDatabaseInitializer<TrainMovementContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string schema = "TrainMovements";

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<TrainMovement>().ToTable("TrainMovement", schema);
            modelBuilder.Entity<TrainActivation>().ToTable("TrainActivation", schema);
            modelBuilder.Entity<TrainCancellation>().ToTable("TrainCancellation", schema);
        }
    }
}
