using SQLite;

namespace ProjecTrail.Models
{
    [Table("projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public string Notizen { get; set; }
        public DateTime Erstelldatum { get; set; }
        public string Kostenstelle { get; set; }
    }

}
