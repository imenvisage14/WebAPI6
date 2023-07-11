using DAL_CRUD.DATA;
using DAL_CRUD.Interface;
using DAL_CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD.Repository
{
    public class RepositoryPerson: IRepository<Person>
    {
        ApplicationDbContext _context;

        public RepositoryPerson( ApplicationDbContext applicationDbContext )
        {
                _context = applicationDbContext;
        }
        public async Task<Person> Create( Person entity )
        {
            var obj= await _context.Persons.AddAsync( entity );
            _context.SaveChanges();
            return obj.Entity;
        }
        public void Delete( Person entity )
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public IEnumerable<Person> GetAll()
        {
            try
            {

                return _context.Persons.Where(w=>w.IsDeleted==false).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Person Get(int id)
        { 
            return _context.Persons.Where(w=>w.IsDeleted==false &&w.Id==id).FirstOrDefault();
        }
        public void Update(Person entity )
        {
            _context.Persons.Update(entity);
            _context.SaveChanges();
        }

    }
}
