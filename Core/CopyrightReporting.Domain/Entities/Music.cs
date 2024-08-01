using CopyrightReporting.Domain.Entities.Commons;

namespace CopyrightReporting.Domain.Entities
{
    public class Music : BaseEntity
    {
        public int ProviderId { get; set; } //Bunu koymazsak veritabanında kendisi ilişkilendirecek. Eğer koyarsak, bununla ilişkilendirecek ve biz bunu yönetebilcez.
        public int MusicTypeId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime PublicationDate { get; set; }

        public Provider Provider { get; set; }
        public MusicType MusicType { get; set; }
        public ICollection<ListenLog> ListenLogs { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
