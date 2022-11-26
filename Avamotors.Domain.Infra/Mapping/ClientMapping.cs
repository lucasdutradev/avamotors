using Avamotors.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avamotors.Domain.Infra.Mapping;

public class ClientMapping : IEntityTypeConfiguration<Client>
{
	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.Ignore(x => x.Notifications);
		builder.ToTable("Client");

		builder.Property(x => x.Id);

		builder.OwnsOne(x => x.Name, name =>
		{
			name.Ignore(x => x.Notifications);
			name.Property(x => x.FirstName)
				.IsRequired()
				.HasColumnName("Name")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(80);

			// name.Property(x => x.LastName)
			// 	.IsRequired()
			// 	.HasColumnName("Name")
			// 	.HasColumnType("NVARCHAR")
			// 	.HasMaxLength(80);
		});


		builder.OwnsOne(x => x.Cpf, cpf =>
		{
			cpf.Ignore(x => x.Notifications);
			cpf.Property(x => x.CPF)
					.IsRequired()
					.HasColumnName("Cpf")
					.HasColumnType("NVARCHAR")
					.HasMaxLength(11);

		});


		builder.Property(x => x.Address)
				.IsRequired()
				.HasColumnName("Address")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(255);

		builder.OwnsOne(x => x.Email, email =>
		{
			email.Ignore(x => x.Notifications);
			email.Property(x => x.Address)
					.IsRequired()
					.HasColumnName("Email")
					.HasColumnType("NVARCHAR")
					.HasMaxLength(155);

			email.HasIndex(x => x.Address)
					.IsUnique();
		});

		builder.OwnsOne(x => x.Phone, phone =>
		{
			phone.Ignore(x => x.Notifications);
			phone.Property(x => x.Number)
					.IsRequired()
					.HasColumnName("Phone")
					.HasColumnType("NVARCHAR")
					.HasMaxLength(11);
		});

		builder.Property(x => x.Sex)
				.IsRequired()
				.HasColumnName("Sex")
				.HasColumnType("NVARCHAR")
				.HasMaxLength(3);

	}
}