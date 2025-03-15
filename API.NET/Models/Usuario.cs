using Microsoft.AspNetCore.Mvc;

namespace API.NET.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
