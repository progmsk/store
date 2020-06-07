using System.Collections.Generic;

namespace Store.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public OrderItemModel[] Items { get; set; } = new OrderItemModel[0];

        public int TotalCount { get; set; }

        public decimal TotalPrice { get; set; }

        public string CellPhone { get; set; }

        public string DeliveryDescription { get; set; }

        public string PaymentDescription { get; set; }

        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
