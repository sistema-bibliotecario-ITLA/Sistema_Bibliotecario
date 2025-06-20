namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IGenericService<vm, svm> where vm : class
where svm : class
{
    Task<IEnumerable<vm>> GetAll();
    Task<vm> GetById(int id);
    Task<svm> Create(svm entity);
    Task<vm> Update(vm entity);
    Task Delete(int id);
}