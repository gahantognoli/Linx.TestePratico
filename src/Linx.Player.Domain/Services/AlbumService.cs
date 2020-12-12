using Linx.Core.Notifications;
using Linx.Core.Services;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public class AlbumService : BaseService, IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository,
            INotificador notificador) : base(notificador)
        {
            _albumRepository = albumRepository;
        }

        public async Task Adicionar(Album album)
        {
            if (!ExecutarValidacao(new AlbumValidation(), album)) return;

            await _albumRepository.Adicionar(album);
        }

        public async Task Atualizar(Album album)
        {
            if (!ExecutarValidacao(new AlbumValidation(), album)) return;

            if (await _albumRepository.ObterPorId(album.Id) == null) Notificar("Album não encontrado");

            _albumRepository.Atualizar(album);
        }

        public async Task Remover(Guid id)
        {
            if (await _albumRepository.ObterPorId(id) == null) Notificar("Album não encontrado");

            _albumRepository.Remover(id);
        }

        public void Dispose()
        {
            _albumRepository?.Dispose();
        }
    }
}
