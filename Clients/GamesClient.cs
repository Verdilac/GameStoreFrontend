using GameStore.Frontend.Models;
namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpclient)
{
    public async Task<GameSummary[]> GetGamesAsync() => 
            await httpclient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task<GameDetails> GetGameAsync(int gameId) =>
        await httpclient.GetFromJsonAsync<GameDetails>($"games/{gameId}")
        ?? throw new Exception($"Could Not Find Game for Id {gameId}");
    
    public async Task AddGameAsync(GameDetails game) =>
        await httpclient.PostAsJsonAsync("games", game);


    public async Task UpdateGameAsync(GameDetails updatedGame) =>
        await httpclient.PutAsJsonAsync($"games/{updatedGame.Id}",updatedGame);

    public async Task DeleteGameAsync(int id) =>
        await httpclient.DeleteAsync($"games/{id}");
    
}