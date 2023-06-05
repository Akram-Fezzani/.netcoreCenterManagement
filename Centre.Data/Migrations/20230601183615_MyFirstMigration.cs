using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Centre.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antennas",
                columns: table => new
                {
                    AntennaId = table.Column<Guid>(nullable: false),
                    AntennaCode = table.Column<int>(nullable: false),
                    AntennaLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antennas", x => x.AntennaId);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomaineId = table.Column<Guid>(nullable: false),
                    DomaineName = table.Column<string>(nullable: true),
                    RaisonSocial = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    CapitalSocial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomaineId);
                });

            migrationBuilder.CreateTable(
                name: "Speculations",
                columns: table => new
                {
                    SpeculationId = table.Column<Guid>(nullable: false),
                    SpeculationCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speculations", x => x.SpeculationId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(nullable: false),
                    LibSouche = table.Column<string>(nullable: true),
                    CodeSouche = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Societys",
                columns: table => new
                {
                    SocietyId = table.Column<Guid>(nullable: false),
                    CodeSociétés = table.Column<int>(nullable: false),
                    RaisonSocial = table.Column<string>(nullable: true),
                    CapitalSocial = table.Column<int>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    tel = table.Column<int>(nullable: false),
                    DomaineId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societys", x => x.SocietyId);
                    table.ForeignKey(
                        name: "FK_Societys_Domains_DomaineId",
                        column: x => x.DomaineId,
                        principalTable: "Domains",
                        principalColumn: "DomaineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    CenterId = table.Column<Guid>(nullable: false),
                    CenterLabel = table.Column<int>(nullable: false),
                    RotationActuelle = table.Column<int>(nullable: false),
                    CodeSpecification = table.Column<int>(nullable: false),
                    UsefulSurface = table.Column<int>(nullable: false),
                    BuildingNumber = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CenterCode = table.Column<int>(nullable: false),
                    SocialReason = table.Column<string>(nullable: true),
                    BlPrefixNumber = table.Column<string>(nullable: true),
                    AntennaId = table.Column<Guid>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.CenterId);
                    table.ForeignKey(
                        name: "FK_Centers_Antennas_AntennaId",
                        column: x => x.AntennaId,
                        principalTable: "Antennas",
                        principalColumn: "AntennaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Centers_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    BuildingCode = table.Column<int>(nullable: false),
                    BuildingLabel = table.Column<int>(nullable: false),
                    BuildingArea = table.Column<int>(nullable: false),
                    BuildingAdress = table.Column<int>(nullable: false),
                    Couvoir = table.Column<int>(nullable: false),
                    Souche = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    rotation = table.Column<int>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChefCenter",
                columns: table => new
                {
                    ChefCenterId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ChefCenterCin = table.Column<int>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    ModificationCin = table.Column<int>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefCenter", x => x.ChefCenterId);
                    table.ForeignKey(
                        name: "FK_ChefCenter_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collectors",
                columns: table => new
                {
                    CollecteurId = table.Column<Guid>(nullable: false),
                    CodeCollecteur = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectors", x => x.CollecteurId);
                    table.ForeignKey(
                        name: "FK_Collectors_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocietyCenters",
                columns: table => new
                {
                    SocietyCenterId = table.Column<Guid>(nullable: false),
                    SocietyId = table.Column<Guid>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocietyCenters", x => x.SocietyCenterId);
                    table.ForeignKey(
                        name: "FK_SocietyCenters_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocietyCenters_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Societys",
                        principalColumn: "SocietyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeculationCenters",
                columns: table => new
                {
                    SpeculationCenterId = table.Column<Guid>(nullable: false),
                    CenterId = table.Column<Guid>(nullable: false),
                    SpeculationId = table.Column<Guid>(nullable: false),
                    SpeculationCenterCode = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SpeculationCenterLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeculationCenters", x => x.SpeculationCenterId);
                    table.ForeignKey(
                        name: "FK_SpeculationCenters_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "CenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpeculationCenters_Speculations_SpeculationId",
                        column: x => x.SpeculationId,
                        principalTable: "Speculations",
                        principalColumn: "SpeculationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CenterId",
                table: "Buildings",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_AntennaId",
                table: "Centers",
                column: "AntennaId");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_TypeId",
                table: "Centers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChefCenter_CenterId",
                table: "ChefCenter",
                column: "CenterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collectors_CenterId",
                table: "Collectors",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyCenters_CenterId",
                table: "SocietyCenters",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SocietyCenters_SocietyId",
                table: "SocietyCenters",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Societys_DomaineId",
                table: "Societys",
                column: "DomaineId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeculationCenters_CenterId",
                table: "SpeculationCenters",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeculationCenters_SpeculationId",
                table: "SpeculationCenters",
                column: "SpeculationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "ChefCenter");

            migrationBuilder.DropTable(
                name: "Collectors");

            migrationBuilder.DropTable(
                name: "SocietyCenters");

            migrationBuilder.DropTable(
                name: "SpeculationCenters");

            migrationBuilder.DropTable(
                name: "Societys");

            migrationBuilder.DropTable(
                name: "Centers");

            migrationBuilder.DropTable(
                name: "Speculations");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Antennas");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
