using Demo.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Configurations
{
    public class AppConfig:IEntityTypeConfiguration<Appconfig>
    {
        public void Configure(EntityTypeBuilder<Appconfig> builder)
        {
            builder.ToTable("AppConfig");
            builder.HasKey(c => c.Key);
            builder.Property(c => c.Value).IsRequired();

        }

        
    }
}
