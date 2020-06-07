using System;
using System.Collections;
using System.Collections.Generic;

namespace Store
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {
        private readonly List<OrderItem> items;

        public OrderItemCollection(IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            this.items = new List<OrderItem>(items);
        }

        public int Count => items.Count;

        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }

        public OrderItem Get(int bookId)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                return orderItem;

            throw new InvalidOperationException("Book not found.");
        }

        public bool TryGet(int bookId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.BookId == bookId);
            if (index == -1)
            {
                orderItem = null;
                return false;
            }

            orderItem = items[index];
            return true;
        }

        public OrderItem Add(int bookId, decimal price, int count)
        {
            if (TryGet(bookId, out OrderItem orderItem))
                throw new InvalidOperationException("Book already exists.");

            orderItem = new OrderItem(bookId, price, count);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int bookId)
        {
            items.Remove(Get(bookId));
        }
    }
}
