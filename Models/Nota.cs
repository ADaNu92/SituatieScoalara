using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SituatieScoalara.Models
{
    public class Nota
    {
        public int ID { get; set; }
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [Display(Name = "Profesor")]
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
        [Display(Name = "Materie")]
        public int MaterieID { get; set; }
        public Materie Materie { get; set; }
        [RegularExpression(@"^[0-9''-'\s]{1,10}$",
        ErrorMessage = "Introduceti doar cifre intre 1 si 10"), Required]
        [Display(Name = "Nota Obtinuta")]
        public int NotaObtinuta { get; set; }
    }
}
