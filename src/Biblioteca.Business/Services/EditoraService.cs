using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Business.Services
{
    public class EditoraService : BaseService, IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EditoraService(IEditoraRepository editoraRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)
                || !ExecutarValidacao(new EnderecoValidation(), editora.Endereco)) return false;

            if (_editoraRepository.Buscar(f => f.Documento == editora.Documento).Result.Any())
            {
                Notificar("Já existe uma editora com este documento informado.");
                return false;
            }

            await _editoraRepository.Adicionar(editora);
            return true;
        }

        public async Task<bool> Atualizar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)) return false;

            if (_editoraRepository.Buscar(f => f.Documento == editora.Documento && f.Id != editora.Id).Result.Any())
            {
                Notificar("Já existe uma editora com este documento infomado.");
                return false;
            }

            await _editoraRepository.Atualizar(editora);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_editoraRepository.ObterEditoraLivrosEndereco(id).Result.Livros.Any())
            {
                Notificar("A editora possui livros cadastrados!");
                return false;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorEditora(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _editoraRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _editoraRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
