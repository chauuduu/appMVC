using AppCrud.Models;
using AppCrud.Service.ClotheService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace AppCrud.ApiController
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClothesController : ControllerBase
    {
        readonly IClothesService ClothesService;
        public ClothesController(IClothesService ClothesService)
        {
            this.ClothesService = ClothesService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ClothesService.GetList());
        }
        [HttpGet("Name")]
        public IActionResult GetLike(String Name)
        {
            return Ok(ClothesService.GetListLike(Name));
        }
        [HttpGet("Id")]
        public IActionResult GetById(int Id)
        {
            return Ok(ClothesService.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Clothes ClothesEx)
        {
            return Ok(ClothesService.Add(ClothesEx));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id, Clothes ClothesEx)
        {
            return Ok(ClothesService.Update(Id, ClothesEx));
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(ClothesService.Delete(Id));
        }
    }
}
