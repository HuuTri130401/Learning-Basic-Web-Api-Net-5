using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoDotNetAPI.Migrations
{
    public partial class UpdateOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderDetail_OrderDetailOrderId_OrderDetailProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderDetailOrderId_OrderDetailProductId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderDetailOrderId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderDetailProductId",
                table: "OrderDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailOrderId",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailProductId",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderDetailOrderId_OrderDetailProductId",
                table: "OrderDetail",
                columns: new[] { "OrderDetailOrderId", "OrderDetailProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderDetail_OrderDetailOrderId_OrderDetailProductId",
                table: "OrderDetail",
                columns: new[] { "OrderDetailOrderId", "OrderDetailProductId" },
                principalTable: "OrderDetail",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
