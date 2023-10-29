using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class FormulaireAbonnementsViewModel
    {
        public Abonnement Abonnement { get; set; }
        public int SalleId { get; set; }
        public int CoachId { get; set; }
    }
}
