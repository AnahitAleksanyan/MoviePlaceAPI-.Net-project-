using MovieAPIAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Utils
{
    public class ActorConverter
    {
        public static ActorForJson ConvertActorToJsonActor(Actor actor)
        {
            ActorForJson actorForJson = new ActorForJson(
                id:actor.Id,
                name: actor.Name,
                surname: actor.Surname,
                country: actor.Country,
                countryId: actor.CountryId,
                movieActorCasts: actor.MovieActorCasts,
                dateOfBirth: actor.DateOfBirth.ToString()
                ); 
            return actorForJson;
        }

        public static Actor ConvertJsonActorToActor(ActorForJson actorForJson)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParse(actorForJson.DateOfBirth, out dateTime);
            Actor actor = new Actor(
                name: actorForJson.Name,
                surname:actorForJson.Surname,
                id:actorForJson.Id,
                country:actorForJson.Country,
                countryId:actorForJson.CountryId,
                movieActorCasts:actorForJson.MovieActorCasts,
                dateOfBirth: dateTime
                );
            return actor;
        }
    }
}
