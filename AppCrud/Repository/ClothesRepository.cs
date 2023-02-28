using AppCrud.Data;
using AppCrud.Interface;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCrud.Repository
{
    public class ClothesRepository : IClothesRepository
    {
        public string Add(Clothes Clothe)
        {
            using (var db = new MyDbContext())
            {
                Clothes Clo = new Clothes(Clothe.Name, Clothe.Description, Clothe.Size, Clothe.Price, Clothe.RentalPrice, Clothe.TypeClothesId, Clothe.Status);
                db.Add(Clothe);
                db.SaveChanges();
                return "Insert Success";
            }
        }

        public string Delete(int Id)
        {
            using (var db = new MyDbContext())
            {
                var Clothe = db.Clothes.Where(e => e.Id == Id).FirstOrDefault();
                if (Clothe == null) return "Delete failed";
                db.Clothes.Remove(Clothe);
                db.SaveChanges();
                return "Delete Success";
            }
        }

        public Clothes GetById(int Id)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Clothes.Include(e => e.TypeClothes).SingleOrDefault(e => e.Id == Id);
                return rs;
            }
        }

        public List<Clothes> GetList()
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Clothes.Include(e => e.TypeClothes).ToList();
                return rs;
            }
        }

        public List<Clothes> GetListLike(string Name)
        {
            using (var db = new MyDbContext())
            {
                var rs = db.Clothes.Where(e => e.Name.Contains(Name)).Include(e => e.TypeClothes).ToList();
                return rs;
            }
        }

        public string Update(int Id, Clothes Clothe)
        {
            using (var db = new MyDbContext())
            {
                Clothes ClothesBefore = db.Clothes.SingleOrDefault(e => e.Id == Id);
                if (ClothesBefore.Status == Status.Available && Clothe.Status == Status.Rental)
                    ClothesBefore.ChangeRentalTime();
                ClothesBefore.Update(Clothe.Name, Clothe.Description, Clothe.Size, Clothe.Price, Clothe.RentalPrice, Clothe.TypeClothesId, Clothe.Status);
                db.SaveChanges();
                return "Update Success";
            }
        }
    }
}