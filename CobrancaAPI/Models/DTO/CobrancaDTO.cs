using System;
using System.ComponentModel.DataAnnotations;
using ClienteAPI.Util;

namespace CobrancaAPI.Models.DTO
{
    public class CobrancaDTO
    {
        [Required] [CPFValidator] public string Cpf { get; set; }

        [Required] public decimal Valor { get; set; }

        [Required] public DateTime Vencimento { get; set; }
    }
}