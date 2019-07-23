﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(AttendanceContext))]
    [Migration("20190722070800_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.AttendanceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AttendanceDate");

                    b.Property<int>("AttendanceEntry");

                    b.Property<long>("PersonID");

                    b.HasKey("Id");

                    b.ToTable("AttendanceItems");
                });

            modelBuilder.Entity("Domain.AttendanceMachine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowMultiple");

                    b.Property<string>("AttendanceEvent");

                    b.Property<TimeSpan>("Duration");

                    b.HasKey("Id");

                    b.ToTable("AttendanceMachines");
                });
#pragma warning restore 612, 618
        }
    }
}
