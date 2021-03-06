﻿using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskStatusModel> TaskStatusModels { get; set; }
        public DbSet<TaskTime> TaskTimes { get; set; }
    }
}
