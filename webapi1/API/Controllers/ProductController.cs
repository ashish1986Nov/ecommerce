
using AutoMapper;
using Core.Entity;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using webapi1.API.Controllers;
using webapi1.API.DTO;
using webapi1.API.Errors;
using webapi1.API.Helpers;

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
    public async Task < ActionResult <Pageinitation<ProductDto>>> GetAllProducts
        (  [FromQuery] ProductSpecsParams specsParams )
    {

        var specs = new ProductWithTypesAndBrandSpecefications(specsParams);

        var countSpecs = new ProductWithCountSpecefication(specsParams);

        var totalItems = await IGenericProductRepository.CountAsync(countSpecs);


        var listOfProduct = await IGenericProductRepository.ListAsync(specs);


        var data = IMapperMap.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(listOfProduct);

        return Ok(new Pageinitation<ProductDto>(specsParams.PageIndex
            , specsParams.PageSize, totalItems,data)
            );

    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse),  StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var specs = new ProductWithTypesAndBrandSpecefications(id);



        var product = await IGenericProductRepository.GetEntityWithSpec(specs);

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