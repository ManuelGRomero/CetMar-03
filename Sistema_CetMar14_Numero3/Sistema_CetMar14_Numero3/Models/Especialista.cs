using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_CetMar14_Numero3.Models
{
    public class Especialista
    {
        [Key]
        public int especialistaID { get; set; }

        [Required, Display(Name = "RFC del Especialista")]
        public string especialistaRFC { get; set; }

        [Required, Display(Name = "Nombre del Especialista")]
        public string especialistaNombre { get; set; }

        [Required, Display(Name = "Apellido")]
        public string especialistaApellido { get; set; }

        [Required, Display(Name = "Especialidad")]
        public string especialidad { get; set; }

        [Required, Display(Name = "Teléfono")]
        public string especialistaTelefono { get; set; }

        [Required, Display(Name = "Domicilio")]
        public string especialistaDomicilio { get; set; }

        virtual public ICollection<Expediente> expedientes { get; set; }
    }
}