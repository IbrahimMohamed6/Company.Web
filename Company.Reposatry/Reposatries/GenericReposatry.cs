using Company.Data.Contexts;
using Company.Data.Entites;
using Company.Reposatry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatry.Reposatries
{
    public class GenericReposatry<T> : IgenericReposatry<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericReposatry(CompanyDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        =>_context.Set<T>().Add(entity);
         
        public void Delete(T entity)
        
          =>  _context.Set<T>().Remove(entity);
            

        public IEnumerable<T> GetAll()
        {
            _context.Set<T>().ToList();
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        =>_context.Set<T>().Find(id);

        public void Update(T entity)
       => _context.Set<T>().Update(entity);
        
        

    }
}
