using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set;}
    
        public ICollection<Music> Musics { get; set; }

    }
}
