﻿using EasyTrain_P2Gr1.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EasyTrain_P2Gr1.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Gestionnaire> Gestionnaires { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<CoursProgramme> CoursProgrammes { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Presence> Presences { get; set; }

        //TODO: Ajouter salles Pisicine, escalade et autres
        //TODO: Ajouter cours, coursProgrammés et reservations

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Permet de se connecter à la Bdd
        {

            optionsBuilder.UseMySql("server=localhost;user id=root;password=rootroot;database=EasyTrain");
        }

        public void InitializeDb() // Permet la création de la Bdd et le remplissage des tables
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();


            this.Abonnements.AddRange(new List<Abonnement>()
            {
                new Abonnement
                {
                    Id = 1,
                    NbCours = 3,
                    AccesPiscine = true,
                    AccesEscalade = true,
                    AccompagnementCoach = true,
                    DateAbonnement = new DateTime(2022, 5, 30),

                },
                new Abonnement{
                    Id = 2,
                    NbCours = 5,
                    AccesPiscine = false,
                    AccesEscalade = false,
                    AccompagnementCoach = true,
                    DateAbonnement = new DateTime(2022, 7, 28)
                }
            });

            this.SaveChanges();

            this.Clients.AddRange(new List<Client>()
            {
                new Client
                {
                Nom = "Bonner",
                Prenom = "Henri",
                DateNaissance = new DateTime(1985, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = UtilisateurService.EncodeMD5("admin"),
                Abonnement = this.Abonnements.Find(1),
                DateCreationCompte = new DateTime(2022, 4, 27)
            },
            new Client
            {
                Nom = "Dupond",
                Prenom = "Pierre",
                DateNaissance = new DateTime(1975, 12, 12),
                AdresseMail = "dupont.pierre@gmail.com",
                MotDePasse = UtilisateurService.EncodeMD5("admin"),
                Abonnement = this.Abonnements.Find(2),
                DateCreationCompte = new DateTime(2022, 7, 27)
            },
            new Client
            {
                Nom = "Sabo",
                Prenom = "Jacques",
                DateNaissance = new DateTime(1975, 12, 12),
                AdresseMail = "sabo.jacques@gmail.com",
                MotDePasse = UtilisateurService.EncodeMD5("admin"),
                Abonnement = this.Abonnements.Find(2),
                DateCreationCompte = new DateTime(2022, 7, 27)
            }
            });

            this.Coachs.AddRange(new List<Coach>()
            {
                new Coach() {
                    Nom = "Dupond",
                    Prenom = "Pierre",
                    Specialité = "Fitness",
                    DateNaissance = new DateTime(1975, 12, 12),
                    AdresseMail = "dupont.pierre@gmail.com",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image02.jpg",
                    DateCreationCompte = new DateTime(2019, 7, 27),
                    Description = "Je reviens d'un treck de 12 ans dans l'Hymalaya."
                },
                new Coach() {
                    Nom = "Amery",
                    Prenom = "Smet",
                    Specialité = "Bodybuilding",
                    DateNaissance = new DateTime(1985,12,1),
                    AdresseMail = "a-smet@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image15.jpg",
                    DateCreationCompte = new DateTime(2020, 10, 20),
                    Description = "J'adore la raquette: tennis, ping pong, badminton et squash."
                 },
                new Coach() {
                    Nom = "May",
                    Prenom = "Berger",
                    Specialité = "Stepping",
                    DateNaissance = new DateTime(1961,2,13),
                    AdresseMail = "bergermay@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image12.jpg",
                    DateCreationCompte = new DateTime(2021, 5, 27),
                    Description = "Le vélo c'est toute ma vie."
                },
                new Coach() {
                    Nom = "Vincent",
                    Prenom = "Shaeleigh",
                    Specialité = "Bodybuilding",
                    DateNaissance = new DateTime(1977, 7, 11),
                    AdresseMail = "r.shaeleigh@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image06.jpg",
                    DateCreationCompte = new DateTime(2022, 1, 7),
                    Description = "Ancien bodybuilder, si vous voulez devenir énorme et sec, prenez rendez-vous avec moi."
                },
                new Coach() {
                    Nom = "Patrick",
                    Prenom = "Akeem",
                    Specialité = "Bodybuilding",
                    DateNaissance = new DateTime(1989,10,1),
                    AdresseMail = "p.akeem@mail.com",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image07.jpg",
                    DateCreationCompte = new DateTime(2015, 3, 30),
                    Description = "J'aime la natation et le yoga."
                 },
                new Coach() {
                    Nom = "Levine",
                    Prenom = "Madison",
                    Specialité = "Biking",
                    DateNaissance = new DateTime(1991,2,13),
                    AdresseMail = "madisonlevine4169@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image11.jpg",
                    DateCreationCompte = DateTime.Now,
                    Description = "Je pratique les sports de combats depuis 15 ans."
                },

                 new Coach() {
                    Nom = "Seelen",
                    Prenom = "Akeem",
                    Specialité = "Bodybuilding",
                    DateNaissance = new DateTime(1989,10,1),
                    AdresseMail = "p.akeem@mail.com",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image21.jpg",
                    DateCreationCompte = new DateTime(2015, 3, 30),
                    Description = "J'aime la natation et le yoga."
                 },
                new Coach() {
                    Nom = "Ludy",
                    Prenom = "Madison",
                    Specialité = "Biking",
                    DateNaissance = new DateTime(1991,2,13),
                    AdresseMail = "madisonlevine4169@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    ImgPath = "/images/coach/image20.jpg",
                    DateCreationCompte = DateTime.Now,
                    Description = "Je pratique les sports de combats depuis 15 ans."
                }

            }); ;

            this.Gestionnaires.AddRange(new List<Gestionnaire>()
            {
                new Gestionnaire(){
                    Nom = "Dubois",
                    Prenom = "Stella",
                    DateNaissance = new DateTime(1990,6,10),
                    AdresseMail = "stella.dubois@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    DateCreationCompte = new DateTime(2019, 7, 27),
                },
                new Gestionnaire(){
                    Nom = "Lester",
                    Prenom = "Vincent",
                    DateNaissance = new DateTime(2003,9,22),
                    AdresseMail = "vincent.lester@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    DateCreationCompte = new DateTime(2020, 3, 25),
                },
                new Gestionnaire(){
                    Nom="Sadeq",
                    Prenom ="Hossame",
                    DateNaissance= new DateTime(1997,5,17),
                    AdresseMail = "hossame.sadeq@mail.fr",
                    MotDePasse = UtilisateurService.EncodeMD5("admin"),
                    DateCreationCompte = new DateTime(2018, 2, 15),
                }
            });
            //Sauvegarde les changements dans la Bdd
            this.SaveChanges();

            this.Equipements.AddRange(new List<Equipement>()
            {
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Haltères" , imageEquipement="/images/vincent/halteres.jpg" },
                new Equipement(){ Nom = "Banc de musculation" , imageEquipement="/images/vincent/bancmusculation.jpg"},
                new Equipement(){ Nom = "Banc de musculation" , imageEquipement="/images/vincent/bancmusculation.jpg"},
                new Equipement(){ Nom = "Banc de musculation" , imageEquipement="/images/vincent/bancmusculation.jpg"},
                new Equipement(){ Nom = "Banc de musculation" , imageEquipement="/images/vincent/bancmusculation.jpg"},
                new Equipement(){ Nom = "Banc de musculation" , imageEquipement="/images/vincent/bancmusculation.jpg"},
                new Equipement(){ Nom = "Cage de musculation", imageEquipement="/images/vincent/cage-de-musculation.jpg"},
                new Equipement(){ Nom = "Cage de musculation", imageEquipement="/images/vincent/cage-de-musculation.jpg"},
                new Equipement(){ Nom = "Cage de musculation", imageEquipement="/images/vincent/cage-de-musculation.jpg"},
                new Equipement(){ Nom = "Rameur", imageEquipement = "/images/vincent/rameur2.jpg"},
                new Equipement(){ Nom = "Rameur", imageEquipement = "/images/vincent/rameur2.jpg"},
                new Equipement(){ Nom = "Tapis de course", imageEquipement="/images/vincent/tapis-de-course.jpg"},
                new Equipement(){ Nom = "Tapis de course", imageEquipement="/images/vincent/tapis-de-course.jpg"},
                new Equipement(){ Nom = "Tapis de course", imageEquipement="/images/vincent/tapis-de-course.jpg"},
                new Equipement(){ Nom = "Tapis de course", imageEquipement="/images/vincent/tapis-de-course.jpg"},
                new Equipement(){ Nom = "Tapis de course", imageEquipement="/images/vincent/tapis-de-course.jpg"},
                new Equipement(){ Nom = "Cage à cuisses", imageEquipement = "/images/vincent/cage-a-cuisse.jpg"},
                new Equipement(){ Nom = "Cage à cuisses", imageEquipement = "/images/vincent/cage-a-cuisse.jpg"},
                new Equipement(){ Nom = "Cage à cuisses", imageEquipement = "/images/vincent/cage-a-cuisse.jpg"},
                new Equipement(){ Nom = "Vélo", imageEquipement="/images/vincent/velo1.jpg"},
                new Equipement(){ Nom = "Vélo", imageEquipement="/images/vincent/velo1.jpg"},
                new Equipement(){ Nom = "Vélo", imageEquipement="/images/vincent/velo1.jpg"},
                new Equipement(){ Nom = "Vélo", imageEquipement="/images/vincent/velo1.jpg"},
                new Equipement(){ Nom = "Aquabiking", imageEquipement="/images/vincent/aquabiking.jpg"},
                new Equipement(){ Nom = "Aquabiking", imageEquipement="/images/vincent/aquabiking.jpg"},
                new Equipement(){ Nom = "Aquabiking", imageEquipement="/images/vincent/aquabiking.jpg"},
                new Equipement(){ Nom = "Aquabiking", imageEquipement="/images/vincent/aquabiking.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
                new Equipement(){ Nom = "Vélo elliptique", imageEquipement = "/images/vincent/veloelliptique.jpg"},
            });

            this.SaveChanges();

            this.Salles.AddRange(new List<Salle>()
            {
                new Salle(){Nom = "The Rock", Type = "Musculation", Equipements = Equipements.Where(e => (e.Nom == "Cage de musculation")
                || (e.Nom == "Set d'haltères") || (e.Nom == "Banc de musculation")).ToList() },
                new Salle(){Nom = "Maillot jaune", Type = "Cyclisme", Equipements = Equipements.Where(e => (e.Nom.Contains("Vélo"))).ToList()},
                new Salle(){Nom = "Disco", Type = "Aérobic", Equipements = Equipements.Where(e => (e.Nom.Contains("Vélo"))).ToList()},
                new Salle(){Nom = "Poseidon", Type = "Piscine", Equipements = new List<Equipement>() },
                new Salle(){Nom = "Cliffhanger", Type = "Escalade", Equipements = new List<Equipement>()}
            });
            this.SaveChanges();

            this.Cours.AddRange(new List<Cours>()
            {
                new Cours(){Titre = "Musculation débutant", NbParticipants = 10, Prix = 23.5, DureeMinutes = 75,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Patrick") && (c.Prenom == "Akeem")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Musculation avancé", NbParticipants = 7, Prix = 26.5, DureeMinutes = 90,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Patrick") && (c.Prenom == "Akeem")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Cyclisme", NbParticipants = 5, Prix = 20,DureeMinutes = 60,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "May") && (c.Prenom == "Berger")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "Maillot jaune") },
                new Cours(){Titre = "Escalade", NbParticipants = 4, Prix = 25,DureeMinutes = 90,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "May") && (c.Prenom == "Berger")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "Cliffhanger") },
                new Cours(){Titre = "Natation", NbParticipants = 20, Prix = 15,DureeMinutes = 75,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "May") && (c.Prenom == "Berger")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "Poseidon") }
            });
            this.SaveChanges();

            this.CoursProgrammes.AddRange(new List<CoursProgramme>()
            {
                new CoursProgramme(){ DateDebut = DateTime.Now , DateFin = DateTime.Now.AddHours(1),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = DateTime.Now.AddDays(1) , DateFin = DateTime.Now.AddDays(1).AddHours(1),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 10, 16, 30, 0), DateFin = new DateTime(2023, 11, 8, 17, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Cyclisme"),
                    PlacesLibres = Cours.First(c => c.Titre == "Cyclisme").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 10, 30, 0), DateFin = new DateTime(2023, 11, 8, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 10, 30, 0), DateFin = new DateTime(2023, 11, 8, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 10, 30, 0), DateFin = new DateTime(2023, 11, 8, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 10, 30, 0), DateFin = new DateTime(2023, 11, 8, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 10, 30, 0), DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 9, 0, 0), DateFin = new DateTime(2023, 11, 8, 10, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Natation"),
                    PlacesLibres = Cours.First(c => c.Titre == "Natation").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 12, 0, 0), DateFin = new DateTime(2023, 11, 8, 13, 30, 0),
                    Cours = Cours.First(c => c.Titre == "Escalade"),
                    PlacesLibres = Cours.First(c => c.Titre == "Escalade").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 9, 0, 0), DateFin = new DateTime(2023, 11, 9, 10, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Natation"),
                    PlacesLibres = Cours.First(c => c.Titre == "Natation").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 12, 0, 0), DateFin = new DateTime(2023, 11, 9, 13, 30, 0),
                    Cours = Cours.First(c => c.Titre == "Escalade"),
                    PlacesLibres = Cours.First(c => c.Titre == "Escalade").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 10, 9, 0, 0), DateFin = new DateTime(2023, 11, 10, 10, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Natation"),
                    PlacesLibres = Cours.First(c => c.Titre == "Natation").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 10, 12, 0, 0), DateFin = new DateTime(2023, 11, 10, 13, 30, 0),
                    Cours = Cours.First(c => c.Titre == "Escalade"),
                    PlacesLibres = Cours.First(c => c.Titre == "Escalade").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 11, 9, 0, 0), DateFin = new DateTime(2023, 11, 11, 10, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Natation"),
                    PlacesLibres = Cours.First(c => c.Titre == "Natation").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 11, 12, 0, 0), DateFin = new DateTime(2023, 11, 11, 13, 30, 0),
                    Cours = Cours.First(c => c.Titre == "Escalade"),
                    PlacesLibres = Cours.First(c => c.Titre == "Escalade").NbParticipants}
            });
            this.SaveChanges();

            this.Reservations.AddRange(new List<Reservation>()
            {

                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Musculation avancé").ToList()[0],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "BONNER.Henri@gmail.com")
                },
                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Musculation débutant").ToList()[0],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "BONNER.Henri@gmail.com")
                },
                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Cyclisme").ToList()[2],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "dupont.pierre@gmail.com")
                },
                 new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Natation").ToList()[0],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "BONNER.Henri@gmail.com")
                },
                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Escalade").ToList()[1],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "BONNER.Henri@gmail.com")
                },
                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Natation").ToList()[0],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "sabo.jacques@gmail.com")
                },
                new Reservation(){
                    CoursProgramme = this.CoursProgrammes.Where(c => c.Cours.Titre == "Escalade").ToList()[0],
                    Client = this.Clients.FirstOrDefault(c => c.AdresseMail == "sabo.jacques@gmail.com")
                }
            });
            this.SaveChanges();


            this.Presences.AddRange(new List<Presence>
            {
                new Presence
                {
                    HeureArrivee = new DateTime(2023, 10, 9, 10, 30, 0), HeureDepart = new DateTime(2023, 10, 9, 11, 30, 0), Client = this.Clients.Find(1)
                },
                new Presence
                {
                    HeureArrivee = DateTime.Now, Client = this.Clients.Find(1)
                },
                new Presence
                {
                    HeureArrivee = DateTime.Now,
                    HeureDepart = DateTime.Now.AddHours(1),
                    Client = this.Clients.Find(2)
                }
            });
            this.SaveChanges();


        }

    }
}
