﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.TaskModel", b =>
                {
                    b.Property<int>("TaskModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TaskStatusModelId");

                    b.Property<string>("Title");

                    b.HasKey("TaskModelId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Models.TaskStatusModel", b =>
                {
                    b.Property<int>("TaskStatusModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskStatusModelName");

                    b.HasKey("TaskStatusModelId");

                    b.ToTable("TaskStatusModels");
                });

            modelBuilder.Entity("Models.TaskTime", b =>
                {
                    b.Property<int>("TaskTimeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TaskModelId");

                    b.HasKey("TaskTimeId");

                    b.HasIndex("TaskModelId");

                    b.ToTable("TaskTimes");
                });

            modelBuilder.Entity("Models.TaskTime", b =>
                {
                    b.HasOne("Models.TaskModel", "TaskModel")
                        .WithMany()
                        .HasForeignKey("TaskModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
