﻿
using CustomerEntities.Configurations;
using CustomerEntities.Models;
using Infra;
using InfraEntities.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace CustomerEntities
{
    public class CustomerDbContext : DbContext
    {
        private readonly string user;
        public CustomerDbContext(DbContextOptions options, IUserResolver userResolver) : base(options) { user = userResolver.Get(); }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountOwner> AccountOwners { get; set;}    

        public DbSet<ClientEmailContact> ClientEmailContacts { get; set; }
        public DbSet<ClientPhoneContact> ClientPhoneContacts { get; set; }
        public DbSet<ClientAddressContact> ClientAddressContacts { get; set; }
        public DbSet<Address> Addresses { get; set; }


  


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor(), new AuditEntityInterceptor(user));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder               
               .ApplyConfiguration(new AddressConfiguration())
               .ApplyConfiguration(new AccountConfiguration())
               .ApplyConfiguration(new AccountOwnerConfiguration())
               .ApplyConfiguration(new ClientConfiguration())
               .ApplyConfiguration(new ClientEmailContactConfiguration())
               .ApplyConfiguration(new ClientAddressContactConfiguration())
               .ApplyConfiguration(new ClientPhoneContactConfiguration());
        }
    }
}
