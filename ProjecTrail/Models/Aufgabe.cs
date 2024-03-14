using System.ComponentModel.DataAnnotations;

namespace ProjecTrail.Models
{
    public class Aufgabe
    {
        [Key]
        public int Id { get; set; }
        public int ProjektId { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public bool IsCompleted { get; set; }     
    }
}
