using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class ListenLog : BaseEntity
    {

        public int MusicId { get; set; }
        public int PackageId { get; set; }
        public int Duration { get; set; }

        public Package Package { get; set; }
        public Music Music { get; set; }
    }
}
