namespace Onion.Core.Application.Services
{
    public class ServiceResponse<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }

    }
}