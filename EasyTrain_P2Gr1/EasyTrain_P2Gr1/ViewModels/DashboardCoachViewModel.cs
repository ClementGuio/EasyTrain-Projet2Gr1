using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class DashboardCoachViewModel
    {
        public List<Coach> Coaches { get; set; }
        public List<Cours> Courses { get; set; }
        public List<Client> Clients { get; set; }
        //public List<Equipement> listeEquipements { get; set; }
        public List<Salle> Salles { get; set; }
        public List<Equipement> Equipements { get; internal set; }
        public List<CoursProgramme> CoursProg { get; internal set; }
        public List<Coach> Coachs { get; internal set; }
    }
      
}
