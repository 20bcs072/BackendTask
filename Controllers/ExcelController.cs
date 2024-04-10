using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using MyWebApiProject.Data;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using product.Models;
using OfficeOpenXml.Style;
using OfficeOpenXml.DataValidation;

[ApiController]
[Route("api/[controller]")]
public class ExcelController : Controller
{
    private readonly AppDbContext _context;

    public ExcelController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult ExportToExcel()
    {
        var products = _context.Products.ToList();
        var reports = _context.Report.ToList();
        var productsToPrint = new List<Product>();

        foreach (var report in reports)
        {
            var fromDate = report.fromDate;
            var toDate = report.toDate;

            foreach (var product in products)
            {
                var publishedDate = product.PublishedDate;

                if (publishedDate >= fromDate && publishedDate <= toDate)
                {
                    productsToPrint.Add(product);
                }
            }
        }

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Products");

            // Header row
            worksheet.Cells[1, 1].Value = "Title";
            worksheet.Cells[1, 2].Value = "Price";
            worksheet.Cells[1, 3].Value = "Author";
            worksheet.Cells[1, 4].Value = "Edition";
            worksheet.Cells[1, 5].Value = "Published Date";
            worksheet.Cells[1, 6].Value = "Report Status";

            // Data rows
            int row = 2;
            foreach (var product in productsToPrint)
            {
                foreach (var report in reports)
                {
                    var fromDate = report.fromDate;
                    var toDate = report.toDate;
                    var publishedDate = product.PublishedDate;

                    if (publishedDate >= fromDate && publishedDate <= toDate)
                    {
                        worksheet.Cells[row, 1].Value = product.Title;
                        worksheet.Cells[row, 2].Value = product.Price;
                        worksheet.Cells[row, 3].Value = product.Author;
                        worksheet.Cells[row, 4].Value = product.Edition;
                        worksheet.Cells[row, 5].Value = product.PublishedDate;
                        worksheet.Cells[row, 6].Value = report.ReportStatus;

                        row++;
                    }
                }
            }

            // Save the Excel file
            // byte[] excelData = package.GetAsByteArray();
            // string fileName = "products.xlsx";
            // return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

        string fileName = "reports_data.xlsx";
        string folderPath = @"D:\Excel";
        string filePath = Path.Combine(folderPath, fileName);

       FileInfo excelFile = new FileInfo(filePath);
        package.SaveAs(excelFile);

        return File(excelFile.OpenRead(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
