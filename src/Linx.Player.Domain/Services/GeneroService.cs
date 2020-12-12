using Linx.Core.Notifications;
using Linx.Core.Services;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository,
            INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
        }

        public async Task Adicionar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            await _generoRepository.Adicionar(genero);
        }

        public async Task Atualizar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return;

            if (await _generoRepository.ObterPorId(genero.Id) == null) Notificar("Genero não encontrado");

            _generoRepository.Atualizar(genero);
        }

        public async Task Remover(Guid id)
        {
            if (await _generoRepository.ObterPorId(id) == null) Notificar("Genero não encontrado");

            _generoRepository.Remover(id);
        }

        public void Dispose()
        {
            _generoRepository?.Dispose();
        }
    }
}
