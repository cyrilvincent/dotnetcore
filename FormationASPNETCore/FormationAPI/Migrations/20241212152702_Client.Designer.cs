﻿// <auto-generated />
using System;
using FormationAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormationAPI.Migrations
{
    [DbContext(typeof(FormationDbContext))]
    [Migration("20241212152702_Client")]
    partial class Client
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientCompte", b =>
                {
                    b.Property<long>("ClientsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ComptesId")
                        .HasColumnType("bigint");

                    b.HasKey("ClientsId", "ComptesId");

                    b.HasIndex("ComptesId");

                    b.ToTable("compte_client", (string)null);
                });

            modelBuilder.Entity("FormationAPI.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nom");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prenom");

                    b.HasKey("Id");

                    b.ToTable("client", (string)null);
                });

            modelBuilder.Entity("FormationAPI.Entities.Compte", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Commentaire")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("commentaire");

                    b.Property<string>("Devise")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("devise");

                    b.Property<decimal>("Solde")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("solde");

                    b.HasKey("Id");

                    b.ToTable("compte", (string)null);
                });

            modelBuilder.Entity("FormationAPI.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CompteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("montant");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.ToTable("transaction", (string)null);
                });

            modelBuilder.Entity("ClientCompte", b =>
                {
                    b.HasOne("FormationAPI.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormationAPI.Entities.Compte", null)
                        .WithMany()
                        .HasForeignKey("ComptesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormationAPI.Entities.Transaction", b =>
                {
                    b.HasOne("FormationAPI.Entities.Compte", "Compte")
                        .WithMany("Transactions")
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");
                });

            modelBuilder.Entity("FormationAPI.Entities.Compte", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}