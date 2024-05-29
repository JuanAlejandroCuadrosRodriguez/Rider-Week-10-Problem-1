using _3.Data;
using _3.Data.Models;
namespace _2.Domain;

public class ClientDomain : IClientDomain
{
    private IClientData _clientData;
    
    public ClientDomain(IClientData clientData)
    {
        _clientData = clientData;
    }
    
    public async Task<int> SaveClientAsync(Client data)
    {
        var existingClient = await _clientData.GetClientByEmailAsync(data.email);
        if (existingClient != null)
        {
            throw new Exception("Client already exists");
        }
        return await _clientData.SaveClientAsync(data);
    }

    public async Task<Boolean> UpdateClientAsync(Client data, int id)
    {
        var existingClient = _clientData.getByIdAsync(id);
        
        return await _clientData.UpdateClientAsync(data, id);
    }

    public async Task<Boolean> DeleteClientAsync(int id)
    {
        return await _clientData.DeleteClientAsync(id);
    }

    public async Task<int> SaveOrderAsync(Order data)
    {
        var client = await _clientData.getByIdAsync(data.ClientId);
        if (client == null)
        {
            throw new Exception("ClientId not found");
        }
        var ordersToday = await _clientData.GetOrdersCountByDateAndClientAsync(data.ClientId, DateTime.Today);
        if (ordersToday >= 5)
        {
            throw new Exception("Orders limit reached");
        }

        data.Date = DateTime.Now;
        return await _clientData.SaveOrderAsync(data);
    }

    public async Task<Boolean> UpdateOrderAsync(Order data, int id)
    {
        var existingOrder = _clientData.getByIdOrderAsync(id);
        
        return await _clientData.UpdateOrderAsync(data, id);
    }

    public async Task<Boolean> DeleteOrderAsync(int id)
    {
        return await _clientData.DeleteOrderAsync(id);
    }
}