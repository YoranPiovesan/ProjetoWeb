using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FUP_Projeto.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datanascimento { get; set; }
        public string Genero { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public int Matricula { get; set; }
    }
}
