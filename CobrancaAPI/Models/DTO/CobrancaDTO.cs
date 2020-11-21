using System;
using System.ComponentModel.DataAnnotations;

namespace CobrancaAPI.Models.DTO
{
    public class CobrancaDTO
    {
        [Required] public string Cpf { get; set; }

        [Required] public decimal Valor { get; set; }

        [Required] public DateTime Vencimento { get; set; }
    }
}