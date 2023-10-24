using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalEquipement
    {
        List<Equipement> GetEquipements();
        Equipement GetEquipement();
        int CreateEquipement(Equipement equipement);
        void UpdateEquipement(Equipement equipement);
        void DeleteEquipement(int id);

    }
}
