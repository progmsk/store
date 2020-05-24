using System;

namespace Store
{
    public class OrderItem
    {
        public int BookId { get; }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                ThrowIfInvalidCount(value);

                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price)
        {
            ThrowIfInvalidCount(count);

            BookId = bookId;
            Count = count;
            Price = price;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater than zero.");
        }
    }
}
