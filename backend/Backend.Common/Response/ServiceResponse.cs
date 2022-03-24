using System.Text.Json;

namespace backend.Core.Common
{

    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public bool LoadMore { get; set; } = true;
        public int TotalDataNumber { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
