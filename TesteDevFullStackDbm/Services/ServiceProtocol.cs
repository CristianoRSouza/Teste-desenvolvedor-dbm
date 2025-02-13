using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteDevFullStackDbm.Data.Context;
using TesteDevFullStackDbm.Data.Dtos;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Data.Repositories;
using TesteDevFullStackDbm.Interfaces.Repositories;
using TesteDevFullStackDbm.Interfaces.Services;

namespace TesteDevFullStackDbm.Services
{
    public class ServiceProtocol : IServiceProtocol
    {
        private readonly IRepositoryProtocol _repositoryProtocol;
        private readonly IRepositoryFollow _repositoryFollow;
        private readonly IRepositoryStatusProtocol _repositoryStatusProtocol;
        private readonly IRepositoryClient _repositoryClient;
        private readonly IMapper _mapper;

        public ServiceProtocol(IRepositoryProtocol protocol, IRepositoryFollow repositoryFollow, IRepositoryStatusProtocol repositoryStatusProtocol, IRepositoryClient repositoryClient, IMapper mapper)
        {
            _repositoryProtocol = protocol;
            _mapper = mapper;
            _repositoryFollow = repositoryFollow;
            _repositoryStatusProtocol = repositoryStatusProtocol;
            _repositoryClient = repositoryClient;
        }

        public async Task<IEnumerable<ProtocolDto>> GetAll()
        {
            return _mapper.Map<List<ProtocolDto>>(await _repositoryProtocol.GetAll());
        }

        public async Task<ProtocolDto> Get(int id)
        {
            var protocol = await _repositoryProtocol.Get(id);
            return _mapper.Map<ProtocolDto>(protocol);
        }

        public async Task Add(ProtocolDto protocol)
        {
            if (protocol == null)
                throw new ArgumentNullException(nameof(protocol));

            var protocolAdd = _mapper.Map<Protocol>(protocol);
            var follow = new ProtocolFollow
            {
                DataAcao = DateTime.Now,
                DescricaoAcao = "Protocolo criado"
            };

            await _repositoryProtocol.AddWithTransaction(protocolAdd, follow);
        }

        public async Task Update(ProtocolDto protocol)
        {
            var existingProtocol = await _repositoryProtocol.Get(protocol.IdProtocol);
            if (existingProtocol == null)
            {
                throw new KeyNotFoundException($"Produto com ID {protocol.IdProtocol} não foi encontrado.");
            }

            if (protocol.ClienteId == 0)
            {
                protocol.ClienteId = existingProtocol.ClienteId;
            }
            if (protocol.ProtocolStatusId == 0)
            {
                protocol.ProtocolStatusId = existingProtocol.ProtocolStatusId;
            }
            _mapper.Map(protocol, existingProtocol);

            await _repositoryProtocol.Update(_mapper.Map<Protocol>(existingProtocol));
        }


        public async Task Delete(int id)
        {
           var follow = await _repositoryFollow.Get(id);
           await _repositoryFollow.Delete(follow.IdFollow);
           await _repositoryProtocol.Delete(id);
        }

        public async Task<IEnumerable<SelectListItem>> GetClientes()
        {
            var clientes = await _repositoryClient.GetAll();
            return clientes.Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text = c.Nome
            }).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetStatus()
        {
            var statusList = await _repositoryStatusProtocol.GetAll();
            return statusList.Select(s => new SelectListItem
            {
                Value = s.IdStatus.ToString(),
                Text = s.NomeStatus
            }).ToList();
        }
    }
}