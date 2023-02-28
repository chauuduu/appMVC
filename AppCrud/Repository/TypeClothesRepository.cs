using AppCrud.Data;
using AppCrud.Interface;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCrud.Repository
{
    public class TypeClothesRepository : ITypeClothesRepository
    {
        public string Add(TypeClothes TypeClothes)
        {
            using (var db = new MyDbContext())
            {
                TypeClothes Type = new TypeClothes(TypeClothes.Name, TypeClothes.Limit);
                db.Add(Type);
                db.SaveChanges();
                return "Insert Success";
            }
        }

        public string Delete(int Id)
        {
            using (var db = new MyDbContext())
            {
                var Clothe = db.TypeClothes.Where(e => e.Id == Id).FirstOrDefault();
                if (Clothe == null) return "Delete failed";
                db.TypeClothes.Remove(Clothe);
                db.SaveChanges();
                return "Delete Success";
            }
        }

        public TypeClothes GetById(int Id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.TypeClothes.Include(e => e.Clothes).SingleOrDefault(e => e.Id == Id);
                return rs;
            }
        }

        public List<TypeClothes> GetList()
        {
            using (var db = new MyDbContext())
            {
                var rs = db.TypeClothes.Include(e => e.Clothes).ToList<TypeClothes>();
                return rs;
            }
        }

        public string Update(int Id, TypeClothes TypeClothes)
        {
            using (var db = new MyDbContext())
            {
                TypeClothes ClothesBefore = db.TypeClothes.SingleOrDefault(e => e.Id == Id);
                ClothesBefore.Update(TypeClothes.Name, TypeClothes.Limit);
                db.SaveChanges();
                return "Update Success";
            }
        }
    }
}

