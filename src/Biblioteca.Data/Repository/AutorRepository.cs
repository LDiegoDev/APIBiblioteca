using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Data.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(MeuDbContext context) : base(context) { }

        public async Task<Autor> ObterAutorEditora(Guid id)
        {
            return await Db.Autores.AsNoTracking().Include(f => f.Editora)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Autor>> ObterAutoresEditoras()
        {
            return await Db.Autores.AsNoTracking().Include(f => f.Editora)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }

}
