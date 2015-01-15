using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RailDataEngine.Data.Common;
using RailDataEngine.Gateway.Entity.TrainMovements;

namespace RailDataEngine.Data.TrainMovements
{
    public class TrainMovementContext : ContextBase, ITrainMovementContext
    {
        public DbSet<TrainMovementEntity> Movements { get; set; } 
        public DbSet<TrainActivationEntity> Activations { get; set; } 
        public DbSet<TrainCancellationEntity> Cancellations { get; set; } 

        public TrainMovementContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<TrainMovementContext>(new NullDatabaseInitializer<TrainMovementContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string schema = "TrainMovement";

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<TrainMovementEntity>().ToTable("TrainMovement", schema);
            modelBuilder.Entity<TrainActivationEntity>().ToTable("TrainActivation", schema);
            modelBuilder.Entity<TrainCancellationEntity>().ToTable("TrainCancellation", schema);
        }
    }
}
