using System.Collections.ObjectModel;

namespace EcomLDC.SharedKernel
{
    public class BaseEntity // OOP: Inheritance (every Entity will inherit from it)  //Base class for all entities (Id + DomainEvents)
    {
        public Guid id { get; protected set; } = new Guid(); // Encapsulation + Identity + LSP (Liskov Substitution Principle) → Every entity can be identified by its Id

        // هنخزن الأحداث الدومينية اللي حصلت جوّه الكيان أثناء تنفيذ UseCase
        // ملحوظة: الأحداث بتتبعت بعد نجاح SaveChanges (Atomic Outbox style بسيط)
        private readonly List<DomainEvent> _domainEvents = new(); // Encapsulation + SRP (Single Responsibility Principle) → Manages its own domain events
        public IReadOnlyCollection<DomainEvent> DomainEvents => new ReadOnlyCollection<DomainEvent>(_domainEvents);
        // Encapsulation + SRP (Single Responsibility Principle) → Exposes domain events as read-only

        // دالة محمية: الكيان نفسه اللي يناديها لما يحصل حدث منطقي (Invariant satisfied)
        // دالة داخلية لإضافة حدث      // Encapsulation + SRP (Single Responsibility Principle) → Manages its own domain events
        protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        // تُنظَّف بعد الـ SaveChanges       // بننضّف الأحداث بعد ما UnitOfWork يكمّل و يبعتها للـ Handlers
        public void ClearDomainEvents() => _domainEvents.Clear();

    }
}
