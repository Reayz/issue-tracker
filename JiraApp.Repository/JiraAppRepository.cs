using JiraApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApp.Repository
{
    public class JiraAppRepository<T> : IJiraAppRepository<T> where T : class
    {
        private readonly JiraAppContext _context;

        private readonly DbSet<T> entities;

        string errorMessage = string.Empty;
        public JiraAppRepository(JiraAppContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }
        public T GetById(object id)
        {
            return entities.Find(id);
        }
        public void Insert(T obj)
        {
            entities.Add(obj);
        }
        public void Update(T obj)
        {
            entities.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(T obj)
        {
            entities.Remove(obj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
