namespace DoubleV.BE.Api.Helpers.Response
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Code { get; set; }
    }
}
