using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ODataController : ControllerBase
    {


        /// <summary>
        /// Odata working example
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(ODataQueryOptions<Peopel> query)
        {
            var result = new List<Peopel>()
            {
                new Peopel(1,"test1"),
                new Peopel(2,"test2"),
                new Peopel(3,"test3"),
                new Peopel(4,"test4"),
                new Peopel(5,"test5"),
                new Peopel(6,"test6"),
            };

            var test = (IQueryable<Peopel>)query.ApplyTo(result.AsQueryable());

            return Ok(test);
        }

    }
}

public class Peopel
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public Peopel(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}