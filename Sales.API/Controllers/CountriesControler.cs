using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country )
            {
                 _contex.Countries.Add(country);
                await _contex.SaveChangesAsync();   
                return Ok(country);
            }
        }
    }
