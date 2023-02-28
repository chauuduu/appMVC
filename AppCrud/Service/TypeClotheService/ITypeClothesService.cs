using AppCrud.Models;
using System.Collections.Generic;
using System;

namespace AppCrud.Service.TypeClotheService
{
    public interface ITypeClothesService
    {
        List<TypeClothes> GetList();
        TypeClothes GetById(int Id);

        String Add(TypeClothes TypeClothes);
        String Update(int Id, TypeClothes TypeClothes);
        String Delete(int Id);
    }
}