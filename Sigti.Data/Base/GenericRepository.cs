using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sigti.Data.Base
{
    public class GenericRepository<T> :Notifiable<Notification>, IGenericRepository<T> where T : Entity
    {
        private readonly SigtiContext _context;
        public GenericRepository(SigtiContext context)
        {
            _context = context;
        }

        public  bool Create(T entity)
        {
            try
            {
                 _context.Add<T>(entity);
                return true;
            }
            catch (Exception ex)
            {

                AddNotification(new Notification("Create", $"{ex.Message}\n{ex.InnerException}"));
                return false;
            }
         
        }
        public bool Update(T entity)
        {
            try
            {
                
                var entityExists = _context.Set<T>().AsNoTracking().Contains(entity);
                if (!entityExists) AddNotification(new Notification("Update", "Registro não localizado na base de dados!"));
                else _context.Entry(entity).State = EntityState.Modified;
                return true;
                
            }
            catch (Exception ex)
            {


                AddNotification(new Notification("Update", $"{ex.Message}\n{ex.InnerException}"));
                return false;
            }

         
        }


        public bool Delete(Guid id)
        {
            try
            {
                var entity =  _context.Set<T>().Find(id);
                if (entity == null) AddNotification(new Notification("Delete", "Registro não localizado na base de dados!"));
                else _context.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception e)
            {

                AddNotification(new Notification("Delete", $"{e.Message}\n" + e.InnerException));
                return false;
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {

                AddNotification(new Notification("GetAll", $"{e.Message}\n" + e.InnerException));
                return null;
            }

        }

        public async Task<IEnumerable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
            }
            catch (Exception e)
            {

                AddNotification(new Notification("GetAllByExpression", $"{e.Message}\n" + e.InnerException));
                return null;
            }

        }

        public async Task<IEnumerable<T>> GetAllByIdAsync(Guid id)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().Where(t => t.Id == id).ToListAsync();
            }
            catch (Exception e)
            {

                AddNotification(new Notification("GetAllById", $"{e.Message}\n" + e.InnerException));
                return null;
            }
         
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception e)
            {

                AddNotification(new Notification(" GetById", $"{e.Message}\n" + e.InnerException));
                return null;
            }
          
        }
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void NotificationsClear()
        {
           Clear();
        }
    }
}
