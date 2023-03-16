using Azure.Core;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
    {
    [ApiController]
    [Route("/api/countries")]
    public class CountriesControler : ControllerBase
        {
        private readonly DataContext _contex;

        public CountriesControler(DataContext context)
            {
             _contex = context;
            }

        [HttpGet("{Idpais}")]
        public async Task<IActionResult> GetAsync(int Idpais) {

                return Ok( await _contex.Countries.FirstOrDefaultAsync(x => x.Id == Idpais) );

            }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
            {
                return Ok(await _contex.Countries.ToListAsync()); 
            }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country )
            {
                 _contex.Countries.Add(country);
                await _contex.SaveChangesAsync();   
                return Ok(country);
            }
        }
    }
