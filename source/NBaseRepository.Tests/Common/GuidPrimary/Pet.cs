namespace NBaseRepository.Tests.Common.GuidPrimary
{
    using System;
    using NBaseRepository.GuidPrimary;

    internal class Pet : IEntity
    {
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
