using Biblioteca.Business.Interfaces;
using Biblioteca.Business.Models;
using Biblioteca.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Biblioteca.Business.Services
{
    public class AutorService : BaseService, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IUser _user;

        public AutorService(IAutorRepository autorRepository,
                              INotificador notificador,
                              IUser user) : base(notificador)
        {
            _autorRepository = autorRepository;
            _user = user;
        }

        public async Task Adicionar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return;

            //var user = _user.GetUserId();

            await _autorRepository.Adicionar(autor);
        }

        public async Task Atualizar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return;

            await _autorRepository.Atualizar(autor);
        }

        public async Task Remover(Guid id)
        {
            await _autorRepository.Remover(id);
        }

        public void Dispose()
        {
            _autorRepository?.Dispose();
        }
    }
}
