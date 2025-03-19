using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.NET.Models
{
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }

        [Column("NOME")]
        public string nome { get; set; }

        [Column("CPF")]
        public string cpf { get; set; }
    }
}
