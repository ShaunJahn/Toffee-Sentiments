namespace Toffee_Sentiments.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public CardCreationDto card { get; set; }
        public int Amount { get; set; }
  

        public virtual Order Order { get; set; }
    }
}