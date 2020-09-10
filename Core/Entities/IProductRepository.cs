using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int id);

        Task<IReadOnlyList<Product>> GetAllProductsAsync();
    }
}
