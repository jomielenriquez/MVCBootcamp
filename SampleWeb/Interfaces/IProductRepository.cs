// Interfaces/IProductRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleWeb.Models;

namespace SampleWeb.Interfaces
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