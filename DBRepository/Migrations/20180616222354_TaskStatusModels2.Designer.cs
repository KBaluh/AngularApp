﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20180616222354_TaskStatusModels2")]
    partial class TaskStatusModels2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
