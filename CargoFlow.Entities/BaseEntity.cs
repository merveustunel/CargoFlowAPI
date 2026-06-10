#nullable enable
using System;

namespace CargoFlow.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
