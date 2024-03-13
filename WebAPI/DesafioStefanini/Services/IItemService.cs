using DesafioStefanini.Models;

namespace DesafioStefanini.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetById(string id);
        Task CreateAsync(Item category);
        Task UpdateAsync(string id, Item item);
        Task DeleteAsync(string id);
    }
}