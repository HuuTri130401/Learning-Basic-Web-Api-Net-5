using DemoDotNetAPI.Models;
using System.Collections.Generic;

namespace DemoDotNetAPI.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll(string searchValue, double? from, double? to, string sortBy, int page = 1);

    }
}
