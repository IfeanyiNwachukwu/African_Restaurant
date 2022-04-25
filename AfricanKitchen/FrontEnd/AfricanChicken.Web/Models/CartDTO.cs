namespace AfricanKitchen.Web.Models
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; } // supplies information about the cart like
        //CartHeaderId
        //UserId
        //CouponCode
        public IEnumerable<CartDetailsDTO> CartDetails { get; set; } // supplies information about the product in the cart
        //CartDetailsId
        //CartHeaderId
        //ProductId
        //Count
    }
}
