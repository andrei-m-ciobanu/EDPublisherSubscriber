﻿// <auto-generated />
using System;
using EmergencyDepartment.SecondaryAdapter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Migrations
{
    [DbContext(typeof(EmergencyDepartmentDbContext))]
    [Migration("20230822192853_UpdateEntities")]
    partial class UpdateEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.BloodPressure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Diastolic")
                        .HasColumnType("int");

                    b.Property<DateTime>("EffectiveDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Systolic")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("BloodPressures");
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EncounterEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EncounterStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.RespiratoryRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BreathsPerMin")
                        .HasColumnType("float");

                    b.Property<DateTime>("EffectiveDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("RespiratoryRates");
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Temperature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EffectiveDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ValueInCelsius")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.BloodPressure", b =>
                {
                    b.HasOne("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Patient", null)
                        .WithMany("BloodPressures")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.RespiratoryRate", b =>
                {
                    b.HasOne("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Patient", null)
                        .WithMany("RespiratoryRates")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Temperature", b =>
                {
                    b.HasOne("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Patient", null)
                        .WithMany("Temperatures")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmergencyDepartment.SecondaryAdapter.Persistence.Entities.Patient", b =>
                {
                    b.Navigation("BloodPressures");

                    b.Navigation("RespiratoryRates");

                    b.Navigation("Temperatures");
                });
#pragma warning restore 612, 618
        }
    }
}
