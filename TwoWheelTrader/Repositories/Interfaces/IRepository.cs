namespace TwoWheelTrader.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Motorcycles { get; }

        void AddMotorcycle(T motorcycle);

        void TopThreeByProfit();

        void TopThreeROI();

        //void RemoveMotorcycle(string motorcycle); -- Not yet implemented, signature unknown, probably an ID

        //void MotorcycleExists(T motorcycle); -- Not sure if this will be needed for the scope of the program, will just add it for now
    }
}
