﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class DieuChuyens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapPhats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDonVi = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: true),
                    MaTaiSan = table.Column<int>(nullable: true),
                    NgayCapPhat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapPhats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DieuChuyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDVDieuChuyen = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: true),
                    MaTaiSan = table.Column<int>(nullable: true),
                    NgayDieuChuyen = table.Column<DateTime>(nullable: false),
                    TenDVDuocDieuChuyen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieuChuyens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThuHois",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenDonViThuHoi = table.Column<string>(nullable: true),
                    MaTaiSan = table.Column<int>(nullable: true),
                    NgayThuHoi = table.Column<DateTime>(nullable: false),
                    SoLuong = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuHois", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapPhats");

            migrationBuilder.DropTable(
                name: "DieuChuyens");

            migrationBuilder.DropTable(
                name: "ThuHois");
        }
    }
}