using location_voiture.Models;
using System.Collections.Generic;
namespace location_voiture.Repositories
{
    public interface ICategoryVoitureRepository
    {
        IEnumerable<CategoryVoiture> GetAll();
        CategoryVoiture? GetById(int id);
        void Add(CategoryVoiture category);
        void Update(CategoryVoiture category);
        void Delete(int id);
        bool Exists(int id);
    }
}
