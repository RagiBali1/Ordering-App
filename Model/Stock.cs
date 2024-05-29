using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Projekt.Model
{
    [Table("stock")]
    class Stock
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Planks")]
        public string Planks { get; set; }
        [Column("Beams")]
        public string Beams { get; set; }
        [Column("OSB")]
        public string OSB { get; set; }
        [Column("Panels")]
        public string Panels { get; set; }
    }
}
