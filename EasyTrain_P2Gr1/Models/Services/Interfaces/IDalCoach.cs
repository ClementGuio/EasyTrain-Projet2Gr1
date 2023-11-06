using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalCoach : IDisposable
    {
        List<Coach> GetCoachs();
        Coach GetCoach(int Id);
        Coach GetCoach(string strId);
        int CreateCoach(Coach coach);
        void UpdateCoach(Coach coach);
        void DeleteCoach(int id);
    }
}
