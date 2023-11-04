using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class DashboardGestionnaireViewModel
    {
        public List<Coach> Coaches { get; set; }
        public List<Cours> Courses { get; set; }
        public List<Salle> Salles { get; set; }
        public List<Coach> Coachs { get; internal set; }
        public List<Equipement> Equipements { get; internal set; }
        public List<Client> Clients { get; set; }

       




        public List<EquipementInfo> GetEquipementInfo()
        {

            List<EquipementInfo> equipementInfoList = new List<EquipementInfo>();

            // Parcoure la liste des équipements et compte le nombre d'instances de chaque équipement
            var equipementCount = Equipements
                .GroupBy(e => e.Nom)
                .Select(g => new { Nom = g.Key, Count = g.Count() });

            // Ajoute les informations à la liste d'informations sur les équipements
            foreach (var equipement in equipementCount)
            {
                equipementInfoList.Add(new EquipementInfo
                {
                    NomEquipement = equipement.Nom,
                    NombreInstances = equipement.Count
                });
            }

            return equipementInfoList;
        }
    }

    public class EquipementInfo
    {
        public string NomEquipement { get; set; }
        public int NombreInstances { get; set; }
    }

  
}
