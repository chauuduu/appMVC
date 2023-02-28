using AppCrud.Models;
using System.Collections.Generic;

namespace AppCrud.Interface
{
    public interface IClothesRepository
    {
        List<Clothes> GetList();
        List<Clothes> GetListLike(string Name);
        Clothes GetById(int Id);

        string Add(Clothes Clothe);
        string Update(int Id, Clothes Clothe);
        string Delete(int Id);
    }
}
