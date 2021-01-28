using Biblioteca.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Business.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Task<IEnumerable<Autor>> ObterAutoresEditoras();
        Task<Autor> ObterAutorEditora(Guid id);
    }
}
