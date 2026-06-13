namespace WebApi.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //Foreign key for Product
        public int ProductId { get; set; }

        //Navigation property for related product
        public Product Product { get; set; }
    }
}
