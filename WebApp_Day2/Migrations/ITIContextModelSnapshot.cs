﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_Day2.Models;

#nullable disable

namespace WebApp_Day2.Migrations
{
    [DbContext(typeof(ITIContext))]
    partial class ITIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp_Day2.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FullMark")
                        .HasColumnType("int");

                    b.Property<int?>("Ins_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Ins_ID");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("WebApp_Day2.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("WebApp_Day2.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Emai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Instructors", (string)null);
                });

            modelBuilder.Entity("WebApp_Day2.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Dept_ID")
                        .HasColumnType("int");

                    b.Property<string>("Emai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Dept_ID");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("WebApp_Day2.Models.StudentCourse", b =>
                {
                    b.Property<int>("Std_ID")
                        .HasColumnType("int");

                    b.Property<int>("Crs_ID")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("Std_ID", "Crs_ID");

                    b.HasIndex("Crs_ID");

                    b.ToTable("StudentCourses", (string)null);
                });

            modelBuilder.Entity("WebApp_Day2.Models.Course", b =>
                {
                    b.HasOne("WebApp_Day2.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("Ins_ID");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("WebApp_Day2.Models.Student", b =>
                {
                    b.HasOne("WebApp_Day2.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dept_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApp_Day2.Models.StudentCourse", b =>
                {
                    b.HasOne("WebApp_Day2.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("Crs_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_Day2.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("Std_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApp_Day2.Models.Course", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("WebApp_Day2.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("WebApp_Day2.Models.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("WebApp_Day2.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
