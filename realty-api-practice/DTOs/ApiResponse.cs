namespace realty_api_practice.DTOs
{
    public class ApiResponse<T> 
    {
        //every single endpoint in the api returns this shpae=sucess or failure
        //the frontend always knows what to expect {success, message, data

        public bool Success { get; set;  }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set;  }

        //static factory methods so controllers stay cl3ean -no manul object creation
        public static ApiResponse<T> Ok(T data, string message = "Success")
            => new() { Success = true, Message = message, Data = data };

        public static ApiResponse<T> Fail(string message) 
            => new() { Success = false, Message = message } ;

    }
}
