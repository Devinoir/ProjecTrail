using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProjecTrail.Models
{
    [Table("tasks")]
    public class Aufgabe
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int ProjektId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public bool IsCompleted { get; set; }     
    }
}
