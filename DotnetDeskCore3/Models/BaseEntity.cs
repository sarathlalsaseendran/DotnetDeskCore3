using System;

namespace DotnetDeskCore3.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreateAt = DateTime.UtcNow;
        }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
    }
}
