using System;

namespace Onion.Data.Entities
{
    public abstract class BaseAuditClass
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
