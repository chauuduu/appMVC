using AppCrud.Interface;
using AppCrud.Models;
using System.Collections.Generic;

namespace AppCrud.Service.ClotheService
{
    public class ClothesService : IClothesService
    {
        readonly IClothesRepository clothesRepository;
        public ClothesService(IClothesRepository _clothesRepository)
        {
            this.clothesRepository = _clothesRepository;
        }

        public string Add(Clothes Clothe)
        {
            var clothe = clothesRepository.GetById(Clothe.Id);
            if (clothe == null)
            {
                return clothesRepository.Add(Clothe);
            }
            else return "Failed";
        }

        public string Delete(int Id)
        {
            var clothe = clothesRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return clothesRepository.Delete(Id);
        }

        public Clothes GetById(int Id)
        {
            return clothesRepository.GetById(Id);
        }

        public List<Clothes> GetList()
        {
            return clothesRepository.GetList();
        }

        public List<Clothes> GetListLike(string Name)
        {
            return clothesRepository.GetListLike(Name);
        }

        public string Update(int Id, Clothes Clothe)
        {
            var clothe = clothesRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return clothesRepository.Update(Id, Clothe);
        }
    }
}