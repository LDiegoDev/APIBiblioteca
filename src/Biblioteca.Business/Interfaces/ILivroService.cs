using Biblioteca.Business.Models;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Business.Interfaces
{
    public interface ILivroService : IDisposable
    {
        Task Adicionar(Livro livro);
        Task Atualizar(Livro livro);
        Task Remover(Guid id);
    }
}
