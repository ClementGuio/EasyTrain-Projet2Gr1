using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalCours
    {
        List<Cours> GetCours();
        Cours GetCours(int id);
        int CreateCours(Cours cours);
        void UpdateCours(Cours cours);
        void DeleteCours(int id);
    }
}
