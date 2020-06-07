using System;
using System.Collections.Generic;

namespace Store.Contractors
{
    public class CashPaymentService : IPaymentService
    {
        public string Name => "Cash";

        public string Title => "Оплата наличными";

        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                       .AddParameter("orderId", order.Id.ToString());
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step != 1)
                throw new InvalidOperationException("Invalid cash payment step.");

            return Form.CreateLast(Name, step + 1, values);
        }

        public OrderPayment GetPayment(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid payment form.");

            return new OrderPayment(Name, "Оплата наличными", form.Parameters);
        }
    }
}
