using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace global2.NET.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddingToOracleDbNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Street = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Complement = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Neighborhood = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    State = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Device",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DeviceName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DeviceType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DeviceStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_EnergyLecture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Consumption = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnergyProduction = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LectureDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_EnergyLecture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_IncentiveScore",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    AcquiredScore = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GoalAchieved = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    GoalAchievedData = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_IncentiveScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_OptimizationAlert",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    AlertType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AlertDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AlertDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_OptimizationAlert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceEnergyLecture",
                columns: table => new
                {
                    DevicesId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EnergyLecturesId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceEnergyLecture", x => new { x.DevicesId, x.EnergyLecturesId });
                    table.ForeignKey(
                        name: "FK_DeviceEnergyLecture_InovaX_Tb_Device_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "InovaX_Tb_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceEnergyLecture_InovaX_Tb_EnergyLecture_EnergyLecturesId",
                        column: x => x.EnergyLecturesId,
                        principalTable: "InovaX_Tb_EnergyLecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_ContactNumber",
                columns: table => new
                {
                    PhoneId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CountryCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DDD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OptimizationAlertsId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_ContactNumber", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_ContactNumber_InovaX_Tb_OptimizationAlert_OptimizationAlertsId",
                        column: x => x.OptimizationAlertsId,
                        principalTable: "InovaX_Tb_OptimizationAlert",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AddressId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    ContactNumbersPhoneId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DevicesId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IncentiveScoreId = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_User_InovaX_Tb_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "InovaX_Tb_Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_User_InovaX_Tb_ContactNumber_ContactNumbersPhoneId",
                        column: x => x.ContactNumbersPhoneId,
                        principalTable: "InovaX_Tb_ContactNumber",
                        principalColumn: "PhoneId");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_User_InovaX_Tb_Device_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "InovaX_Tb_Device",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_User_InovaX_Tb_IncentiveScore_IncentiveScoreId",
                        column: x => x.IncentiveScoreId,
                        principalTable: "InovaX_Tb_IncentiveScore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceEnergyLecture_EnergyLecturesId",
                table: "DeviceEnergyLecture",
                column: "EnergyLecturesId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_ContactNumber_OptimizationAlertsId",
                table: "InovaX_Tb_ContactNumber",
                column: "OptimizationAlertsId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_User_AddressId",
                table: "InovaX_Tb_User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_User_ContactNumbersPhoneId",
                table: "InovaX_Tb_User",
                column: "ContactNumbersPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_User_DevicesId",
                table: "InovaX_Tb_User",
                column: "DevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_User_IncentiveScoreId",
                table: "InovaX_Tb_User",
                column: "IncentiveScoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceEnergyLecture");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_User");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_EnergyLecture");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Address");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_ContactNumber");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Device");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_IncentiveScore");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_OptimizationAlert");
        }
    }
}
