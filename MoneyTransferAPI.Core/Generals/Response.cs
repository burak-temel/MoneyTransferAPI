namespace MoneyTransferAPI.Core.Generals
{
    public class Response<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public Response()
        {
            // Varsayılan değerler
            Result = false;
            Message = string.Empty;
            Data = default;
            StatusCode = 200; // HTTP 200 OK
        }

        // Hızlı yanıt oluşturmak için yardımcı metodlar
        public static Response<T> Success(T data, string message = "", int statusCode = 200)
        {
            return new Response<T> { Result = true, Data = data, Message = message, StatusCode = statusCode };
        }

        public static Response<T> Fail(string message, int statusCode = 400)
        {
            return new Response<T> { Result = false, Message = message, StatusCode = statusCode };
        }
    }
}