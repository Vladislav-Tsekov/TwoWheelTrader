namespace TwoWheelTrader.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Motorcycles { get; } // Read-only collection that will store all motorcycles of a given category

        void AddMotorcycle(T motorcycle); // Adds a given motorcycle to the collection

        void TopThreeByProfit(IRepository<T> motorcycles); 
        // Returns the three highest ranked motorcycles, sorted by profit in a descending order

        void TopThreeROI(IRepository<T> motorcycles); 
        // Returns the three highest ranked motorcycles, sorted by Profit % Price

        //void RemoveMotorcycle(string motorcycle); -- Not yet implemented, signature unknown, probably an ID

        //void MotorcycleExists(T motorcycle); -- Not sure if this will be needed for the scope of the program, will just add it for now
    }
}
