﻿using Microsoft.AspNetCore.Mvc;
using Services.ShoppingCartAPI.Contracts.IRepositoryManager.ShoppingCartRepositoryStore;
using Services.ShoppingCartAPI.DataTransferObjects.Readable;

namespace Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        protected ResponseDTO _response;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _response = new ResponseDTO();
        }
        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDTO cart = await _cartRepository.GetCartByUserId(userId);
                _response.Result = cart;
            }
            catch (Exception ex)
            {
               _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString()};
            }
            return _response;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDTO model)
        {
            try
            {
                CartDTO cart = await _cartRepository.CreateUpdateCart(model);
                _response.Result = cart;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("UpdateCart")]
        public async Task<object> UpdateCart(CartDTO model)
        {
            try
            {
                CartDTO cart = await _cartRepository.CreateUpdateCart(model);
                _response.Result = cart;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCart")]
        public async Task<object> RemoveCart([FromBody] int cartId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
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