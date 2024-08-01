using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string Name{ get; set;}
        public float Price { get; set; }
        public string Description { get; set; }

        public ICollection <ListenLog> ListenLogs { get; set; } //Bire çok ilişki, her pacckage da birden çok listenLog olabilir.
    }
}
