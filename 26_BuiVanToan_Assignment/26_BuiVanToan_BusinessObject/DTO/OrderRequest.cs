namespace _26_BuiVanToan_BusinessObject.DTO
{
    public class OrderRequest
    {
        public string Freight { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
