using EasyTrain_P2Gr1.Models;
using EasyTrain_P2Gr1.Models.Constantes;
using System.Security.Permissions;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class AbonnementViewModel
    {
        public Abonnement Abonnement { get; set; }

        public double TarifBase = TarifsAbonnement.TarifBase;
        public double TarifCours = TarifsAbonnement.TarifCours;
        public double TarifPiscine = TarifsAbonnement.TarifPiscine;
        public double TarifEscalade = TarifsAbonnement.TarifEscalade;
        public double TarifCoaching = TarifsAbonnement.TarifCoaching;
    }
}
