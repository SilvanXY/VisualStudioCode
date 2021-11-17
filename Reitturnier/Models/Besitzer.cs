using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Reitturnier.Models
{
     [Table("tbl_Besitzer", Schema = "dbo")]
    public class Besitzer
    {
        [Key]
        [ReadOnly(true)]
        public int Rowguid { get; set; }
        [Display(Name = "NN")]
        public string Nachname { get; set; }
        [Display(Name = "VN")]
        public string Vorname { get; set; }
        public string Strasse { get; set; }
        public int? PLZ { get; set; }
        public string Ort { get; set; }

    }
}
