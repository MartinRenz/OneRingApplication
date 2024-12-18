namespace OneRingAPI.Models
{
    public class DataResponse<T>
    {
        public string Message { get; set; }
        public T? Data { get; set; }

        public DataResponse(string message, T? data)
        {
            Message = message;
            Data = data;
        }
    }
}