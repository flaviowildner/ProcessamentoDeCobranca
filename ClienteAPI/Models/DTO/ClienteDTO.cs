namespace ClienteAPI.Models.DTO
{
    public class ClienteDTO
    {
        /// <summary>
        /// The CPF identifier
        /// </summary>
        /// <example>100.268.579-60</example>
        public string Cpf { get; set; }

        /// <summary>
        /// The nome
        /// </summary>
        /// <example>Fulano</example>
        public string Nome { get; set; }

        /// <summary>
        /// The estado
        /// </summary>
        /// <example>RJ</example>
        public string Estado { get; set; }
    }
}