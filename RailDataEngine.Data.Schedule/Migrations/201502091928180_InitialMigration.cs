namespace RailDataEngine.Data.Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Schedules.Association",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(),
                        MainTrainUid = c.String(),
                        TrainUid = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Days = c.String(),
                        Category = c.Int(),
                        DateIndicator = c.Int(),
                        Location = c.String(),
                        BaseLocationSuffix = c.String(),
                        LocationSuffix = c.String(),
                        StpIndicator = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedules.Meta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Classification = c.String(),
                        Timestamp = c.DateTime(),
                        Owner = c.String(),
                        MetaData_Type = c.String(),
                        MetaData_Sequence = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedules.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationIdentity = c.Int(),
                        TiplocCode = c.String(),
                        Arrival = c.String(),
                        Departure = c.String(),
                        Pass = c.String(),
                        PublicArrival = c.String(),
                        PublicDeparture = c.String(),
                        Platform = c.String(),
                        Line = c.String(),
                        Path = c.String(),
                        EngineeringAllowance = c.Int(),
                        PathingAllowance = c.Int(),
                        PerformanceAllowance = c.Int(),
                        LocationType = c.Int(),
                        Record_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Schedules.Schedule", t => t.Record_Id)
                .Index(t => t.Record_Id);
            
            CreateTable(
                "Schedules.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainUid = c.String(),
                        TransactionType = c.Int(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        RunningDays = c.String(),
                        BankHolidayRunning = c.Boolean(nullable: false),
                        TrainStatus = c.String(),
                        TrainCategory = c.String(),
                        SignallingId = c.String(),
                        TrainServiceCode = c.String(),
                        BusinessSector = c.String(),
                        PowerType = c.String(),
                        TimingLoad = c.String(),
                        Speed = c.Int(),
                        OperatingCharacteristics = c.String(),
                        TrainClass = c.Int(),
                        Sleepers = c.Int(),
                        Reservations = c.Int(),
                        CateringCode = c.Int(),
                        ServiceBrand = c.Int(),
                        StpIndicator = c.Int(),
                        UicCode = c.String(),
                        AtocCode = c.String(),
                        IsPerformanceMonitoringApplicable = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedules.Tiploc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(),
                        TiplocCode = c.String(),
                        Nalco = c.String(),
                        Stanox = c.String(),
                        CrsCode = c.String(),
                        Description = c.String(),
                        TpsDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Schedules.Location", "Record_Id", "Schedules.Schedule");
            DropIndex("Schedules.Location", new[] { "Record_Id" });
            DropTable("Schedules.Tiploc");
            DropTable("Schedules.Schedule");
            DropTable("Schedules.Location");
            DropTable("Schedules.Meta");
            DropTable("Schedules.Association");
        }
    }
}
