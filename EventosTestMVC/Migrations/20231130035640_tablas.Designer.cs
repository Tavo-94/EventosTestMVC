﻿// <auto-generated />
using System;
using EventosTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventosTestMVC.Migrations
{
    [DbContext(typeof(DataContext))]
<<<<<<<< HEAD:EventosTestMVC/Migrations/20231130035640_tablas.Designer.cs
    [Migration("20231130035640_tablas")]
    partial class tablas
========
    [Migration("20231130035101_initialmig")]
    partial class initialmig
>>>>>>>> 99709b53c84d4df451eb76072349195208ebf234:EventosTestMVC/Migrations/20231130035101_initialmig.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventoEntityTag", b =>
                {
                    b.Property<Guid>("EventosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("EventosId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("EventoEntityTag");
                });

            modelBuilder.Entity("EventoEntityUsuarioEntity", b =>
                {
                    b.Property<Guid>("EventosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuariosEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EventosId", "UsuariosEmail");

                    b.HasIndex("UsuariosEmail");

                    b.ToTable("EventoEntityUsuarioEntity");
                });

            modelBuilder.Entity("EventosTestMVC.Models.AvatarUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArchivoLottie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AvatarUsers");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EventosTestMVC.Models.CodigoVestimenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CodigoVestimenta");
                });

            modelBuilder.Entity("EventosTestMVC.Models.EventoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CodigoVestimentaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaDeEvento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TipoEventoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoVestimentaId");

                    b.HasIndex("TipoEventoId");

                    b.ToTable("EventoEntities");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventoEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventoEntityId");

                    b.ToTable("Insumos");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("EventosTestMVC.Models.TagsToEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("TagId");

                    b.ToTable("TagsToEvents");
                });

            modelBuilder.Entity("EventosTestMVC.Models.TipoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoEventos");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioEmail");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UsuarioEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AvatarUserId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.HasIndex("AvatarUserId");

                    b.ToTable("UsuarioEntities");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UsuarioToEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("EventoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioEmail");

                    b.ToTable("UsuarioToEventos");
                });

            modelBuilder.Entity("EventoEntityTag", b =>
                {
                    b.HasOne("EventosTestMVC.Models.EventoEntity", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventosTestMVC.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventoEntityUsuarioEntity", b =>
                {
                    b.HasOne("EventosTestMVC.Models.EventoEntity", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventosTestMVC.Models.UsuarioEntity", null)
                        .WithMany()
                        .HasForeignKey("UsuariosEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventosTestMVC.Models.EventoEntity", b =>
                {
                    b.HasOne("EventosTestMVC.Models.CodigoVestimenta", "CodigoVestimenta")
                        .WithMany("Eventos")
                        .HasForeignKey("CodigoVestimentaId");

                    b.HasOne("EventosTestMVC.Models.TipoEvento", "TipoEvento")
                        .WithMany("Eventos")
                        .HasForeignKey("TipoEventoId");

                    b.Navigation("CodigoVestimenta");

                    b.Navigation("TipoEvento");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Supply", b =>
                {
                    b.HasOne("EventosTestMVC.Models.Category", "Category")
                        .WithMany("Supplies")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EventosTestMVC.Models.EventoEntity", "EventoEntity")
                        .WithMany("Supplies")
                        .HasForeignKey("EventoEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("EventoEntity");
                });

            modelBuilder.Entity("EventosTestMVC.Models.TagsToEvent", b =>
                {
                    b.HasOne("EventosTestMVC.Models.EventoEntity", "Evento")
                        .WithMany("TagEvents")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventosTestMVC.Models.Tag", "Tag")
                        .WithMany("TagEvents")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UserComment", b =>
                {
                    b.HasOne("EventosTestMVC.Models.EventoEntity", "Evento")
                        .WithMany("UserComments")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventosTestMVC.Models.UsuarioEntity", "Usuario")
                        .WithMany("UserComments")
                        .HasForeignKey("UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UsuarioEntity", b =>
                {
                    b.HasOne("EventosTestMVC.Models.AvatarUser", "AvatarUser")
                        .WithMany("Usuario")
                        .HasForeignKey("AvatarUserId");

                    b.Navigation("AvatarUser");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UsuarioToEvento", b =>
                {
                    b.HasOne("EventosTestMVC.Models.EventoEntity", "Evento")
                        .WithMany("UsuarioToEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventosTestMVC.Models.UsuarioEntity", "Usuario")
                        .WithMany("UsuarioToEventos")
                        .HasForeignKey("UsuarioEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EventosTestMVC.Models.AvatarUser", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Category", b =>
                {
                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("EventosTestMVC.Models.CodigoVestimenta", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("EventosTestMVC.Models.EventoEntity", b =>
                {
                    b.Navigation("Supplies");

                    b.Navigation("TagEvents");

                    b.Navigation("UserComments");

                    b.Navigation("UsuarioToEventos");
                });

            modelBuilder.Entity("EventosTestMVC.Models.Tag", b =>
                {
                    b.Navigation("TagEvents");
                });

            modelBuilder.Entity("EventosTestMVC.Models.TipoEvento", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("EventosTestMVC.Models.UsuarioEntity", b =>
                {
                    b.Navigation("UserComments");

                    b.Navigation("UsuarioToEventos");
                });
#pragma warning restore 612, 618
        }
    }
}
