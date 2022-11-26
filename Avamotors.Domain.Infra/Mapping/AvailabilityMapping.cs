using System.Security.Cryptography.X509Certificates;
using Avamotors.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avamotors.Domain.Infra.Mapping;

public class AvailabilityMapping : IEntityTypeConfiguration<Availability>
{
	public void Configure(EntityTypeBuilder<Availability> builder)
	{
		builder.Ignore(x => x.Notifications);
		builder.ToTable("Availability");

		builder.Property(x => x.Id);

		builder.Property(x => x.Date)
				.IsRequired()
				.HasColumnName("Date")
				.HasColumnType("DATETIME");

		builder.Property(x => x.PriceInThisDay)
				.IsRequired()
				.HasColumnName("PriceInThisDay")
				.HasColumnType("DECIMAL")
				.HasPrecision(2, 2);

		builder.Property(x => x.FilledDate)
				.IsRequired()
				.HasColumnName("FilledDate")
				.HasColumnType("BIT");

		builder.HasOne(x => x.Client)
				.WithOne(x => x.Availability)
				.HasForeignKey<Availability>(x => x.ClientId)
				.HasConstraintName("FK_Availability_Client");

		builder.Property(x => x.ClientId)
				.HasColumnType("UNIQUEIDENTIFIER");

		builder.Property(x => x.CarId)
				.HasColumnType("UNIQUEIDENTIFIER");
	}
}
