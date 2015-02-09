namespace RailDataEngine.Data.TrainDescriber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TrainDescriberMessages.BerthMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        AreaId = c.String(),
                        MessageType = c.Int(),
                        FromBerth = c.String(),
                        ToBerth = c.String(),
                        TrainDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TrainDescriberMessages.SignalMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        AreaId = c.String(),
                        MessageType = c.Int(),
                        Address = c.String(),
                        Data = c.String(),
                        ReportTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("TrainDescriberMessages.SignalMessage");
            DropTable("TrainDescriberMessages.BerthMessage");
        }
    }
}
