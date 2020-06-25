using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    class OrderRepository : IOrderRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public OrderRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Order> CreateAsync()
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            var dto = Order.DtoFactory.Create();
            dbContext.Orders.Add(dto);
            await dbContext.SaveChangesAsync();

            return Order.Mapper.Map(dto);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            var dto = await dbContext.Orders
                                     .Include(order => order.Items)
                                     .SingleAsync(order => order.Id == id);

            return Order.Mapper.Map(dto);
        }

        public async Task UpdateAsync(Order order)
        {
            var dbContext = dbContextFactory.Create(typeof(OrderRepository));

            await dbContext.SaveChangesAsync();
        }
    }
}
