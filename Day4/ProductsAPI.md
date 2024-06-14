# Creating Products API

 - 1. Install entity framwork core
    Install the necessary EF Core packages:
    ```
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    ```

 - 2. Create your data models

    Create your entity classes. These classes represent the tables in your database. For example, create a `Models` folder and add a `Product` class:

    ```cs
    // Models/Product.cs
    namespace MyApp.Models
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
    ```

 - 3. Create the Database Context

    The DbContext class manages the entity objects during runtime, which includes populating objects with data from a database, change tracking, and persisting data to the database. Create a `Data` folder and add an `AppDbContext` class:

    ```cs
    // Data/AppDbContext.cs
    using Microsoft.EntityFrameworkCore;
    using MyApp.Models;

    namespace MyApp.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
        }
    }
    ```

 - 4. Create Repository Patter

    To abstract the data access logic, you can use the repository pattern. Create an `Interfaces` folder and add an `IProductRepository` interface:

    ```cs
    // Interfaces/IProductRepository.cs
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyApp.Models;

    namespace MyApp.Interfaces
    {
        public interface IProductRepository
        {
            Task<IEnumerable<Product>> GetAllProducts();
            Task<Product> GetProductById(int id);
            Task AddProduct(Product product);
            Task UpdateProduct(Product product);
            Task DeleteProduct(int id);
        }
    }
    ```

    Implement this interface in a Repositories folder:

    ```cs
    // Repositories/ProductRepository.cs
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyApp.Data;
    using MyApp.Interfaces;
    using MyApp.Models;

    namespace MyApp.Repositories
    {
        public class ProductRepository : IProductRepository
        {
            private readonly AppDbContext _context;

            public ProductRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> GetAllProducts()
            {
                return await _context.Products.ToListAsync();
            }

            public async Task<Product> GetProductById(int id)
            {
                return await _context.Products.FindAsync(id);
            }

            public async Task AddProduct(Product product)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateProduct(Product product)
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

    ```

 - 5. Create your Controller

    Create a `Controllers` folder and add a `ProductsController`:

    ```cs
    // Controllers/ProductsController.cs
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyApp.Interfaces;
    using MyApp.Models;

    namespace MyApp.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IProductRepository _productRepository;

            public ProductsController(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
            {
                var products = await _productRepository.GetAllProducts();
                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> GetProduct(int id)
            {
                var product = await _productRepository.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }

            [HttpPost]
            public async Task<ActionResult<Product>> PostProduct(Product product)
            {
                await _productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutProduct(int id, Product product)
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                await _productRepository.UpdateProduct(product);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                await _productRepository.DeleteProduct(id);
                return NoContent();
            }
        }
    }
    ```

 - 6. Configure the Database Context

    In your `Program.cs` file, configure the database context in the `ConfigureServices` method:

    ```cs
    // Include the necessary package and code
    using Microsoft.EntityFrameworkCore;
    using SampleWeb.Data;
    using SampleWeb.Interfaces;
    using SampleWeb.Repositories;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllersWithViews();

    // Add DbContext with SQL Server provider
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Add repository dependency
    builder.Services.AddScoped<IProductRepository, ProductRepository>();

    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
    ```

    Also, add your connection string in `appsettings.json`:

    ```json
    {
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*",
        "ConnectionStrings": {
            "DefaultConnection": "Server=server_name;Database=database_name;Trusted_Connection=True;TrustServerCertificate=True"
        }
    }
    ```

 - 7. Apply Migration and Update Database

    install EF Core tools

    ```bash
    dotnet tool install --global dotnet-ef
    ```

    Run the following commands to create and apply the initial migration, and then update the database:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```