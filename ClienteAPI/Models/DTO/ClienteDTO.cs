using System.ComponentModel.DataAnnotations;
using ClienteAPI.Util;

namespace ClienteAPI.Models.DTO
{
    public class ClienteDTO
    {
        [Required]
        [CPFValidator]
        public string Cpf { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Estado { get; set; }
    }
}