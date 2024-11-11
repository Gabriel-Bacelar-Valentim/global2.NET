using global2.NET.Database;
using Microsoft.EntityFrameworkCore;

namespace global2.NET.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FIAPDbContext _context;

        public Repository(FIAPDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            // Verifique se a entidade está anexada ao contexto
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                // Se a entidade não estiver anexada, anexe-a
                _context.Set<T>().Attach(entity);
            }

            // Marque a entidade como deletada
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
