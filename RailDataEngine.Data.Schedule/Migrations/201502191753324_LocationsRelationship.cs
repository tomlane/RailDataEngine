namespace RailDataEngine.Data.Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Schedules.Location", "Record_Id", "Schedules.Schedule");
            AddForeignKey("Schedules.Location", "Record_Id", "Schedules.Schedule", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Schedules.Location", "Record_Id", "Schedules.Schedule");
            AddForeignKey("Schedules.Location", "Record_Id", "Schedules.Schedule", "Id");
        }
    }
}
