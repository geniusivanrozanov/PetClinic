using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class OrderCallRepository : BaseRepository<OrderCallEntity, Guid>, IOrderCallRepository
{
    public OrderCallRepository(AppDbContext context) : base(context) { }

    public async Task<OrderCallEntity> AddOrderCallAsync(OrderCallEntity entity) => await AddAsync(entity);
    
    public async Task AddRangeOrderCallAsync(IEnumerable<OrderCallEntity> entities) => await AddRangeAsync(entities);
    
    public async Task<IEnumerable<OrderCallEntity>> FindOrderCallAsync(Expression<Func<OrderCallEntity, bool>> predicate) => await FindAsync(predicate);
   
    public async Task<IEnumerable<OrderCallEntity>> GetAllOrderCallsAsync() => await GetAllAsync();
   
    public async Task<OrderCallEntity?> GetOrderCallAsync(Guid id) => await GetAsync(id);

    public void RemoveOrderCall(OrderCallEntity entity) => Remove(entity);
  
    public void RemoveRangeOrderCall(IEnumerable<OrderCallEntity> entities) => RemoveRange(entities);

    public OrderCallEntity UpdateOrderCall(OrderCallEntity entity) => Update(entity);
}
