using Linx.Core.Notifications;
using Linx.Core.Services;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Validations;
using System;
using System.Threading.Tasks;

namespace Linx.Player.Domain.Services
{
    public class MusicaService : BaseService, IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;

        public MusicaService(IMusicaRepository musicaRepository,
            INotificador notificador) : base(notificador)
        {
            _musicaRepository = musicaRepository;
        }

        public async Task Adicionar(Musica musica)
        {
            if (!ExecutarValidacao(new MusicaValidation(), musica)) return;

            await _musicaRepository.Adicionar(musica);
        }

        public async Task Atualizar(Musica musica)
        {
            if (!ExecutarValidacao(new MusicaValidation(), musica)) return;

            if (await _musicaRepository.ObterPorId(musica.Id) == null) Notificar("Música não encontrada");

            _musicaRepository.Atualizar(musica);
        }

        public async Task Remover(Guid id)
        {
            if (await _musicaRepository.ObterPorId(id) == null) Notificar("Música não encontrada");

            _musicaRepository.Remover(id);
        }

        public void Dispose()
        {
            _musicaRepository?.Dispose();
        }
    }
}
