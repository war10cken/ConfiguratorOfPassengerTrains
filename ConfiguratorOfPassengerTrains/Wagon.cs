
namespace ConfiguratorOfPassengerTrains
{
    public class Wagon : Train
    {
        private int _wagonCapacity { get; }

        public Wagon(int wagonCapacity)
        {
            _wagonCapacity = wagonCapacity;
        }
    }
}