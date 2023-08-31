using DemoDotNetAPI.Data;
using DemoDotNetAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoDotNetAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(DemoDbContext context) { 
            _context = context;
        }
        public List<ProductModel> GetAll(string searchValue, double? from, double? to, string sortBy, int page = 1)
        {
            //list product return list Products Entity
            //this line will be return empty list if not Contains searchValue
            //var listProducts = _context.Products.Where(pr => pr.NameProduct.Contains(searchValue));

            //Version 01    //Add more AsQueryable()
            //var listProducts = _context.Products.AsQueryable(); //Nếu không include thì sẽ không lấy được type từ bảng khác (Type == Null)

            //Version 02
            var listProducts = _context.Products.Include(hh => hh.Type).AsQueryable();

            //Thu tu: Filter -> Sort -> Paging
            #region Fitering
            if (!string.IsNullOrEmpty(searchValue))
            {
                listProducts = listProducts.Where(pr => pr.NameProduct.Contains(searchValue));
            }

            if (from.HasValue)
            {
                listProducts = listProducts.Where(hh => hh.Price >= from);
            }
            if (to.HasValue)
            {
                listProducts = listProducts.Where(hh => hh.Price <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name(ProductName)
            listProducts = listProducts.OrderBy(pr => pr.NameProduct);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "product_name_desc":
                        listProducts = listProducts.OrderByDescending(pr => pr.NameProduct);
                        break;
                    case "price_desc":
                        listProducts = listProducts.OrderByDescending(pr => pr.Price);
                        break;
                    case "price_asc":
                        listProducts = listProducts.OrderBy(pr => pr.Price);
                        break;
                }
            }
            #endregion

            //#region Pagin
            //listProducts = listProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            ////Convert list Products Entity to ProductViewModel to show for end user
            //var result = listProducts.Select(hh => new ProductModel
            //{
            //    ProductId = hh.Id,
            //    ProductName = hh.NameProduct,
            //    Description = hh.DescriptionProduct,
            //    Price = hh.Price,
            //    TypeName = hh.Type.TypeName,
            //    Discount = hh.Discount,
            //    TypeId = hh.TypeId
            //});
            //return result.ToList();

            var result = PaginatedList<Product>.Create(listProducts, page, PAGE_SIZE);
            return result.Select(pr => new ProductModel
            {
                ProductId = pr.Id,
                ProductName = pr.NameProduct,
                Description = pr.DescriptionProduct,
                Price = pr.Price,
                TypeName = pr.Type.TypeName,
                Discount = pr.Discount,
                TypeId = pr.TypeId
            }).ToList();
        }
    }
}
