using PetClinic.DAL.Entities;
using PetClinic.DAL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace PetClinic.DAL.Repositories;

public class ReviewRepository : BaseRepository<ReviewEntity, Guid>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context) { }

    public async Task AddRangeReviewAsync(IEnumerable<ReviewEntity> entities) => await AddRangeAsync(entities);

    public async Task<ReviewEntity> AddReviewAsync(ReviewEntity entity) => await AddAsync(entity);

    public async Task<IEnumerable<ReviewEntity>> FindReviewAsync(Expression<Func<ReviewEntity, bool>> predicate) => await FindAsync(predicate);
  
    public async Task<IEnumerable<ReviewEntity>> GetAllReviewsAsync() => await GetAllAsync();

    public async Task<ReviewEntity?> GetReviewAsync(Guid id) => await GetAsync(id);

    public void RemoveRangeReview(IEnumerable<ReviewEntity> entities) => RemoveRange(entities);

    public void RemoveReview(ReviewEntity entity) => Remove(entity);

    public ReviewEntity UpdateReview(ReviewEntity entity) => Update(entity);
}
