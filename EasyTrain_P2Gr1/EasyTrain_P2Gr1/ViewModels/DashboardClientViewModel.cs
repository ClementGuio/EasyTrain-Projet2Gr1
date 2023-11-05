using EasyTrain_P2Gr1.Models;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class DashboardClientViewModel
    {
        public List<Cours> Cours { get; set; }
        public List<Salle> Salles { get; set; }
        public List<Coach> Coachs { get; internal set; }
        public List<Equipement> Equipements { get; internal set; }
    }
}
