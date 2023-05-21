

namespace Ex03.GarageLogic
{
    public enum eVechilesTypes
    {
        Car, Motorcycle, Truck
    }

    public enum eEngineTypes
    {
        Fuel, Electric

    }

    class VechileCreator
    {
        public static Vechile GetVechileByType(eVechilesTypes i_VechileType, string i_LicenseNumber)
        {
            Vechile vechile = null;
            switch (i_VechileType)
            {
                case eVechilesTypes.Car:
                    vechile = new Car();
                    break;
                case eVechilesTypes.Motorcycle:
                    vechile = new Motorcycle();
                    break;
                case eVechilesTypes.Truck:
                    vechile = new Truck();
                    break;
            }

            vechile.LicensePlateNumber = i_LicenseNumber;
            return vechile;
        }

        public static void createNewEngine(Vechile i_Vechile, eEngineTypes i_EngineTypes)
        {
            if(i_EngineTypes == eEngineTypes.Fuel)
            {
                i_Vechile.Engine = new Fuel();
            }
            else
            {
                i_Vechile.Engine = new Electric();
            }
            
        }
    }
}
