using System;
using Microsoft.AspNetCore.Mvc;
using Products.API.Models;
using Products.Data;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get(
            [FromServices] AppDbContext context) => Ok(context.Products!.ToList());

        [HttpPost("/")]
        public IActionResult Post([FromBody] ProductModel productModel,
            [FromServices] AppDbContext context)
        {
            context.Products!.Add(productModel);
            context.SaveChanges();
            return Created($"/{productModel.Id}", productModel);
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var productModel = context.Products!.FirstOrDefault(x => x.Id == id);
            if(productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel);
        }

        [HttpPut("/")]
        public IActionResult Put([FromRoute] int id,
            [FromBody] ProductModel productModel,
            [FromServices] AppDbContext context)
        {
            var model = context.Products!.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }

            model.Name = productModel.Name;
            model.Price = productModel.Price;
            model.Amount = productModel.Amount;

            context.Products!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/")]
        public IActionResult Delete([FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Products!.FirstOrDefault(x => x.Id == id);

            if(model == null)
            {
                return NotFound();
            }

            context.Products!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }

    }
}