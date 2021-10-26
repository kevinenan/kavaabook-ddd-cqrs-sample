using System;

namespace KavaaBook.Domain.SeedWork
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        protected DomainEvent(Guid id, DateTime occuredOn)
        {
            Id = id;
            OccurredOn = occuredOn;
        }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.Now;
        }
    }
}