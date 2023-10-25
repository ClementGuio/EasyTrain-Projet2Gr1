using System.Collections.Generic;
using System;

namespace EasyTrain_P2Gr1.Models.DAL.Interfaces
{
    public interface IDalCoach : IDisposable
    {
        List<Coach> GetCoachs();
        public Coach GetCoach(int Id);
        public int CreerCoach(Coach coach);
        public void UpdateCoach(Coach coach);
        public void DeleteCoach(int id);
    }
}
