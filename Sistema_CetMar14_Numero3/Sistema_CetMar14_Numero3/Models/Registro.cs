using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_CetMar14_Numero3.Models
{
    public class Registro
    {
        [Key]
        public int registroHistorialID { get; set; }

        [Required, Display(Name = "Nota")]
        public string registroHistorialnota { get; set; }

        [Required, Display(Name = "Fecha Realizada"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), DataType(DataType.Date)]
        public DateTime registroHistorialFecha { get; set; }

        [Required, Display(Name = "Canalización")]
        public string registroHistorialCanalizacion { get; set; }

        [Required, Display(Name = "Expediente Alumno")]
        public int expedienteID { get; set; }
        public virtual Expediente expedientes { get; set; }
    }
}