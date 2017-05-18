using System.Collections.Generic;

namespace WorkshopXMLToJSON.Contract
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();

        void Save(IEnumerable<Car> cars);
    }
}
