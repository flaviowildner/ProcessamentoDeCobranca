using System.ComponentModel.DataAnnotations;
using ClienteAPI.Util;

namespace ClienteAPI.Controllers
{
    public class FindClientByCpfParameter
    {
        [Required]
        [CPFValidator]
        public string Cpf { get; set; }
    }
}