
namespace DDFinanceBackend.Models.Responses
{
    public class MainResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public MainResponse(T data)
        {
            Success = true;
            Message = "Success";
            Data = data;
        }

        public MainResponse(T data,string error)
        {
            Success = false;
            Message = error;
            Data = default;
        }
    }
}
