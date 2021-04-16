using Fidelity.Models;

namespace Fidelity.Services
{
    public interface ICardStore
    {
        Carte[] LoadCartes();

        void SaveCartes(Carte[] lst);
    }
}
