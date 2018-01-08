using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetapp.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("INSERT INTO Category (Name) VALUES ('mouse')");
             migrationBuilder.Sql("INSERT INTO Category (Name) VALUES ('keyboard')");
             migrationBuilder.Sql("INSERT INTO Category (Name) VALUES ('headset')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
