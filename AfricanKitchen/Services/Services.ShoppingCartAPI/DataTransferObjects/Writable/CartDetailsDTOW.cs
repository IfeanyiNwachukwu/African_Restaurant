using Services.ShoppingCartAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.ShoppingCartAPI.DataTransferObjects.Writable
{
    public class CartDetailsDTOW
    {
        //public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }

        //[ForeignKey("CartHeaderId")]
        //public virtual CartHeader CartHeader { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
    }
}
