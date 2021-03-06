// <auto-generated />
using System;
using GOT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GOT.Migrations
{
    [DbContext(typeof(GotDbContext))]
    [Migration("20211229135119_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
