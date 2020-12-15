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
    [Route("api/generos")]
    public class GeneroController : MainController
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GeneroController(IGeneroRepository generoRepository, 
            IGeneroService generoService, IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
            _generoService = generoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GeneroViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<GeneroViewModel>>(await _generoRepository.ObterTodos());
        }

        [HttpGet("{id}", Name = "GeneroPorId")]
        public async Task<GeneroViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<GeneroViewModel>(await _generoRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(GeneroViewModel generoViewModel)
        {
            await _generoService.Adicionar(_mapper.Map<Genero>(generoViewModel));

            await Commit(_generoRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return CreatedAtRoute("GeneroPorId", new { id = generoViewModel.Id }, generoViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, GeneroViewModel generoViewModel)
        {
            if (id != generoViewModel.Id) return BadRequest();

            await _generoService.Atualizar(_mapper.Map<Genero>(generoViewModel));

            await Commit(_generoRepository);

            if (!OperacaoValida()) return CustomBadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _generoService.Remover(id);

            await Commit(_generoRepository);

            return Ok();
        }
    }
}
