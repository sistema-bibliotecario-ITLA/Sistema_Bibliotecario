using Backend_Biblioteca.Core.Application.ViewModels.Autor;

namespace Backend_Biblioteca.Core.Application.Interfaces.Services;

public interface IAutorService
{
    Task<IEnumerable<AutorViewModel>> GetAllWithBooks();
    Task<AutorViewModel> GetByIdWithBooks(int id);
    Task Create(SaveAutorViewModel autorVm);
    Task Update(AutorViewModel autorVm);
    Task Delete(int id);
}