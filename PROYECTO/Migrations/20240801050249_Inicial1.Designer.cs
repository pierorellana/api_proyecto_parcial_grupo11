﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROYECTO.Entidades;

#nullable disable

namespace PROYECTO.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240801050249_Inicial1")]
    partial class Inicial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PROYECTO.Entidades.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Nombrecategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemsAgregados")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Inventario", b =>
                {
                    b.Property<int>("InventarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventarioId"));

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("InventarioId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Orden", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenId"));

                    b.Property<string>("EstadoOrden")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("SolicitudId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrdenId");

                    b.HasIndex("SolicitudId");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProveedorId"));

                    b.Property<int>("Calidad")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Porductos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tiempoentrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ProveedorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("NombreRol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Solicitud", b =>
                {
                    b.Property<int>("SolicitudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolicitudId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoPaypal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CostoEnvio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CvcTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionCalle1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoProvincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiracionTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolicitudId");

                    b.HasIndex("ProductoId");

                    b.ToTable("SolicitudPedido");
                });

            modelBuilder.Entity("PROYECTO.Entidades.SolicitudSoporte", b =>
                {
                    b.Property<int>("SolicitudSoporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolicitudSoporteId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolicitudSoporteId");

                    b.ToTable("SolicitudSoportes");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Inventario", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROYECTO.Entidades.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Orden", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Solicitud", "Solicitud")
                        .WithMany()
                        .HasForeignKey("SolicitudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Producto", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Proveedor", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Solicitud", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Usuario", b =>
                {
                    b.HasOne("PROYECTO.Entidades.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("PROYECTO.Entidades.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
