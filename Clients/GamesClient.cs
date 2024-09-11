using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> _games =
    [
        new()
        {
            Id = 1,
            Name = "Horizon Zero Dawn",
            Genre = "OpenWorldRPG",
            Price = 39.99M,
            ReleaseDate = new DateOnly(2018, 7, 15)
        },
        new()
        {
            Id = 2,
            Name = "TitanFall",
            Genre = "Action",
            Price = 20.99M,
            ReleaseDate = new DateOnly(2016, 1 , 1)
        },
        new()
        {
            Id = 3,
            Name = "Elden Ring",
            Genre = "OpenWorldRPG",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2021, 9 , 02)
        }

    ];

    //returning the converted List 
    private readonly Genre[] _genres = new GenresClient().GetGenres();
    public GameSummary[] GetGames() => [.._games];

    public void AddGame(GameDetails game) {
        Genre genre = GetGenreById(game.GenreId);
        var gameSummery = new GameSummary
        {
            Id = _games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        _games.Add(gameSummery);
    }


    public void UpdateGame(GameDetails updatedGame) {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id) {
        var game = GetGameSummaryById(id);
        _games.Remove(game);
    }

    public GameDetails GetGame(int gameId) {
        var game = GetGameSummaryById(gameId);
        //var genre  = _genres.Single(genre=> string.Equals(genre.Name, game.Genre,StringComparison.OrdinalIgnoreCase));
        var genre = _genres.Single(genre => string.Equals(genre.Name.Trim(), game.Genre.Trim(), StringComparison.OrdinalIgnoreCase));
        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    private GameSummary GetGameSummaryById(int gameId) {
        GameSummary? game = _games.Find(game => game.Id == gameId);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id) {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = _genres.Single(genre =>genre.Id == int.Parse(id));
        return genre;
    }
}