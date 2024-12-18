namespace OneRingAPI.Models
{
    /// <summary>
    /// Resposta genérica das APIs contendo uma mensagem e dados associados.
    /// </summary>
    /// <typeparam name="T">Tipo dos dados retornados.</typeparam>
    public class DataResponse<T>
    {
        /// <summary>
        /// Mensagem da resposta.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dados da resposta.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="message">A mensagem da resposta.</param>
        /// <param name="data">Os dados da resposta.</param>
        public DataResponse(string message, T? data)
        {
            Message = message;
            Data = data;
        }
    }
}