namespace WebApi.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        //Navigation property for related orders
        public List<Order> Orders { get; set; }
    }
}
