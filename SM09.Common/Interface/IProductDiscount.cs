using SM09.Common.Entities;

namespace SM09.Common.Interface
{
    public interface IProductDiscount
    {
        decimal AfterDiscountPrice(Order order);
    }
}
