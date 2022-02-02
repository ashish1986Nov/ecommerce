
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastucture.Data;
using Core.Entity;
using Core.Interfaces;

namespace webapi1.Controller;



[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private IProductRepository _iProductRepository;

    public ProductController(IProductRepository iproductRepository)
    {
        _iProductRepository = iproductRepository;


    }

    [HttpGet]
    public async Task < ActionResult <List<Product>>> GetAllProducts()
    {
        var listOfProduct = await _iProductRepository.GetProductListAsync();   
        return Ok(listOfProduct);

    }


    [HttpGet("brand")]

    public async Task<ActionResult<List<ProductType>>> GetAllProductType()
    {
        var listOfProduct = await _iProductRepository.GetProductTypeAsync();
        return Ok(listOfProduct);

    }

    [HttpGet("type")]
    public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrand()
    {
        var listOfProduct = await _iProductRepository.GetProductBrandAsync();
        return Ok(listOfProduct);

    }


    [HttpGet("{id}")]
  
    public async Task < ActionResult<Product>> GetProduct(int id)
    {

        var product = await _iProductRepository.GetProductAsync(id);
        return Ok(product); 
    
    
    }

    

}