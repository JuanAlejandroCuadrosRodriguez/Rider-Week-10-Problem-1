using _3.Data.Models;
using _3.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace _3.Data;

public class ClientMySqlData : IClientData
{
    private RappiDBContext _rappiDbContext;
    
    public ClientMySqlData(RappiDBContext rappiDbContext)
    {
        _rappiDbContext = rappiDbContext;
    }
    
    public async Task<int> SaveClientAsync(Client data)
    {
        data.IsActive = true;
        
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _rappiDbContext.Clients.Add(data);
                await _rappiDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return data.Id;
    }

    public async Task<bool> UpdateClientAsync(Client data, int id)
    {
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            var clientToUpdate = _rappiDbContext.Clients.Where(t => t.Id == id).FirstOrDefault();
            clientToUpdate.Name = data.Name;
            clientToUpdate.email = data.email;
            
            _rappiDbContext.Clients.Update(clientToUpdate);
            await _rappiDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        return true;
    }

    public async Task<Boolean> DeleteClientAsync(int id)
    {
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            var clientToDelete = _rappiDbContext.Clients.Where(t => t.Id == id).FirstOrDefault();
            clientToDelete.IsActive = false;
            
            await _rappiDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return true;
    }

    public async Task<List<Client>> getAllClientAsync()
    {
        return await _rappiDbContext.Clients.Where(t => t.IsActive)
            .ToListAsync();
    }

    public async Task<Client> getByIdAsync(int Id)
    {
        return await _rappiDbContext.Clients.Where(t => t.Id == Id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> SaveOrderAsync(Order data)
    {
        data.IsActive = true;
        
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _rappiDbContext.Orders.Add(data);
                await _rappiDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return data.Id;
    }

    public async Task<Boolean> UpdateOrderAsync(Order data, int id)
    {
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            var OrderToUpdate = _rappiDbContext.Orders.Where(t => t.Id == id).FirstOrDefault();
            OrderToUpdate.Date = data.Date;
            OrderToUpdate.Total = data.Total;
            
            _rappiDbContext.Orders.Update(OrderToUpdate);
            await _rappiDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        return true;
    }

    public async Task<List<Order>> getAllOrderAsync()
    {
        return await _rappiDbContext.Orders.Where(t => t.IsActive)
            .ToListAsync();
    }

    public async Task<Order> getByIdOrderAsync(int Id)
    {
        return await _rappiDbContext.Orders.Where(t => t.Id == Id)
            .FirstOrDefaultAsync();
    }

    public async Task<Boolean> DeleteOrderAsync(int id)
    {
        using (var transaction = await _rappiDbContext.Database.BeginTransactionAsync())
        {
            var OrderToDelete = _rappiDbContext.Orders.Where(t => t.Id == id).FirstOrDefault();
            OrderToDelete.IsActive = false;
            
            await _rappiDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        return true;
    }

    public async Task<Client> GetClientByEmailAsync(string email)
    {
        return await _rappiDbContext.Clients.Where(t => t.email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetOrdersCountByDateAndClientAsync(int clientId, DateTime date)
    {
        return await _rappiDbContext.Orders.CountAsync(t => t.ClientId == clientId && t.Date.Date == date.Date);
    }
}