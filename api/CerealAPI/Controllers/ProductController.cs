using CerealAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CerealAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private CerealContext _context = new CerealContext();

        /// <summary>
        /// Get all products or get a specific product by providing an id.
        /// </summary>
        /// <param name="id">Optional parameter</param>
        /// <returns></returns>
        [EndpointSummary("Get products")]
        [EndpointDescription("Get all products or get a specific product by providing an ID.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(int? id)
        {
            var productsReadOnly = _context.Products.AsNoTracking();
            if (id != null)
            {
                var product = await productsReadOnly.FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    return NoContent();
                }

                return Ok(product);
            }
            else
            {
                var allProducts = await productsReadOnly.ToListAsync();

                return Ok(allProducts);
            }
        }

        /// <summary>
        /// Get products by calories. Use option parameter to get products with 'more' or 'less' calories than the amount specified.
        /// </summary>
        /// <param name="calories"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        [EndpointSummary("Get products by calories")]
        [EndpointDescription("Get all products by calories. Specify 'more' or 'less' in the option parameter to get products with greater or less than the specified calories.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("calories/{calories}")]
        public async Task<ActionResult<List<Product>>> GetByCalories(int calories, string? option = null)
        {
            var productsReadOnly = _context.Products.AsNoTracking();
            List<Product> products = null;

            if (string.IsNullOrWhiteSpace(option))
            {
                products = await productsReadOnly.Where(p => p.Calories == calories).ToListAsync();
            }
            else if (option == "less")
            {
                products = await productsReadOnly.Where(p => p.Calories < calories).ToListAsync();
            }
            else if (option == "more")
            {
                products = await productsReadOnly.Where(p => p.Calories > calories).ToListAsync();
            }
            else
            {
                return NoContent();
            }

            if (products == null ||  products.Count == 0)
            {
                return NoContent();
            }

            return Ok(products);
        }

        /// <summary>
        /// Get products by manufacturer.
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        [EndpointSummary("Get products by manufacturer")]
        [EndpointDescription("Get all products from a specific manufacturer.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("manufacturer/{manufacturer}")]
        public async Task<ActionResult<List<Product>>> GetByManufacturer(string manufacturer = null)
        {
            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                return BadRequest("Please provide a manufacturer");
            }

            var product = await _context.Products.AsNoTracking()
                .Where(p => p.Manufacturer.Contains(manufacturer)).ToListAsync();

            return Ok(product);
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [EndpointSummary("Create a new product")]
        [EndpointDescription("Create a new product by providing a complete object of type Product.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product newProduct)
        {
            try
            {
                if (string.IsNullOrEmpty(newProduct.Manufacturer) || string.IsNullOrWhiteSpace(newProduct.Manufacturer))
                {
                    return BadRequest("Missing manufacturer.");
                }
                if (string.IsNullOrEmpty(newProduct.Name) || string.IsNullOrWhiteSpace(newProduct.Name))
                {
                    return BadRequest("Missing name.");
                }
                newProduct.Id = null;
            
                await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                return Ok(newProduct);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [EndpointSummary("Update a product")]
        [EndpointDescription("Update a product matching ID in the provided product. Only updates properties that are filled out in the provided product.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            try
            {
                Product? dbProduct = await _context.Products.FindAsync(product.Id);

                if (dbProduct == null)
                {
                    return NoContent();
                }

                if (!string.IsNullOrWhiteSpace(product.Name))
                {
                    return BadRequest("Missing name.");
                }

                if (!string.IsNullOrWhiteSpace(product.Manufacturer))
                {
                    return BadRequest("Missing manufacturer.");
                }

                dbProduct = product;
                _context.Products.Update(dbProduct);

                await _context.SaveChangesAsync();
                return Ok(dbProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [EndpointSummary("Update a product")]
        [EndpointDescription("Update a product matching ID in the provided product. Only updates properties that are filled out in the provided product.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] Product product)
        {
            try
            {
                Product? dbProduct = await _context.Products.FindAsync(product.Id);

                if (dbProduct == null)
                {
                    return NoContent();
                }

                if (!string.IsNullOrWhiteSpace(product.Name))
                {
                    dbProduct.Name = product.Name;
                }

                if (!string.IsNullOrWhiteSpace(product.Manufacturer))
                {
                    dbProduct.Manufacturer = product.Manufacturer;
                }

                if (!string.IsNullOrWhiteSpace(product.Type))
                {
                    dbProduct.Type = product.Type;
                }

                if (product.Calories != null)
                {
                    dbProduct.Calories = product.Calories;
                }

                if (product.Protein != null)
                {
                    dbProduct.Protein = product.Protein;
                }

                if (product.Fat != null)
                {
                    dbProduct.Fat = product.Fat;
                }

                if (product.Sodium != null)
                {
                    dbProduct.Sodium = product.Sodium;
                }

                if (product.Fiber != null)
                {
                    dbProduct.Fiber = product.Fiber;
                }

                if (product.Carbo != null)
                {
                    dbProduct.Carbo = product.Carbo;
                }

                if (product.Sugars != null)
                {
                    dbProduct.Sugars = product.Sugars;
                }

                if (product.Potass != null)
                {
                    dbProduct.Potass = product.Potass;
                }

                if (product.Vitamins != null)
                {
                    dbProduct.Vitamins = product.Vitamins;
                }

                if (product.Shelf != null)
                {
                    dbProduct.Shelf = product.Shelf;
                }

                if (product.Weight != null)
                {
                    dbProduct.Weight = product.Weight;
                }

                if (product.Cups != null)
                {
                    dbProduct.Cups = product.Cups;
                }

                if (product.Rating != null)
                {
                    dbProduct.Rating = product.Rating;
                }

                await _context.SaveChangesAsync();
                return Ok(dbProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EndpointSummary("Delete a product")]
        [EndpointDescription("Delete a product with matching ID.")]
        [ProducesResponseType<List<Product>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Product? product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return Ok($"Product '{product.Name}' was deleted.");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
