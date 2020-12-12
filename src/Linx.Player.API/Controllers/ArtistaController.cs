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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linx.Player.API.Controllers
{
    [Route("api/artistas")]
    public class ArtistaController : MainController
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IArtistaService _artistaService;
        private readonly IMapper _mapper;

        public ArtistaController(IArtistaRepository artistaRepository, 
            IArtistaService artistaService, IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _artistaRepository = artistaRepository;
            _artistaService = artistaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ArtistaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ArtistaViewModel>>(await _artistaRepository.ObterTodos());
        }

        [HttpGet("{id}", Name = "ArtistaPorId")]
        public async Task<ArtistaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ArtistaViewModel>(await _artistaRepository.ObterPorId(id));
        }

        [HttpGet("por-quantidade-musicas")]
        public async Task<IEnumerable<ArtistaViewModel>> ObterArtistasComMaisMusicas()
        {
            return _mapper.Map<IEnumerable<ArtistaViewModel>>(await _artistaRepository.ObterArtistasComMaisMusicas());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ArtistaViewModel artistaViewModel)
        {
            await _artistaService.Adicionar(_mapper.Map<Artista>(artistaViewModel));

            await Commit(_artistaRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return CreatedAtRoute("ArtistaPorId", new { id = artistaViewModel.Id }, artistaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ArtistaViewModel artistaViewModel)
        {
            if (id != artistaViewModel.Id) return BadRequest();

            await _artistaService.Atualizar(_mapper.Map<Artista>(artistaViewModel));

            await Commit(_artistaRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _artistaService.Remover(id);

            await Commit(_artistaRepository);

            return Ok();
        }
    }
}
