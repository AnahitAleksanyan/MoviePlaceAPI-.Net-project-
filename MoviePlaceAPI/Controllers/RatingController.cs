using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using MoviePlaceAPI.Models;

namespace MoviePlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public string GetRatings()
        {
            
            return JsonSerializer.Serialize(Enum.GetNames(typeof(Rating)));
        }
    }
}

