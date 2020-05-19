using System;

namespace Store
{
    public class OrderItem
    {
        public int BookId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");

            BookId = bookId;
            Count = count;
            Price = price;
        }
    }
}
