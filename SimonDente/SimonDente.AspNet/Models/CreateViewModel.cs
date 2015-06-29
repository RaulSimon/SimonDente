using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimonDente.AspNet.Models
{
    public class CreateViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(11,ErrorMessage = "Minimo de caracteres = 11")]
        public string Cpf { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Minimo de caracteres = 9")]
        public string Rg { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }

    public class CreateViewCovenantModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Business { get; set; }
        [Required]
        public string Plan { get; set; }
        [Required]
        public int Coverage { get; set; }
    }
}