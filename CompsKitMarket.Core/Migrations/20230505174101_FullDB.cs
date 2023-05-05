using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompsKitMarket.Core.Migrations
{
    public partial class FullDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoolerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrtiption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoolerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrafProcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Freq = table.Column<double>(type: "float", nullable: false),
                    GProcs = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrafProcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateTimeOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcSockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcSockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStore",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStore", x => new { x.OrdersId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_OrderStore_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStore_Stores_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cpu4 = table.Column<byte>(type: "tinyint", nullable: false),
                    Cpu8 = table.Column<byte>(type: "tinyint", nullable: false),
                    Sata = table.Column<byte>(type: "tinyint", nullable: false),
                    Pcle6 = table.Column<byte>(type: "tinyint", nullable: false),
                    Pcle8 = table.Column<byte>(type: "tinyint", nullable: false),
                    Pcle16 = table.Column<byte>(type: "tinyint", nullable: false),
                    Fdd = table.Column<byte>(type: "tinyint", nullable: false),
                    Ide = table.Column<byte>(type: "tinyint", nullable: false),
                    Usb = table.Column<byte>(type: "tinyint", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Deep = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MotherFormId = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<bool>(type: "bit", nullable: false),
                    VideoLenght = table.Column<int>(type: "int", nullable: false),
                    CoolHeight = table.Column<int>(type: "int", nullable: false),
                    ChargeLength = table.Column<int>(type: "int", nullable: false),
                    Fans = table.Column<byte>(type: "tinyint", nullable: false),
                    InsideHsdSize3 = table.Column<byte>(type: "tinyint", nullable: false),
                    InsideHsdSize2 = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frame_FormFactors_MotherFormId",
                        column: x => x.MotherFormId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frame_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hsd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Connections = table.Column<int>(type: "int", nullable: false),
                    Vol = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hsd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hsd_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagePart",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePart", x => new { x.ImagesId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ImagePart_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagePart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturerPart",
                columns: table => new
                {
                    ManufacturersId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerPart", x => new { x.ManufacturersId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ManufacturerPart_Manufacturers_ManufacturersId",
                        column: x => x.ManufacturersId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturerPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPart",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPart", x => new { x.OrdersId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_OrderPart_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartStores",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartStores", x => new { x.PartId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_PartStores_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cooler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CoolerTypeId = table.Column<int>(type: "int", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: true),
                    TypeCooling = table.Column<int>(type: "int", nullable: false),
                    Diam = table.Column<int>(type: "int", nullable: false),
                    Tdp = table.Column<int>(type: "int", nullable: false),
                    CountFan = table.Column<byte>(type: "tinyint", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Rpm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooler_CoolerTypes_CoolerTypeId",
                        column: x => x.CoolerTypeId,
                        principalTable: "CoolerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cooler_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cooler_ProcSockets_SocketId",
                        column: x => x.SocketId,
                        principalTable: "ProcSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cpu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProcSocketId = table.Column<int>(type: "int", nullable: false),
                    ProcModelId = table.Column<int>(type: "int", nullable: false),
                    Cores = table.Column<byte>(type: "tinyint", nullable: false),
                    Graf = table.Column<bool>(type: "bit", nullable: false),
                    Crystal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseFreq = table.Column<double>(type: "float", nullable: false),
                    MaxFreq = table.Column<double>(type: "float", nullable: false),
                    MultiThread = table.Column<double>(type: "float", nullable: false),
                    Tdp = table.Column<int>(type: "int", nullable: false),
                    BoxType = table.Column<int>(type: "int", nullable: false),
                    Tehprocess = table.Column<int>(type: "int", nullable: false),
                    TypeRamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cpu_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cpu_ProcModels_ProcModelId",
                        column: x => x.ProcModelId,
                        principalTable: "ProcModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpu_ProcSockets_ProcSocketId",
                        column: x => x.ProcSocketId,
                        principalTable: "ProcSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cpu_TypeRams_TypeRamId",
                        column: x => x.TypeRamId,
                        principalTable: "TypeRams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FormFactorId = table.Column<int>(type: "int", nullable: false),
                    TypeRamId = table.Column<int>(type: "int", nullable: false),
                    CountRam = table.Column<int>(type: "int", nullable: false),
                    RamFreq = table.Column<int>(type: "int", nullable: false),
                    M2 = table.Column<byte>(type: "tinyint", nullable: false),
                    Sata3 = table.Column<int>(type: "int", nullable: false),
                    Pci16 = table.Column<byte>(type: "tinyint", nullable: false),
                    Pci8 = table.Column<byte>(type: "tinyint", nullable: false),
                    Pci4 = table.Column<byte>(type: "tinyint", nullable: false),
                    Pci1 = table.Column<byte>(type: "tinyint", nullable: false),
                    ProcSocketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboard_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboard_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboard_ProcSockets_ProcSocketId",
                        column: x => x.ProcSocketId,
                        principalTable: "ProcSockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboard_TypeRams_TypeRamId",
                        column: x => x.TypeRamId,
                        principalTable: "TypeRams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Vol = table.Column<double>(type: "float", nullable: false),
                    Count = table.Column<byte>(type: "tinyint", nullable: false),
                    Freq = table.Column<int>(type: "int", nullable: false),
                    Timings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ram_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ram_TypeRams_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeRams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GrafProcId = table.Column<int>(type: "int", nullable: false),
                    VramVol = table.Column<int>(type: "int", nullable: false),
                    VramTypeId = table.Column<int>(type: "int", nullable: false),
                    BusInter = table.Column<int>(type: "int", nullable: false),
                    Cooling = table.Column<int>(type: "int", nullable: false),
                    Rtx = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_GrafProcs_GrafProcId",
                        column: x => x.GrafProcId,
                        principalTable: "GrafProcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Video_Parts_Id",
                        column: x => x.Id,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Video_TypeRams_VramTypeId",
                        column: x => x.VramTypeId,
                        principalTable: "TypeRams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooler_CoolerTypeId",
                table: "Cooler",
                column: "CoolerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooler_SocketId",
                table: "Cooler",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpu_ProcModelId",
                table: "Cpu",
                column: "ProcModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpu_ProcSocketId",
                table: "Cpu",
                column: "ProcSocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Cpu_TypeRamId",
                table: "Cpu",
                column: "TypeRamId");

            migrationBuilder.CreateIndex(
                name: "IX_Frame_MotherFormId",
                table: "Frame",
                column: "MotherFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagePart_PartsId",
                table: "ImagePart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerPart_PartsId",
                table: "ManufacturerPart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboard_FormFactorId",
                table: "Motherboard",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboard_ProcSocketId",
                table: "Motherboard",
                column: "ProcSocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboard_TypeRamId",
                table: "Motherboard",
                column: "TypeRamId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPart_PartsId",
                table: "OrderPart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStore_StoresId",
                table: "OrderStore",
                column: "StoresId");

            migrationBuilder.CreateIndex(
                name: "IX_PartStores_StoreId",
                table: "PartStores",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Ram_TypeId",
                table: "Ram",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_GrafProcId",
                table: "Video",
                column: "GrafProcId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_VramTypeId",
                table: "Video",
                column: "VramTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Cooler");

            migrationBuilder.DropTable(
                name: "Cpu");

            migrationBuilder.DropTable(
                name: "Frame");

            migrationBuilder.DropTable(
                name: "Hsd");

            migrationBuilder.DropTable(
                name: "ImagePart");

            migrationBuilder.DropTable(
                name: "ManufacturerPart");

            migrationBuilder.DropTable(
                name: "Motherboard");

            migrationBuilder.DropTable(
                name: "OrderPart");

            migrationBuilder.DropTable(
                name: "OrderStore");

            migrationBuilder.DropTable(
                name: "PartStores");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "CoolerTypes");

            migrationBuilder.DropTable(
                name: "ProcModels");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "ProcSockets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "GrafProcs");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "TypeRams");
        }
    }
}
