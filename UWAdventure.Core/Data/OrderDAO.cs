namespace UWAdventure.Data
{
    /// <summary>
    /// Data access object for orders 
    /// </summary>
    public class OrderDAO : IOrderDAO
    {
        private readonly IDbUWAdventure _dbObj;

        public OrderDAO(IDbUWAdventure dbObj)
        {
            _dbObj = dbObj;
        }


    }
}
