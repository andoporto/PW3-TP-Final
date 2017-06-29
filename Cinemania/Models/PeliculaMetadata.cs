using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinemania.Models
{
    public class PeliculaMetadata
    {
        [Required]
        [Key]
        public int cod { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 10, ErrorMessage = " El {0} debe tener entre 10 y 50 caracteres")]
        public string nombre { get; set; }
        [Required]
        public int descripcion { get; set; }
        [Required]
        public int calificacion { get; set; }
        [Required]
        public int genero { get; set; }
        [Required]  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]             
        public Nullable<System.DateTime> FechaCarga { get; set; }
    }
}