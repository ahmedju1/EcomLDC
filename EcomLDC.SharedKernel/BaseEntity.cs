namespace EcomLDC.SharedKernel
{
    public class BaseEntity // OOP: Inheritance (every Entity will inherit from it)  //Base class for all entities (Id + DomainEvents)
    {
        public Guid id { get; protected set; } = new Guid(); // Encapsulation + Identity + LSP (Liskov Substitution Principle) → Every entity can be identified by its Id
        private readonly List<DomainEvent> _domainEvents = new(); // Encapsulation + SRP (Single Responsibility Principle) → Manages its own domain events
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly(); // Encapsulation + SRP (Single Responsibility Principle) → Exposes domain events as read-only
        protected void AddDomainEvent(DomainEvent domainEvent) // Encapsulation + SRP (Single Responsibility Principle) → Manages its own domain events
        {
            _domainEvents.Add(domainEvent);
        }

    }
}
