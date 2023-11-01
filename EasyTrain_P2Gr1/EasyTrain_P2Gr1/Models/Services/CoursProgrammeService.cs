using EasyTrain_P2Gr1.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTrain_P2Gr1.Models.Services
{
    public class CoursProgrammeService : DisposableService, IDalCoursProgramme
    {
        public List<CoursProgramme> GetCoursProgrammes()
        {
         return this._bddContext.CoursProgrammes
                .Include(c => c.Cours)
                .Include(c => c.Cours.Coach)
                .Include(c => c.Cours.Salle)
                .OrderBy(c => c.DateDebut).ToList(); 
        }

        public List<CoursProgramme> GetCoursProgrammesAVenir()
        {
            return GetCoursProgrammes().Where(c => c.DateDebut.CompareTo(DateTime.Now) > 0).ToList();
        }



        public CoursProgramme GetCoursProgramme(int id)
        {
            return this._bddContext.CoursProgrammes.Include(c => c.Cours).FirstOrDefault(c => c.Id == id);
        }

        public CoursProgramme GetCoursProgramme(string strId)
        {
            int id;
            if (int.TryParse(strId, out id))
            {
                return GetCoursProgramme(id);
            }
            return null;
        }

        public int CreateCoursProgramme(CoursProgramme coursProgramme)
        {
            this._bddContext.Attach(coursProgramme.Cours);
            this._bddContext.CoursProgrammes.Add(coursProgramme);
            this._bddContext.SaveChanges();
            return coursProgramme.Id;
        }

        public void UpdateCoursProgramme(CoursProgramme coursProgramme)
        {
            _bddContext.CoursProgrammes.Update(coursProgramme);
            _bddContext.SaveChanges();
        }

        public void DeleteCoursProgramme(int id) 
        {
            CoursProgramme coursProgramme = this._bddContext.CoursProgrammes.Find(id);
            List<Reservation> reservations = _bddContext.Reservations.Where(r => r.CoursProgramme.Id == coursProgramme.Id).ToList();
            if (coursProgramme != null)
            {
                if (reservations.Count > 0)
                {
                    _bddContext.Reservations.RemoveRange(reservations);
                }
                _bddContext.CoursProgrammes.Remove(coursProgramme);
                _bddContext.SaveChanges();
            }
        }
    }
}
