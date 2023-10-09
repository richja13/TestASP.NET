using TestWebApp.Models;

namespace TestWebApp.Services.Interfaces
{
    public interface IWarehouseService
    {
        int Save(Product product);
        List<Product> GetAll();
        Product Get(int id);
        int Delete(int id);
    }
}
