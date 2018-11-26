using Microsoft.Extensions.Configuration;

namespace UWAdventure.Data
{
    public interface IDbUWAdventure
    {
        string GetConnectionString(string name);
    }
}
