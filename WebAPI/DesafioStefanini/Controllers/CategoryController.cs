﻿using DesafioStefanini.Models;
using DesafioStefanini.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET: api/CategoryController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/CategoryController
        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _categoryService.CreateAsync(category);
            return Ok("Categoria criada com sucesso!");
        }

        // PUT: api/CategoryController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category newCategory)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryService.UpdateAsync(id, newCategory);
            return Ok("Categoria atualizada com sucesso!");
        }

        // DELETE: api/CategoryController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteAsync(id);
            return Ok("Categoria excluída com sucesso!");
        }
    }
}
