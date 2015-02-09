namespace RailDataEngine.Data.TrainMovements.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TrainMovements.TrainActivation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.String(),
                        CreationTimestamp = c.DateTime(),
                        OriginTimestamp = c.DateTime(),
                        TrainUid = c.String(),
                        ScheduleOriginStanox = c.String(),
                        ScheduleStartDate = c.DateTime(),
                        ScheduleEndDate = c.DateTime(),
                        ScheduleSource = c.Int(),
                        ScheduleType = c.Int(),
                        OriginStanox = c.String(),
                        OriginDepartureTimestamp = c.DateTime(),
                        CallType = c.Int(),
                        CallMode = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TrainMovements.TrainCancellation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.String(),
                        OriginalLocationStanox = c.String(),
                        OriginalLocationTimestamp = c.DateTime(),
                        TocId = c.String(),
                        DepartureTimestamp = c.DateTime(),
                        DivisionCode = c.String(),
                        LocationStanox = c.String(),
                        Timestamp = c.DateTime(),
                        ReasonCode = c.String(),
                        Type = c.Int(),
                        TrainServiceCode = c.String(),
                        TrainFileAdress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TrainMovements.TrainMovement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.String(),
                        ActualTimestamp = c.DateTime(),
                        LocationStanox = c.String(),
                        PassengerTimestamp = c.DateTime(),
                        PlannedTimestamp = c.DateTime(),
                        OriginalLocationStanox = c.String(),
                        OriginalLocationTimestamp = c.DateTime(),
                        PlannedEventType = c.Int(),
                        EventType = c.Int(),
                        EventSource = c.Int(),
                        IsCorrection = c.Boolean(),
                        IsOffRoute = c.Boolean(),
                        Direction = c.Int(),
                        Line = c.String(),
                        Route = c.String(),
                        CurrentTrainId = c.String(),
                        TrainServiceCode = c.String(),
                        DivisionCode = c.String(),
                        TocId = c.String(),
                        TimetableVariation = c.Int(),
                        VariationStatus = c.Int(),
                        NextReportStanox = c.String(),
                        NextReportRunTime = c.Int(),
                        HasTerminated = c.Boolean(),
                        IsDelayMonitoringPoint = c.Boolean(),
                        TrainFileAddress = c.String(),
                        ReportingStanox = c.String(),
                        IsAutoExpected = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TrainMovements.TrainMovement");
            DropTable("TrainMovements.TrainCancellation");
            DropTable("TrainMovements.TrainActivation");
        }
    }
}
