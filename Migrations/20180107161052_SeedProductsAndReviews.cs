using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dotnetapp.Migrations
{
    public partial class SeedProductsAndReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'https://images10.newegg.com/NeweggImage/ProductImage/26-153-231-V02.jpg', 'Mouse', 3.0, 1)");
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'https://multimedia.bbycastatic.ca/multimedia/products/500x500/104/10497/10497231.jpg', 'Mouse2', 4.0, 1)");
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'https://images10.newegg.com/ProductImage/23-828-003-28.jpg', 'Keyboard', 5.0, 1)");
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'https://images10.newegg.com/ProductImage/23-828-011-V05.jpg', 'Keyboard2', 4.5, 2)");
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'https://images10.newegg.com/ProductImage/26-197-105-09.jpg', 'Headset', 1.0, 2)");
            migrationBuilder.Sql("INSERT INTO Products (Description, ImageUrl, Name, Rating, UserId) VALUES ('Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 'http://bpc.h-cdn.co/assets/17/09/480x480/gallery-1488659377-logitech-prodigy-gaming-headset.jpg', 'Headset2', 4.5, 2)");
            
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (1, 3.0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 2)");
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (2, 4.0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 2)");
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (3, 5.0, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 2)");
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (4, 4.5, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 1)");
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (5, 2.5, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 1)");
            migrationBuilder.Sql("INSERT INTO Reviews (ProductId, Rating, Text, UserId) VALUES (6, 4.5, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis hendrerit dolor facilisis ornare vulputate. Mauris.', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products WHERE Name IN ('Mouse', 'Mouse2', 'Keyboard', 'Keyboard2', 'Headset', 'Headset2')");
            migrationBuilder.Sql("DELETE FROM Reviews WHERE UserId IN (1, 2)");
        }
    }
}
