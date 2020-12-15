using AutoMapper;
using Linx.Core.Notifications;
using Linx.Player.API.ViewModels;
using Linx.Player.Domain.Entities;
using Linx.Player.Domain.Repositories;
using Linx.Player.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.Player.API.Controllers
{
    [Authorize]
    [Route("api/albuns")]
    public class AlbumController : MainController
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository, 
            IAlbumService albumService, IMapper mapper, 
            INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _albumRepository = albumRepository;
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlbumViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AlbumViewModel>>(await _albumRepository.ObterTodos());
        }

        [HttpGet("{id}", Name = "AlbumPorId")]
        public async Task<AlbumViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AlbumViewModel>(await _albumRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(AlbumViewModel albumViewModel)
        {
            await _albumService.Adicionar(_mapper.Map<Album>(albumViewModel));

            await Commit(_albumRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return CreatedAtRoute("AlbumPorId", new { id = albumViewModel.Id }, albumViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AlbumViewModel albumViewModel)
        {
            if (id != albumViewModel.Id) return BadRequest();

            await _albumService.Atualizar(_mapper.Map<Album>(albumViewModel));

            await Commit(_albumRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _albumService.Remover(id);

            await Commit(_albumRepository);

            return Ok();
        }
    }
}
