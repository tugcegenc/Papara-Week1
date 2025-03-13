using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Api.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private static List<Product> ProductList = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 1500, Description = "Gaming Laptop", Stock = 10, IsAvailable = true },
        new Product { Id = 2, Name = "Mouse", Price = 50, Description = "Wireless Mouse", Stock = 50, IsAvailable = true },
        new Product { Id = 3, Name = "Keyboard", Price = 50, Description = "Keyboard", Stock = 30, IsAvailable = true },
        new Product { Id = 4, Name = "Monitor", Price = 300, Description = "4K Monitor", Stock = 50, IsAvailable = false }
    };
    
    [HttpGet]
    public IActionResult GetProducts([FromQuery] string? name, [FromQuery] string? sortBy)
    {
        var products = ProductList.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(sortBy))
        {
            if (sortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                products = products.OrderBy(p => p.Price);
            else if (sortBy.Equals("name", StringComparison.OrdinalIgnoreCase))
                products = products.OrderBy(p => p.Name);
        }

        return Ok(products.ToList());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = ProductList.SingleOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = "Product not found" });

        return Ok(product);
    }
    
    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (ProductList.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            return BadRequest(new { message = "Product with the same name already exists" });

        product.Id = ProductList.Any() ? ProductList.Max(p => p.Id) + 1 : 1;
        ProductList.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existingProduct = ProductList.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
            return NotFound(new { message = "Product not found" });

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Description = product.Description;
        existingProduct.Stock = product.Stock;
        existingProduct.IsAvailable = product.IsAvailable;

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = ProductList.SingleOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = "Product not found" });

        ProductList.Remove(product);
        return NoContent();
    }
}
