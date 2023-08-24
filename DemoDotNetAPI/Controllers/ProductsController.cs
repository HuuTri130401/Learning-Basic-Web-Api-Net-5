using DemoDotNetAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoDotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll() //interface return ve cho cac action
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(string id)
        {
            try
            {
                //LINQ [Object] Query //truy vấn trên mảng objects , nếu có thì nó trả về đơn, ko thì default
                var product = products.SingleOrDefault(pr => pr.CodeProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();//404
                }
                return Ok(product); //Nếu đúng chuẩn GUID mà sai id thì ra 404 not found
            }
            catch
            {
                return BadRequest(); //Nếu ko đúng chuẩn GUID thì sẽ ra 400 bad request 
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateProductById(string id, ProductVM productVM) //put cho id nao, ton tai thi put cho object do
        //{
        //    try
        //    {
        //        var product = products.SingleOrDefault(pr => pr.CodeProduct == Guid.Parse(id));
        //        if(product != null)
        //        {
        //            product = new Product()
        //            {
        //                NameProduct = productVM.NameProduct,
        //                Price = productVM.Price,
        //            };
        //            return Ok(product);
        //        }
        //        return NotFound();

        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(string id, Product productEdit) //put cho id nao, ton tai thi put cho object do
        {
            try
            {
                var product = products.SingleOrDefault(pr => pr.CodeProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                if (id != product.CodeProduct.ToString())
                {
                    return BadRequest();
                }

                if (product != null)
                {
                    product.NameProduct = productEdit.NameProduct;
                    product.Price = productEdit.Price;
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product()
            {
                CodeProduct = Guid.NewGuid(),
                NameProduct = productVM.NameProduct,
                Price = productVM.Price,
            };
            products.Add(product);
            return Ok(new
            {
                Sucsess = true,
                Data = products
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                var product = products.SingleOrDefault(pr => pr.CodeProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                products.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
