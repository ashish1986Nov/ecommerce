
using AutoMapper;
using Core.Entity;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using webapi1.API.Controllers;
using webapi1.API.DTO;
using webapi1.API.Errors;

namespace webapi1.API.Controller;




public class ProductController : BaseApiController
{
    public IGenericRepository<Product> IGenericProductRepository { get; }
    public IGenericRepository<ProductType> IGenericProductTypeRepository { get; }
    public IGenericRepository<ProductBrand> IGenericProductBrandRepository { get; }
    public IMapper IMapperMap { get; }

    public ProductController(IGenericRepository<Product> iGenericProductRepository,
        IGenericRepository<ProductType> iGenericProductTypeRepository,
        IGenericRepository<ProductBrand> iGenericProductBrandRepository,
        IMapper iMapperMap)
    {
        IGenericProductRepository = iGenericProductRepository;
        IGenericProductTypeRepository = iGenericProductTypeRepository;
        IGenericProductBrandRepository = iGenericProductBrandRepository;
        IMapperMap = iMapperMap;

    }

    [HttpGet]
    public async Task < ActionResult <IReadOnlyList<ProductDto>>> GetAllProducts()
    {
        var listOfProduct = await IGenericProductRepository.ListAllAsync();

        //var prodDtoList = DtoConverter.DobConvertedProdList(listOfProduct);


        return Ok(IMapperMap.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(listOfProduct));

    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse),  StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await IGenericProductRepository.GetByIdAsync(id);

        if (product == null)
        {

            return NotFound(new ApiResponse(404));
        
        }

      //  var prodDto = DtoConverter.DtoCoverterUtilProduct(product);

        return Ok(IMapperMap.Map<Product,ProductDto>(product));
    }




    [HttpGet("brand")]

    public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrands()
    {
        var listOfProduct = await IGenericProductBrandRepository.ListAllAsync();
        return Ok(listOfProduct);

    }

    [HttpGet("type")]

    public async Task<ActionResult<List<ProductBrand>>> GetAllProductTypes()
    {
        var listOfProduct = await IGenericProductTypeRepository.ListAllAsync();

        return Ok(listOfProduct);

    }


    

}