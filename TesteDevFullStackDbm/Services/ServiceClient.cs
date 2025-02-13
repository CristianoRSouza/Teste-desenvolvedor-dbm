using AutoMapper;
using TesteDevFullStackDbm.Data.Entities;
using TesteDevFullStackDbm.Interfaces.Repositories;
using TesteDevFullStackDbm.Interfaces.Services;
using TesteDevFullStackDbm.Data.Dtos;

namespace TesteDevFullStackDbm.Services
{
    public class ServiceClient : IServiceClient
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryClient _repositoryClient;

        public ServiceClient(IMapper mapper, IRepositoryClient repositoryClient)
        {   
            _repositoryClient = repositoryClient;
            _mapper = mapper;   
        }
        public async Task AddUser(ClientDto client)
        {
            await _repositoryClient.Add(_mapper.Map<Client>(client));
        }

        public async Task DeleteUser(int id)
        {
            await _repositoryClient.Delete(id);
        }

        public async Task<IEnumerable<ClientDto>> GetAllUser()
        {
            var clients = await _repositoryClient.GetAll();
            return _mapper.Map<IEnumerable<ClientDto>>(clients); 
        }

        public async Task<IEnumerable<Client>> GetClientWithDetails()
        {
            return  await _repositoryClient.GetClientWithDetails();
        }

        public async Task<ClientDto> GetUser(int id)
        {
            return _mapper.Map<ClientDto>(await _repositoryClient.Get(id));
        }

        public async Task UpdateUser(ClientDto client)
        {
            var existingUser = await _repositoryClient.Get(client.IdCliente);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Produto com ID {client.IdCliente} não foi encontrado.");
            }

            _mapper.Map(client, existingUser);


            await _repositoryClient.Update(_mapper.Map<Client>(existingUser));
        }
    }
}
