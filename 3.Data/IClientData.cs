using System.Runtime.InteropServices.JavaScript;
using _3.Data.Models;

namespace _3.Data;

public interface IClientData
{
    Task<int> SaveClientAsync(Client data);
    
    Task<Boolean> UpdateClientAsync(Client data, int id);
    
    Task<Boolean> DeleteClientAsync(int id);

    Task<List<Client>> getAllClientAsync();
    
    Task<Client> getByIdAsync(int Id);
    
    Task<int> SaveOrderAsync(Order data);
    
    Task<Boolean> UpdateOrderAsync(Order data, int id);
    
    Task<List<Order>> getAllOrderAsync();
    
    Task<Order> getByIdOrderAsync(int Id);
    
    Task<Boolean> DeleteOrderAsync(int id);
    
    Task<Client> GetClientByEmailAsync(string email);
    
    Task<int> GetOrdersCountByDateAndClientAsync(int clientId, DateTime date);
}