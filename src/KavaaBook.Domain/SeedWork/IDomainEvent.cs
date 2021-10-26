using System;
using MediatR;

namespace KavaaBook.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}