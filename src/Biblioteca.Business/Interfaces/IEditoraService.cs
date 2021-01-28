using Biblioteca.Business.Models;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Business.Interfaces
{
    public interface IEditoraService : IDisposable
    {
        Task<bool> Adicionar(Editora editora);
        Task<bool> Atualizar(Editora editora);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
