namespace Onion.Core.Application.Services.Orders.Response
{
    public class OrderProductResponse
    {
        public OrderProductResponse(int id,string name,string brand,float price,string code)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Code = code;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public float Price { get; private set; }
        public string Code { get; private set; }
    }
}