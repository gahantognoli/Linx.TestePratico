using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Linx.Core.Notifications;
using Linx.Player.API.ViewModels;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Linx.Player.API.Controllers
{
    [Route("api/musicas")]
    public class MusicaController : MainController
    {
        private readonly IMusicaRepository _musicaRepository;
        private readonly IMusicaService _musicaService;
        private readonly IMapper _mapper;

        public MusicaController(IMusicaRepository musicaRepository, 
            IMusicaService musicaService, IMapper mapper, 
            INotificador notificador) : base(notificador)
        {
            _musicaRepository = musicaRepository;
            _musicaService = musicaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MusicaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<MusicaViewModel>>(await _musicaRepository.ObterTodos());
        }

        [HttpGet("{id}", Name = "MusicaPorId")]
        public async Task<MusicaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<MusicaViewModel>(await _musicaRepository.ObterPorId(id));
        }

        [HttpGet("por-genero")]
        public async Task<IEnumerable<MusicaViewModel>> ObterPorGenero(string genero)
        {
            return _mapper.Map<IEnumerable<MusicaViewModel>>(await _musicaRepository.ObterPorGenero(genero));
        }

        [HttpGet("por-artista")]
        public async Task<IEnumerable<MusicaViewModel>> ObterPorArtista(string artista)
        {
            return _mapper.Map<IEnumerable<MusicaViewModel>>(await _musicaRepository.ObterPorArtista(artista));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(MusicaViewModel musicaViewModel)
        {
            await _musicaService.Adicionar(_mapper.Map<Musica>(musicaViewModel));

            await Commit(_musicaRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return CreatedAtRoute("MusicaPorId", new { id = musicaViewModel.Id }, musicaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, MusicaViewModel musicaViewModel)
        {
            if (id != musicaViewModel.Id) return BadRequest();

            await _musicaService.Atualizar(_mapper.Map<Musica>(musicaViewModel));

            await Commit(_musicaRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _musicaService.Remover(id);

            await Commit(_musicaRepository);

            return Ok();
        }
    }
}
