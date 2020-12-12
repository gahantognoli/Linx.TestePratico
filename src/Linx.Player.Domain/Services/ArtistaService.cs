using Linx.Core.Notifications;
using Linx.Core.Services;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public class ArtistaService : BaseService, IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaService(IArtistaRepository artistaRepository,
            INotificador notificador) : base(notificador)
        {
            _artistaRepository = artistaRepository;
        }

        public async Task Adicionar(Artista artista)
        {
            if (!ExecutarValidacao(new ArtistaValidation(), artista)) return;

            await _artistaRepository.Adicionar(artista);
        }

        public async Task Atualizar(Artista artista)
        {
            if (!ExecutarValidacao(new ArtistaValidation(), artista)) return;

            if (await _artistaRepository.ObterPorId(artista.Id) == null) Notificar("Artista não encontrado");

            _artistaRepository.Atualizar(artista);
        }

        public async Task Remover(Guid id)
        {
            if (await _artistaRepository.ObterPorId(id) == null) Notificar("Artista não encontrado");

            _artistaRepository.Remover(id);
        }

        public void Dispose()
        {
            _artistaRepository?.Dispose();
        }
    }
}
