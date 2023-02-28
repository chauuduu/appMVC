using AppCrud.Interface;
using AppCrud.Models;
using System.Collections.Generic;

namespace AppCrud.Service.TypeClotheService
{
    public class TypeClothesService : ITypeClothesService
    {
        readonly ITypeClothesRepository typeClothesRepository;
        public TypeClothesService(ITypeClothesRepository _typeClothesRepository)
        {
            this.typeClothesRepository = _typeClothesRepository;
        }
        public string Add(TypeClothes TypeClothes)
        {
            var clothe = typeClothesRepository.GetById(TypeClothes.Id);
            if (clothe == null)
            {
                return typeClothesRepository.Add(TypeClothes);
            }
            return "Failed";
        }

        public string Delete(int Id)
        {
            var clothe = typeClothesRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return typeClothesRepository.Delete(Id);
        }

        public TypeClothes GetById(int Id)
        {
            return typeClothesRepository.GetById(Id);
        }

        public List<TypeClothes> GetList()
        {
            return typeClothesRepository.GetList();
        }

        public string Update(int Id, TypeClothes TypeClothes)
        {
            var clothe = typeClothesRepository.GetById(Id);
            if (clothe == null)
            {
                return "Failed";
            }
            return typeClothesRepository.Update(Id, TypeClothes);
        }
    }
}

