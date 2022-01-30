
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastucture.Data;
using Core.Entity;

namespace webapi1.Controller;



[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private StoreContext _storeContext;

    public ProductController(StoreContext storecontext)
    {
        _storeContext = storecontext;


    }

    [HttpGet]
    public async Task < ActionResult <List<Product>>> GetAllProducts()
    {
        var listOfProduct =  await _storeContext.Products.ToListAsync();
        
        return Ok(listOfProduct);

    }


    [HttpGet("{id}")]
  
    public async Task < ActionResult<Product>> GetProduct(int id)
    {

        var product = await _storeContext.Products.FindAsync(id);
         return Ok(product); 
    
    
    }

    

}