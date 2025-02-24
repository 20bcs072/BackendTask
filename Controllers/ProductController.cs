using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApiProject.Data;
using product.Interface;
using product.Models;

public class ProductController :ControllerBase
    {
        private readonly IProduct _bankService;
 
    public ProductController(IProduct bankService)
    {
        _bankService = bankService;
    }
 
    // [HttpGet("products")]
    // // [Authorize]
    // public ActionResult<IEnumerable<Product>> GetUsers()
    // {
    //     var users = _bankService.GetProduct();
    //     return Ok(users);
    // }
     
   [HttpDelete("products/{id}")]
    public ActionResult DeleteProduct(int id)
    {
        try
        {
            _bankService.deleteproduct(id);
            return Ok("Product deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
     
 [HttpGet("products/{id}")]
    public async Task<ActionResult<Product>> GetUserById(int id)
    {
        try
        {
            var product = await _bankService.getUserById(id);
           return product;
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

      [HttpPost("products")]
    public IActionResult InsertProduct([FromBody] Product newProduct)
    {
        try
        {
            _bankService.InsertProduct(newProduct);
            return Ok(newProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

         [HttpPut("updateproduct/{Id}")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
               
                var updatedUser = await _bankService.UpdateProduct(product);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

     [HttpGet("pro")]
        public IActionResult GetProducts([FromQuery]int skip, [FromQuery] int take, [FromQuery] string? orderByColumn,[FromQuery] bool isAscending, [FromQuery] string? idFilter, [FromQuery] string? titleFilter, [FromQuery] string? priceFilter, [FromQuery] string? authorFilter, [FromQuery] string? editionFilter, [FromQuery] string? filterTerm)
        {
            try
            {
                var products = _bankService.GetProducts(skip, take, orderByColumn, isAscending, idFilter, titleFilter, priceFilter, authorFilter, editionFilter, filterTerm);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
         [HttpGet("count")]
        public ActionResult<IEnumerable<User>> GetCount()
        {
            var count=_bankService.GetCount();
            return Ok(count);
        }
        [HttpGet("drop")]

         public IEnumerable<string> DropdownTitle(int skip, int take)
         {
              var count=_bankService.DropdownTitle(skip,take);
            return count;
         }

         [HttpGet("Title")]
            public IEnumerable<string> DropdownTitle()
             {
              var count=_bankService.DropdownTitle();
            return count;
         }

         public class BookInputModel
        {
            public List<string> Titles { get; set; }
            public string AuthorName { get; set; }
        }

    //     [HttpGet("List")]
    //     public async Task<ActionResult<Product>> GetProducts()
    // {
    //     try
    //     {
    //         var product = await _bankService.GetProducts();
    //        return product;
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"Internal server error: {ex.Message}");
    //     }

    // }
      [HttpGet("details")]
        public ActionResult<IEnumerable<Product>> GetProductDetails()
        {
            var equipment = _bankService.GetProductDetails();
            return Ok(equipment);
        }

       [HttpGet("ReportDetails")]

       public ActionResult<IEnumerable<Report>> GetReportDetails()
    // public async Task<IActionResult> GetReportDetails()
       {
        var rep=_bankService.GetReportDetails();
        return Ok(rep);
       }

       [HttpPost("AddReport")]
    public IActionResult AddReport ([FromBody] Report newReport)
    {
        try
        {
            _bankService.InsertReport(newReport);
            return Ok(newReport);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
 
 
}