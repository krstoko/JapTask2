namespace backend.Dtos.Requests
{
    public class RecipeSearch : BaseSearch
    {
        public int CategoryId { get; set; }
        public string SearchValue { get; set; }
    }
}
