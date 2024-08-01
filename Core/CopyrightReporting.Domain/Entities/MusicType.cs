using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class MusicType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }

    }
}
