using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Business.Models
{
    public class Editora : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoEditora TipoEditora { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public Endereco Endereco { get; set; }
        public IEnumerable<Livro> Livros { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
    }
}
