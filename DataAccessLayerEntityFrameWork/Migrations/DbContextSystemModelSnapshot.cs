﻿// <auto-generated />
using DataAccessLayerEntityFrameWork.ContextDbs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayerEntityFrameWork.Migrations
{
    [DbContext(typeof(DbContextSystem))]
    partial class DbContextSystemModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Models.HR.HrDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DomainLayer.Models.HR.HrDepartmentEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Department_Id")
                        .HasColumnType("int");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Department_Id");

                    b.HasIndex("Employee_Id");

                    b.ToTable("HrDepartmentEmployee");
                });

            modelBuilder.Entity("DomainLayer.Models.HR.HrEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DomainLayer.Models.HR.HrDepartmentEmployee", b =>
                {
                    b.HasOne("DomainLayer.Models.HR.HrDepartment", "Department")
                        .WithMany("DepartmentEmployees")
                        .HasForeignKey("Department_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.HR.HrEmployee", "Employee")
                        .WithMany("DepartmentEmployees")
                        .HasForeignKey("Employee_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DomainLayer.Models.HR.HrDepartment", b =>
                {
                    b.Navigation("DepartmentEmployees");
                });

            modelBuilder.Entity("DomainLayer.Models.HR.HrEmployee", b =>
                {
                    b.Navigation("DepartmentEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
