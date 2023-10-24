﻿using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalCoursProgramme
    {
        List<CoursProgramme> GetCoursProgrammes();
        CoursProgramme GetCoursProgramme();
        int CreateCoursProgramme(CoursProgramme coursProgramme);
        void UpdateCoursProgramme(CoursProgramme coursProgramme);
        void DeleteCoursProgramme(int id);
    }
}
