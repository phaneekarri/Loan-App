﻿using CustomerEntities.Models;
using CustomerEntities.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerEntities.Configurations
{
    class AccountOwnerConfiguration : IEntityTypeConfiguration<AccountOwner>
    {
        public void Configure(EntityTypeBuilder<AccountOwner> builder)
        {
            builder.HasQueryFilter(x=>!x.IsDeleted);   
        }
    }
}
