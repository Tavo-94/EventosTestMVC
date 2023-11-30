using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventosTestMVC.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvatarUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchivoLottie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodigoVestimenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoVestimenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEntities",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEntities", x => x.Email);
                    table.ForeignKey(
                        name: "FK_UsuarioEntities_AvatarUsers_AvatarUserId",
                        column: x => x.AvatarUserId,
                        principalTable: "AvatarUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventoEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoVestimentaId = table.Column<int>(type: "int", nullable: true),
                    TipoEventoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoEntities_CodigoVestimenta_CodigoVestimentaId",
                        column: x => x.CodigoVestimentaId,
                        principalTable: "CodigoVestimenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventoEntities_TipoEventos_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEventos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_EventoEntities_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_UsuarioEntities_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalTable: "UsuarioEntities",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoEntityTag",
                columns: table => new
                {
                    EventosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoEntityTag", x => new { x.EventosId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventoEntityTag_Etiquetas_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoEntityTag_EventoEntities_EventosId",
                        column: x => x.EventosId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoEntityUsuarioEntity",
                columns: table => new
                {
                    EventosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoEntityUsuarioEntity", x => new { x.EventosId, x.UsuariosEmail });
                    table.ForeignKey(
                        name: "FK_EventoEntityUsuarioEntity_EventoEntities_EventosId",
                        column: x => x.EventosId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoEntityUsuarioEntity_UsuarioEntities_UsuariosEmail",
                        column: x => x.UsuariosEmail,
                        principalTable: "UsuarioEntities",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    EventoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insumos_Categorias_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Insumos_EventoEntities_EventoEntityId",
                        column: x => x.EventoEntityId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagsToEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsToEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsToEvents_Etiquetas_TagId",
                        column: x => x.TagId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsToEvents_EventoEntities_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioToEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioToEventos_EventoEntities_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventoEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioToEventos_UsuarioEntities_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalTable: "UsuarioEntities",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EventoId",
                table: "Comentarios",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioEmail",
                table: "Comentarios",
                column: "UsuarioEmail");

            migrationBuilder.CreateIndex(
                name: "IX_EventoEntities_CodigoVestimentaId",
                table: "EventoEntities",
                column: "CodigoVestimentaId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoEntities_TipoEventoId",
                table: "EventoEntities",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoEntityTag_TagsId",
                table: "EventoEntityTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoEntityUsuarioEntity_UsuariosEmail",
                table: "EventoEntityUsuarioEntity",
                column: "UsuariosEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_CategoryId",
                table: "Insumos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_EventoEntityId",
                table: "Insumos",
                column: "EventoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsToEvents_EventoId",
                table: "TagsToEvents",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsToEvents_TagId",
                table: "TagsToEvents",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEntities_AvatarUserId",
                table: "UsuarioEntities",
                column: "AvatarUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToEventos_EventoId",
                table: "UsuarioToEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToEventos_UsuarioEmail",
                table: "UsuarioToEventos",
                column: "UsuarioEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "EventoEntityTag");

            migrationBuilder.DropTable(
                name: "EventoEntityUsuarioEntity");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "TagsToEvents");

            migrationBuilder.DropTable(
                name: "UsuarioToEventos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "EventoEntities");

            migrationBuilder.DropTable(
                name: "UsuarioEntities");

            migrationBuilder.DropTable(
                name: "CodigoVestimenta");

            migrationBuilder.DropTable(
                name: "TipoEventos");

            migrationBuilder.DropTable(
                name: "AvatarUsers");
        }
    }
}
