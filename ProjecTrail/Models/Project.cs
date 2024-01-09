using System.ComponentModel.DataAnnotations;

namespace ProjecTrail.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public DateTime Erstelldatum { get; set; }
        public string Kostenstelle { get; set; }
        public List<Aufgabe> Aufgaben { get; set; }
    }

}
