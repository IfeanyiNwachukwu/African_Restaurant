namespace Services.ShoppingCartAPI.DataTransferObjects.Readable
{
    public class CouponDTO
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}
