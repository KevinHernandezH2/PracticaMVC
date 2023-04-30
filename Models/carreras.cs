using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class carreras
    {

        [Key]

        [Display(Name = "ID")]
        public int carrera_id { get; set; }

        [Display(Name = "Nombre de la Carrera")]
        public string? nombre_carrera { get; set; }

        [Display(Name = "ID de la Facultad")]
        public int facultad_id { get; set; }

        [Display(Name = "Estado")]
        public string? estado { get; set; }
    }
}
