using System.Text.Json.Serialization;
using WebApi.Entity;

namespace WebApi.ViewModel
{
    public class ProductRequest
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
