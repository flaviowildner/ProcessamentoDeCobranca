using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models.DTO
{
    public class ClienteDTO
    {
        [Required] public string Cpf { get; set; }

        [Required] public string Nome { get; set; }

        [Required] public string Estado { get; set; }
    }
}