using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetapp.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users (Email, Name, PhoneNumber, PictureUrl) VALUES ('aaa@a.pl', 'admin', 123456789, 'https://vignette.wikia.nocookie.net/daria/images/1/15/Admin.png/revision/latest?cb=20140902104042')");
            migrationBuilder.Sql("INSERT INTO Users (Email, Name, PhoneNumber, PictureUrl) VALUES ('bbb@a.pl', 'user', 222333444, 'https://upload.wikimedia.org/wikipedia/commons/e/e4/Elliot_Grieveson.png')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Name IN ('admin', 'user')");
        }
    }
}
