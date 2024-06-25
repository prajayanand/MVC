namespace ApplicationCore.Contracts.Repositories;
//create a repo interface where T is gonna be class of entities
//base repo is gonna have commonly used CRUD methods

public interface IRepository<T> where T : class
{
   T GetById(int id);
   IEnumerable<T> GetAll();
   T Add(T entity);
   T Update(T entity);
   T Delete(T entity);
}