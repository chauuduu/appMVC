﻿using AppCrud.Models;
using AppCrud.Service.TypeClotheService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppCrud.ApiController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeClothesController : ControllerBase
    {
        readonly ITypeClothesService TypeClothesService;
        public TypeClothesController(ITypeClothesService TypeClothesService)
        {
            this.TypeClothesService = TypeClothesService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TypeClothesService.GetList());
        }
        [HttpGet("Id")]
        public IActionResult GetById(int Id)
        {
            return Ok(TypeClothesService.GetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Insert(TypeClothes TypeClothesEx)
        {
            return Ok(TypeClothesService.Add(TypeClothesEx));
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id, TypeClothes TypeClothesEx)
        {
            return Ok(TypeClothesService.Update(Id, TypeClothesEx));
        }
        [HttpDelete("ID")]
        public IActionResult Delete(int ID)
        {
            return Ok(TypeClothesService.Delete(ID));
        }
    }
}
