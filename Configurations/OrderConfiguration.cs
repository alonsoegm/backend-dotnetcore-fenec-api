﻿using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations;
/// <summary>
/// Configuration settings for the Order entity.
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(o => o.Id);

		builder.Property(o => o.CustomerName)
			   .IsRequired()
			   .HasMaxLength(100);

		builder.Property(o => o.OrderDate)
			   .IsRequired()
			   .HasDefaultValueSql("GETUTCDATE()"); // Ensuring consistent timestamp behavior
	}
}

