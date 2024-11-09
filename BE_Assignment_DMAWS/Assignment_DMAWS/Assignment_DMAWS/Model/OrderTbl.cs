using System.ComponentModel.DataAnnotations;

namespace Assignment_DMAWS.Model
{
    public class OrderTbl
    {
        [Key]
        public int ItemCode { get; set; }
        [StringLength(250)]
        public string? ItemName { get; set; }
        public int ItemQty { get; set; }
        public DateTime OrderDelivery { get; set; }
        [StringLength(200)]
        public string? OrderAddress { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
    }

    public class OrderTblUpdateModel
    {
        public DateTime OrderDelivery { get; set; }
        public string? OrderAddress { get; set; }
    }
}
