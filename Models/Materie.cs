using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SituatieScoalara.Models
{
    public class Materie
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$", ErrorMessage = "Introduceti doar litere, intre 3 si 40"), Required]
        public string Nume { get; set; }
    }
}
