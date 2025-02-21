namespace ServiceCenter.Domain.Enums
{
    /// <summary>
    /// Represents the status of an order.
    /// </summary>
    /// <remarks>
    /// Possible values include Pending, Shipped, and Completed.
    /// </remarks>
    public enum OrderStatus
    {
        Pending = 0,   
        Shipped = 1,     
        Completed = 2    
    }
}
