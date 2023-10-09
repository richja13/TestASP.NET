using TestWebApp.Models;
using TestWebApp.Services.Interfaces;

namespace TestWebApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        public int Save(Product product)
        {
            // logika zapisujaca do bazy
            return 1;
        }
    }
}
