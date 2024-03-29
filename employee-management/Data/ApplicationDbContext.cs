﻿using employee_management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace employee_management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach(var relationship in builder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys())) {
                builder.Entity<LeaveApplication>()
                        .HasOne(f => f.Status)
                        .WithMany()
                        .HasForeignKey(e => e.StatusId)
                        .OnDelete(DeleteBehavior.Cascade);

            }
        }

        public DbSet<Employee> Employees { get;set; }
        public DbSet<Department> Departments { get;set; }
        public DbSet<Designation>  Designations { get;set; }
        public DbSet<SystemCode> systemCodes { get; set; }
        public DbSet<SystemCodeDetail> systemCodeDetails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
    }
}