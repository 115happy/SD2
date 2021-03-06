﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class ChargeConfiguration : EntityTypeConfiguration<Charge>
    {
        public ChargeConfiguration()
        {
            ToTable("tb_charges");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            Property(e => e.Amount)
                .HasColumnName("amount")
                .IsRequired();
        }
    }
}