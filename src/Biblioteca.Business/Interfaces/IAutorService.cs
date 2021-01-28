using Biblioteca.Business.Models;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Business.Interfaces
{
    public interface IAutorService : IDisposable
    {
        Task Adicionar(Autor autor);
        Task Atualizar(Autor autor);
        Task Remover(Guid id);
    }
}
