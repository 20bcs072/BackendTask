using Microsoft.AspNetCore.Mvc;
using MyWebApiProject.Data;
using product.Models;
using static ProductController;

namespace product.Interface
{
    public interface IProduct
   {
        IEnumerable<Product> GetProduct ();

      public ActionResult<IEnumerable<Product>> GetProductDetails();
  

        public void deleteproduct(int Id);

        public Task<Product> getUserById(int id);  

          // public void InsertProduct(Product newProduct);


    public IActionResult AddReport ([FromBody] Report newReport);
    

            public Task<Product> UpdateProduct(Product product);

               public IEnumerable<Product> GetProducts(int skip, int take, string orderByColumn, bool isAscending, string idFilter, string titleFilter, string priceFilter, string authorFilter, string editionFilter, string filterTerm);

               public int GetCount();

                public IEnumerable<string> DropdownTitle(int skip, int take);

                 public IEnumerable<string> DropdownTitle();

                  public void InsertAuthor(BookInputModel bk);

                   public ActionResult<IEnumerable<Report>> GetReportDetails();
        void InsertProduct(Report newReport);
        void InsertReport(Report newReport);
        void InsertProduct(Product newProduct);
    }
           
}