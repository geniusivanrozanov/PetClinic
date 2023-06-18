using PetClinic.DAL.Entities;
using System.Linq.Expressions;

namespace PetClinic.DAL.Interfaces.Repositories;

public interface IReviewRepository
{
    Task<ReviewEntity?> GetReviewAsync(Guid id);
    Task<IEnumerable<ReviewEntity>> GetAllReviewsAsync();
    Task<IEnumerable<ReviewEntity>> FindReviewAsync(Expression<Func<ReviewEntity, bool>> predicate);
    Task<ReviewEntity> AddReviewAsync(ReviewEntity entity);
    Task AddRangeReviewAsync(IEnumerable<ReviewEntity> entities);
    void RemoveReview(ReviewEntity entity);
    void RemoveRangeReview(IEnumerable<ReviewEntity> entities);
    ReviewEntity UpdateReview(ReviewEntity entity);
}
