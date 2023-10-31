﻿using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.Models.Services.Interfaces
{
    public interface IDalCoursProgramme:IDisposable
    {
        List<CoursProgramme> GetCoursProgrammes();
        public List<CoursProgramme> GetCoursProgrammesAVenir();
        CoursProgramme GetCoursProgramme(int id);
        CoursProgramme GetCoursProgramme(string strId);
        int CreateCoursProgramme(CoursProgramme coursProgramme);
        void UpdateCoursProgramme(CoursProgramme coursProgramme);
        void DeleteCoursProgramme(int id);
    }
}
