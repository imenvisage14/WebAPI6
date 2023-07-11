using DAL_CRUD.Interface;
using DAL_CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_CRUD.Service
{
    public class PersonService
    {
        private readonly IRepository<Person> _person;
        public PersonService( IRepository<Person> person)
        {
                _person = person;
        }

        public Person Get(int id)
        {
            return _person.Get(id);
        }
        public IEnumerable<Person> GetAll()
        {
            return _person.GetAll().ToList();
        }
        public async Task<Person> AddPerson(Person person )
        {
            return await _person.Create( person );
        }
        public bool DeletePerson(string UserEmail)
        {

            try
            {
                var DataList = _person.GetAll().Where(x => x.UserEmail == UserEmail).ToList();
                foreach (var item in DataList)
                {
                    _person.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        public bool UpdatePerson(Person person)
        {
            try
            {
                var DataList = _person.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _person.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
