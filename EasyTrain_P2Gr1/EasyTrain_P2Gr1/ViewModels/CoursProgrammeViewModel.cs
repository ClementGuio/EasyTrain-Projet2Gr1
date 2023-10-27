using EasyTrain_P2Gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class CoursProgrammeViewModel
    {
        public CoursProgramme CoursProgramme { get; set; }
        public int CoursId { get; set; }

        public List<SelectListItem> Cours { get; set; }
    }
}
