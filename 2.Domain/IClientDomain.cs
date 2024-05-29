using System.Runtime.InteropServices.JavaScript;
using _3.Data.Models;

namespace _2.Domain;

public interface IClientDomain
{
    Task<int> SaveClientAsync(Client data);
    
    Task<Boolean> UpdateClientAsync(Client data, int id);
    
    Task<Boolean> DeleteClientAsync(int id);
    
    Task<int> SaveOrderAsync(Order data);
    
    Task<Boolean> UpdateOrderAsync(Order data, int id);
    
    Task<Boolean> DeleteOrderAsync(int id);
}