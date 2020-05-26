using System.Collections.Generic;

namespace Store.Web.Models
{
    public class DeliveryModel
    {
        public int OrderId { get; set; }

        public Dictionary<string, string> Methods { get; set; }
    }
}
