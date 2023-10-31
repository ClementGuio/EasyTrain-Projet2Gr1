using EasyTrain_P2Gr1.Models;
using System;
using System.Collections.Generic;

namespace EasyTrain_P2Gr1.ViewModels
{
    public class CalendrierViewModel
    {
        public int NbJoursAffiches { get; set; }
        public List<PlanningJour> PlanningJours { get; set; }

        public class PlanningJour
        {
            public DateTime Date { get; set; }
            public List<CoursProgramme> CoursProgrammes { get; set; }

        }

        public CalendrierViewModel(List<CoursProgramme> coursProgrammes, int nbJoursAffiches)
        {
            this.NbJoursAffiches = nbJoursAffiches;
            this.PlanningJours = new List<PlanningJour>();

            //Algo de création du calendrier
            DateTime prochaineDate = coursProgrammes[0].DateDebut;
            DateTime dateCourante = new DateTime(prochaineDate.Year, prochaineDate.Month, prochaineDate.Day);       //On stocke la date du prochain cours
            DateTime derniereDate = dateCourante.AddDays(NbJoursAffiches);                                          //On stocke la date du dernier jour affiché                                                                                           
            Console.WriteLine("=> dernierDate : "+derniereDate);
            //System.Threading.Thread.Sleep(5000); 
            using (List<CoursProgramme>.Enumerator enumerator = coursProgrammes.GetEnumerator())                    //Enumerateur pour parcourir la liste des cours
            {
                enumerator.MoveNext();                                  //On positionne l'enumerateur sur le 1er element
                while (dateCourante.CompareTo(derniereDate) <= 0)       //Tant que la prochaine date est plus petite ou égale à la dernière date du calendrier
                {
                    //System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("=> "+dateCourante);
                    List<CoursProgramme> coursDate = new List<CoursProgramme>();
                    while (enumerator.Current != null && enumerator.Current.DateDebut.Day == dateCourante.Day)
                    {
                        Console.WriteLine("Add "+enumerator.Current.DateDebut);
                        coursDate.Add(enumerator.Current);
                        enumerator.MoveNext();
                    }
                    Console.WriteLine("---------End Day----------");
                    this.PlanningJours.Add(new PlanningJour
                    {
                        Date = dateCourante,
                        CoursProgrammes = coursDate
                    });
                    dateCourante = dateCourante.AddDays(1);
                }
            }
        }
    }
}
