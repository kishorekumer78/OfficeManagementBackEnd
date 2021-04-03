﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeMgt.Data;

namespace OfficeMgt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfficeMgt.Models.Flg.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aircraft")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<int>("MissionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PhaseId")
                        .HasColumnType("int");

                    b.Property<string>("Syllabus")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MissionTypeId");

                    b.HasIndex("PhaseId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("OfficeMgt.Models.Flg.MissionType", b =>
                {
                    b.Property<int>("MissionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MissionTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MissionTypeId");

                    b.ToTable("MissionTypes");
                });

            modelBuilder.Entity("OfficeMgt.Models.Flg.Phase", b =>
                {
                    b.Property<int>("PhaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PhaseId");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("OfficeMgt.Models.Flg.Mission", b =>
                {
                    b.HasOne("OfficeMgt.Models.Flg.MissionType", "Type")
                        .WithMany("Missions")
                        .HasForeignKey("MissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfficeMgt.Models.Flg.Phase", "Phase")
                        .WithMany("Missions")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phase");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("OfficeMgt.Models.Flg.MissionType", b =>
                {
                    b.Navigation("Missions");
                });

            modelBuilder.Entity("OfficeMgt.Models.Flg.Phase", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}