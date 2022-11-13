using System;
using Flunt.Notifications;

namespace Avamotors.Domain.Entities;

public abstract class Entitie : Notifiable<Notification>
{
	protected Entitie()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; set; }
}