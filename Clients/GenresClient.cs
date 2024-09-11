using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;


public class GenresClient
{
   private readonly Genre[] _genres =
   [
      new()
      {
         Id = 1,
         Name = "Fantasy"
      },
      new()
      {
         Id = 2,
         Name = "Action"
      },
      new()
      {
         Id = 3,
         Name = "OpenWorldRPG"
      },
      new()
      {
         Id = 4,
         Name = "Building"
      }
   ];
   
   public Genre[] GetGenres() => _genres;
}