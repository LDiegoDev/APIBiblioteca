using System;
using System.Collections.Generic;

namespace Biblioteca.Business.Models
{
    public class Autor : Entity
    {
        public Guid EditoraId { get; set; }
        public string Nome { get; set; }

        /* EF Relations */
        public Editora Editora { get; set; }
        public IEnumerable<Livro> Livros { get; set; }

    }
}
