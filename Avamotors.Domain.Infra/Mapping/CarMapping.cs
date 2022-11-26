using Avamotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avamotors.Domain.Infra.Mapping;

public class CarMapping : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.Ignore(x => x.Notifications);
		builder.ToTable("Car");

		builder.Property(x => x.Id);

		builder.Property(x => x.Name)
				.IsRequired()
				.HasColumnName("Name")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(80);

		builder.Property(x => x.Km)
				.IsRequired()
				.HasColumnName("Km")
				.HasColumnType("DECIMAL")
				.HasPrecision(2, 2);

		builder.Property(x => x.Year)
				.IsRequired()
				.HasColumnName("Year")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(4);

		builder.Property(x => x.Model)
				.IsRequired()
				.HasColumnName("Model")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(50);

		builder.Property(x => x.Description)
				.IsRequired()
				.HasColumnName("Description")
				.HasColumnType("LONGTEXT");

		builder.Property(x => x.Image)
				.IsRequired()
				.HasColumnName("Image")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(255);

		builder.HasOne<Seller>(x => x.Owner)
				.WithMany(x => x.Cars)
				.HasForeignKey(x => x.SellerId)
				.HasConstraintName("FK_Cars_Owner");

		builder.HasMany<Availability>(x => x.Availabilitys)
				.WithOne(x => x.Car)
				.HasForeignKey(x => x.CarId)
				.HasConstraintName("FK_Car_Availabilitys");

		builder.Property(x => x.SellerId)
				.HasColumnType("UNIQUEIDENTIFIER");
	}
}