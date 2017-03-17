using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_CetMar14_Numero3.Models
{
    public class Alumno
    {
        [Key]
        public int alumnoID { get; set; }

        [Required, Display(Name = "Número de Matricula")]
        public int noMatricula { get; set; }

        [Required, Display(Name = "Nombre (s) del Alumno")]
        public string alumnoNombre { get; set; }

        [Required, Display(Name = "Apellido Paterno")]
        public string alumnoApellidoPaterno { get; set; }

        [Required, Display(Name = "Apellido Materno")]
        public string alumnoApellidoMaterno { get; set; }

        [Required, Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento { get; set; }

        [Required, Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required, Display(Name = "Domicilio")]
        public string domicilio { get; set; }

        [Display(Name = "Grupo")]
        public string grupo { get; set; }

        [Display(Name = "¿Actualmente Vives con?")]
        public string pregunta1 { get; set; }

        [Display(Name = "¿Actualmente Presenta un Problema de Salud?")]
        public string pregunta2 { get; set; }

        [Display(Name = "¿Cuánto Pesas?")]
        public string pregunta3 { get; set; }

        [Display(Name = "¿Cuál es tu Talla?")]
        public string pregunta4 { get; set; }

        [Display(Name = "¿Cuántas veces Comes al Día?")]
        public string pregunta5 { get; set; }

        [Display(Name = "¿Cuántas Veces Duermes al Día?")]
        public string pregunta6 { get; set; }

        [Display(Name = "¿Qué Actividad Físca Realizas?")]
        public string pregunta7 { get; set; }

        [Display(Name = "¿Cómo te Ves en los Siguentes 10 años?")]
        public string pregunta8 { get; set; }

        [Display(Name = "¿En Alguna Ocasión haz Consumudo, Tabaco, Alcohol u otras Sustancias?")]
        public string pregunta9 { get; set; }

        virtual public ICollection<Expediente> expedientes { get; set; }

    }
}