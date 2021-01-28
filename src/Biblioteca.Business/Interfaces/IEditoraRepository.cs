using Biblioteca.Business.Models;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> ObterEditoraEndereco(Guid id);
        Task<Editora> ObterEditoraLivrosEndereco(Guid id);
    }
}
