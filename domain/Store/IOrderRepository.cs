using System.Threading.Tasks;

namespace Store
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync();

        Task<Order> GetByIdAsync(int id);

        Task UpdateAsync(Order order);
    }
}
