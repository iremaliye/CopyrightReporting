using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class Provider :BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Music> Musics { get; set; }

    }
}
