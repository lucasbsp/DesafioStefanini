using DesafioStefanini.Models;
using DesafioStefanini.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/ItemController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var item = await _itemService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/ItemController
        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            item.CategoryName = null;
            await _itemService.CreateAsync(item);
            return Ok("Tarefa criada com sucesso!");
        }

        // PUT: api/ItemController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Item newItem)
        {
            var item = await _itemService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            newItem.CategoryName = null;
            await _itemService.UpdateAsync(id, newItem);
            return Ok("Tarefa atualizada com sucesso!");
        }

        // DELETE: api/ItemController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _itemService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            await _itemService.DeleteAsync(id);
            return Ok("Tarefa excluída com sucesso!");
        }
    }
}
