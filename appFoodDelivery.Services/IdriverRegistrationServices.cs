using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Services
{
 public  interface IdriverRegistrationServices
    {
        Task<int> CreateAsync(driverRegistration obj);
        // Task CreateAsync(driverRegistration obj);
        driverRegistration GetById(int id);
        Task UpdateAsync(driverRegistration obj);
        void Updatestatus(driverRegistration obj);
        Task Delete(int id);

        IEnumerable<driverRegistration> GetAll();
    }
}
