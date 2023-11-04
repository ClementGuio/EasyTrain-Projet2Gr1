using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalEquipement: IDisposable
    {
        List<Equipement> GetEquipements();
        Equipement GetEquipement(int id);
        int CreateEquipement(Equipement equipement);
        void UpdateEquipement(Equipement equipement);
        void DeleteEquipement(int id);
    }
}
