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
            return GetCoursProgrammes()
                .Where(c => c.DateDebut.CompareTo(DateTime.Now) > 0).ToList();
        }

        public List<CoursProgramme> GetCoursProgrammesAVenirCoach(int coachId)
        {
            DateTime jour = DateTime.Now;
            return this._bddContext.CoursProgrammes
                .Include(c => c.Cours)
                .ThenInclude(c => c.Coach)
                .Where(c => c.Cours.Coach.Id == coachId && c.DateDebut.CompareTo(jour) > 0)
                .ToList();
        }

        public List<CoursProgramme> GetCoursProgrammesAVenirCoach(string strCoachId)
        {
            if (int.TryParse(strCoachId, out int id))
            {
                return GetCoursProgrammesAVenirCoach(id);
            }
            return new List<CoursProgramme>();
        }

        public CoursProgramme GetCoursProgramme(int id)
        {
            return this._bddContext.CoursProgrammes
                .Include(c => c.Cours)
                .Include(c => c.Cours.Coach)
                .Include(c => c.Cours.Salle)
                .FirstOrDefault(c => c.Id == id);
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
