using Core.Entities.Order;

namespace Core.Specifications
{
    public class OrderWithItemsAndOrderFilterSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsAndOrderFilterSpecification(string email) : base(o => o.CustomerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}");
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDesc(o => o.OrderDate);
        }

        public OrderWithItemsAndOrderFilterSpecification(int id, string email) : base(o => o.Id == id && o.CustomerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}");
            AddInclude(o => o.DeliveryMethod);
        }
    }
}
