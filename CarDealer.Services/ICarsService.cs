namespace CarDealer.Services
{
    public interface ICarsService
    {
        void AddCategory(string name);

        void AddColor(string name);

        void AddMake(string name);

        void AddFuelType(string name);

        void AddEuroStandart(string name);

        void AddGearbox(string name);
    }
}
