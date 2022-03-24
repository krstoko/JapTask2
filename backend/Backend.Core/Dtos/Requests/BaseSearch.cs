namespace backend.Dtos.Requests
{
    public abstract class BaseSearch
    {
        public int? Skip { get; set; }
        public int? PageSize { get; set; }

    }
}
