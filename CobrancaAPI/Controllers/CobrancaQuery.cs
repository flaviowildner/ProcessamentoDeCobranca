using CobrancaAPI.Util;

namespace CobrancaAPI.Controllers
{
    [AtLeastOneAttribute(ErrorMessage = "At least one attribute is mandatory")]
    public class CobrancaQuery
    {
        public string Cpf { get; set; }

        public int? Mes { get; set; }
    }
}