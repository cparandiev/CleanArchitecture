using Domain.Entities.UserAggregate;

namespace Domain.Entities.AdminAggregate
{
    public class Admin : BaseEntity
    {
        public int UsedId { get; set; }

        public virtual User User { get; set; }
    }
}
