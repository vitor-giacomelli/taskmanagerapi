﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSchedulerApi.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<Task> Tarefas { get; set; }
    }
}
