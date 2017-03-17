using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_CetMar14_Numero3.Models
{
    public class Expediente
    {
        [Key]
        public int expedienteID { get; set; }

        [Display(Name = "No. Expediente")]
        public string noExpediente { get; set; }

        [Display(Name = "Alumno")]
        public int alumnoID { get; set; }
        public virtual Alumno alumnos { get; set; }

        [Required, Display(Name = "Especialista")]
        public int especialistaID { get; set; }
        public virtual Especialista especialistas { get; set; }

        virtual public ICollection<Registro> Registro { get; set; }
    }
}