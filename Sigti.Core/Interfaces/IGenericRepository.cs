using Sigti.Core.Entities;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        bool Create(T entity);
        bool Update(T entity);
       bool Delete(Guid id);
        Task<IEnumerable<T>> GetAllByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllByExpressionAsync(Expression<Func<T,bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        Task<int> GetQuantity();


        IReadOnlyCollection<Notification> GetNotifications();
        void NotificationsClear();
    }
}
