using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.ProductAPI.Contracts.IRepositoryManager;
using Services.ProductAPI.DataTransferObjects.Readable;
using Services.ProductAPI.DataTransferObjects.Writable;
using Services.ProductAPI.Helpers;
using Services.ProductAPI.Models;

namespace Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IRepositoryManager _repository;
        private IMapper _mapper;

        public ProductAPIController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            this._response = new ResponseDTO();
        }

        
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await _repository.Product.GetProducts();
                var productsToreturn = _mapper.Map<List<ProductDTO>>(products);
                _response.Result = productsToreturn;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var product = await _repository.Product.GetProductById(id);
                var productsToreturn = _mapper.Map<ProductDTO>(product);
                _response.Result = productsToreturn;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDTO model)
        {
            try
            {
                var productToCreate = _mapper.Map<Product>(model);
                _repository.Product.CreateUpdateProduct(productToCreate);
                await _repository.SaveAsync();
                var productsToreturn = _mapper.Map<ProductDTO>(productToCreate);
                _response.Result = productsToreturn;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDTO model)
        {
            try
            {
                var productToCreate = _mapper.Map<Product>(model);
                _repository.Product.CreateUpdateProduct(productToCreate);
                await _repository.SaveAsync();
                var productsToreturn = _mapper.Map<ProductDTO>(productToCreate);
                _response.Result = productsToreturn;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

       
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int Id)
        {
            try
            {
                bool isSuccess = await _repository.Product.DeleteProduct(Id);
                await _repository.SaveAsync();
                _response.Result = isSuccess;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }
    }
}
