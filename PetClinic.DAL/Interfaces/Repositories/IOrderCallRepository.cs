using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IOrderCallRepository
{
    Task<OrderCallEntity?> GetOrderCallAsync(Guid id);
    Task<IEnumerable<OrderCallEntity>> GetAllOrderCallsAsync();
    Task<IEnumerable<OrderCallEntity>> FindOrderCallAsync(Expression<Func<OrderCallEntity, bool>> predicate);
    Task<OrderCallEntity> AddOrderCallAsync(OrderCallEntity entity);
    Task AddRangeOrderCallAsync(IEnumerable<OrderCallEntity> entities);
    void RemoveOrderCall(OrderCallEntity entity);
    void RemoveRangeOrderCall(IEnumerable<OrderCallEntity> entities);
    OrderCallEntity UpdateOrderCall(OrderCallEntity entity);
}
