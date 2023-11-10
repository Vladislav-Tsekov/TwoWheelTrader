namespace VehEvalu8.Routes
{
    public class Route
    {
        public string? TownName { get; set; }

        public int DistanceToTown { get; set; }

        public static int FuelConsumption() 
        {
            return 1;
        }
    }
}
