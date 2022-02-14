﻿// <auto-generated />
using System;
using GOT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GOT.Migrations
{
    [DbContext(typeof(GotDbContext))]
    partial class GotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GOT.Models.LancuchGorski", b =>
                {
                    b.Property<int>("IdL")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdL");

                    b.ToTable("MountRanges");

                    b.HasData(
                        new
                        {
                            IdL = 1,
                            Name = "Tatry"
                        },
                        new
                        {
                            IdL = 2,
                            Name = "Beskidy Zachodnie"
                        },
                        new
                        {
                            IdL = 3,
                            Name = "Beskidy Wschodnie"
                        },
                        new
                        {
                            IdL = 4,
                            Name = "Góry Świętokrzyskie"
                        },
                        new
                        {
                            IdL = 5,
                            Name = "Sudety"
                        });
                });

            modelBuilder.Entity("GOT.Models.OdcinekTrasy", b =>
                {
                    b.Property<int>("IdO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("HeightDiff")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("PointEndId")
                        .HasColumnType("int");

                    b.Property<int>("PointStartId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Trail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdO");

                    b.HasIndex("PointEndId");

                    b.HasIndex("PointStartId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("GOT.Models.Przodownik", b =>
                {
                    b.Property<int>("NrLegitymacji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdT")
                        .HasColumnType("int");

                    b.HasKey("NrLegitymacji");

                    b.HasIndex("IdT");

                    b.ToTable("Leaders");

                    b.HasData(
                        new
                        {
                            NrLegitymacji = 1,
                            IdT = 1
                        },
                        new
                        {
                            NrLegitymacji = 2,
                            IdT = 4
                        });
                });

            modelBuilder.Entity("GOT.Models.Punkt", b =>
                {
                    b.Property<int>("IdP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("IdL")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdP");

                    b.HasIndex("IdL");

                    b.ToTable("Points");

                    b.HasData(
                        new
                        {
                            IdP = 1,
                            Height = 1300.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Rusinowa Polana"
                        },
                        new
                        {
                            IdP = 2,
                            Height = 0.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Dolina Filipka"
                        },
                        new
                        {
                            IdP = 3,
                            Height = 1036.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Wierch Porońca"
                        },
                        new
                        {
                            IdP = 4,
                            Height = 0.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Łysa Polana"
                        },
                        new
                        {
                            IdP = 5,
                            Height = 1489.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Gęsia Szyja"
                        },
                        new
                        {
                            IdP = 6,
                            Height = 0.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Rówień Waksmundzka "
                        },
                        new
                        {
                            IdP = 7,
                            Height = 0.0,
                            IdL = 1,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Psia Trawka"
                        },
                        new
                        {
                            IdP = 8,
                            Height = 0.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Dzięgielów - Zamek"
                        },
                        new
                        {
                            IdP = 9,
                            Height = 0.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Cieszyn przez Mniszewo"
                        },
                        new
                        {
                            IdP = 10,
                            Height = 521.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Jasieniowa"
                        },
                        new
                        {
                            IdP = 11,
                            Height = 0.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Bażantowice"
                        },
                        new
                        {
                            IdP = 12,
                            Height = 621.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Schronisko PTTK Tuł"
                        },
                        new
                        {
                            IdP = 13,
                            Height = 864.0,
                            IdL = 2,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Mała Czantoria"
                        },
                        new
                        {
                            IdP = 14,
                            Height = 384.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Góra św. Marcina"
                        },
                        new
                        {
                            IdP = 15,
                            Height = 403.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Słona Góra"
                        },
                        new
                        {
                            IdP = 16,
                            Height = 390.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Trzemeska Góra"
                        },
                        new
                        {
                            IdP = 17,
                            Height = 0.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Mochnaczka Niżna"
                        },
                        new
                        {
                            IdP = 18,
                            Height = 0.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Banica"
                        },
                        new
                        {
                            IdP = 19,
                            Height = 0.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Izby"
                        },
                        new
                        {
                            IdP = 20,
                            Height = 792.0,
                            IdL = 3,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Dzielec"
                        },
                        new
                        {
                            IdP = 21,
                            Height = 347.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Fajna ryba"
                        },
                        new
                        {
                            IdP = 22,
                            Height = 336.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Buczyna"
                        },
                        new
                        {
                            IdP = 23,
                            Height = 337.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Kozłowa"
                        },
                        new
                        {
                            IdP = 24,
                            Height = 0.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Kuźniaki"
                        },
                        new
                        {
                            IdP = 25,
                            Height = 449.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Siniewska Góra"
                        },
                        new
                        {
                            IdP = 26,
                            Height = 364.0,
                            IdL = 4,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Góra Dobrzeszowska"
                        },
                        new
                        {
                            IdP = 27,
                            Height = 0.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Czerniawa Zdrój"
                        },
                        new
                        {
                            IdP = 28,
                            Height = 776.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Czerniawska Kopa"
                        },
                        new
                        {
                            IdP = 29,
                            Height = 1124.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Smrek (TPG Stóg Izerski)"
                        },
                        new
                        {
                            IdP = 30,
                            Height = 1066.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Łącznik"
                        },
                        new
                        {
                            IdP = 31,
                            Height = 1105.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Stóg Izerski"
                        },
                        new
                        {
                            IdP = 32,
                            Height = 965.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Polana Izerska"
                        },
                        new
                        {
                            IdP = 33,
                            Height = 998.0,
                            IdL = 5,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Rozdroże pod Kopą"
                        });
                });

            modelBuilder.Entity("GOT.Models.SpisTrasPunktowanych", b =>
                {
                    b.Property<int>("IdS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdO")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("IdS");

                    b.HasIndex("IdO");

                    b.ToTable("ScoredTracks");
                });

            modelBuilder.Entity("GOT.Models.Trasa", b =>
                {
                    b.Property<int>("IdTr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdW")
                        .HasColumnType("int");

                    b.HasKey("IdTr");

                    b.HasIndex("IdW");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("GOT.Models.Turysta", b =>
                {
                    b.Property<int>("IdT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppartNr")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("FlatNr")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdT");

                    b.ToTable("Tourists");

                    b.HasData(
                        new
                        {
                            IdT = 1,
                            AppartNr = 9,
                            City = "Wrocław",
                            FlatNr = 2,
                            Login = "Janek123",
                            Name = "Jan",
                            Password = "Haselko123",
                            PostCode = "59-243",
                            Street = "Kazimierska",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            IdT = 2,
                            AppartNr = 9,
                            City = "Wrocław",
                            FlatNr = 2,
                            Login = "Janek1234",
                            Name = "Jan",
                            Password = "Haselko123",
                            PostCode = "59-243",
                            Street = "Kazimierska",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            IdT = 3,
                            AppartNr = 9,
                            City = "Wrocław",
                            FlatNr = 2,
                            Login = "Janek12345",
                            Name = "Jan",
                            Password = "Haselko123",
                            PostCode = "59-243",
                            Street = "Kazimierska",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            IdT = 4,
                            AppartNr = 9,
                            City = "Wrocław",
                            FlatNr = 2,
                            Login = "Janek123456",
                            Name = "Jan",
                            Password = "Haselko123",
                            PostCode = "59-243",
                            Street = "Kazimierska",
                            Surname = "Kowalski"
                        });
                });

            modelBuilder.Entity("GOT.Models.Uprawnienia", b =>
                {
                    b.Property<int>("IdU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdL")
                        .HasColumnType("int");

                    b.Property<int>("NrLegitymacji")
                        .HasColumnType("int");

                    b.HasKey("IdU");

                    b.HasIndex("IdL");

                    b.HasIndex("NrLegitymacji");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            IdU = 1,
                            IdL = 1,
                            NrLegitymacji = 1
                        },
                        new
                        {
                            IdU = 2,
                            IdL = 4,
                            NrLegitymacji = 1
                        });
                });

            modelBuilder.Entity("GOT.Models.Wpis", b =>
                {
                    b.Property<int>("IdWp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdO")
                        .HasColumnType("int");

                    b.Property<int>("IdTr")
                        .HasColumnType("int");

                    b.HasKey("IdWp");

                    b.HasIndex("IdO");

                    b.HasIndex("IdTr");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("GOT.Models.Wycieczka", b =>
                {
                    b.Property<int>("IdW")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<bool>("VerifStatus")
                        .HasColumnType("bit");

                    b.HasKey("IdW");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("GOT.Models.OdcinekTrasy", b =>
                {
                    b.HasOne("GOT.Models.Punkt", "PointEnd")
                        .WithMany()
                        .HasForeignKey("PointEndId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GOT.Models.Punkt", "PointStart")
                        .WithMany()
                        .HasForeignKey("PointStartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PointEnd");

                    b.Navigation("PointStart");
                });

            modelBuilder.Entity("GOT.Models.Przodownik", b =>
                {
                    b.HasOne("GOT.Models.Turysta", "Person")
                        .WithMany()
                        .HasForeignKey("IdT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("GOT.Models.Punkt", b =>
                {
                    b.HasOne("GOT.Models.LancuchGorski", "MountRange")
                        .WithMany()
                        .HasForeignKey("IdL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MountRange");
                });

            modelBuilder.Entity("GOT.Models.SpisTrasPunktowanych", b =>
                {
                    b.HasOne("GOT.Models.OdcinekTrasy", "Track")
                        .WithMany()
                        .HasForeignKey("IdO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("GOT.Models.Trasa", b =>
                {
                    b.HasOne("GOT.Models.Wycieczka", "Trip")
                        .WithMany()
                        .HasForeignKey("IdW")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("GOT.Models.Uprawnienia", b =>
                {
                    b.HasOne("GOT.Models.LancuchGorski", "MountRange")
                        .WithMany()
                        .HasForeignKey("IdL")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GOT.Models.Przodownik", "Leader")
                        .WithMany()
                        .HasForeignKey("NrLegitymacji")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leader");

                    b.Navigation("MountRange");
                });

            modelBuilder.Entity("GOT.Models.Wpis", b =>
                {
                    b.HasOne("GOT.Models.OdcinekTrasy", "Track")
                        .WithMany()
                        .HasForeignKey("IdO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GOT.Models.Trasa", "Route")
                        .WithMany()
                        .HasForeignKey("IdTr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Track");
                });
#pragma warning restore 612, 618
        }
    }
}
