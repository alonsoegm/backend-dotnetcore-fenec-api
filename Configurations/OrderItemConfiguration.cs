using FenecApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FenecApi.Configurations
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.HasKey(oi => oi.Id);
			builder.Property(oi => oi.Quantity)
				   .IsRequired();

			builder.HasOne(oi => oi.Order)
				   .WithMany(o => o.OrderItems)
				   .HasForeignKey(oi => oi.OrderId);

			builder.HasOne(oi => oi.Product)
				   .WithMany()
				   .HasForeignKey(oi => oi.ProductId);
		}
	}
}
