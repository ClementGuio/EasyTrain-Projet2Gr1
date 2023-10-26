using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public DbSet<CoursProgramme> CoursProgrammes {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Permet de se connecter à la Bdd
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rootroot;database=EasyTrain"); // Chaine de caractères de connexion
        }

        public void InitializeDb() // Permet la création de la Bdd et le remplissage des tables
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //Remplissage des tables
            this.Clients.AddRange(new List<Client>()
            {
                new Client
            {
                Nom = "BONNER",
                Prenom = "Henri",
                DateNaissance = new DateTime(1980, 12, 12),
                AdresseMail = "BONNER.Henri@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2023, 3, 15),
                DateCreationCompte = new DateTime(2022, 4, 27)
            },
            new Client
            {
                Nom = "DUPONT",
                Prenom = "Pierre",
                DateNaissance = new DateTime(1975, 12, 12),
                AdresseMail = "dupont.pierre@gmail.com",
                MotDePasse = "mdp",
                DateAbonnement = new DateTime(2022, 3, 15),
                DateCreationCompte = new DateTime(2022, 7, 27)
            } });

            this.Coachs.AddRange(new List<Coach>()
            {
                new Coach() {Nom = "Frau" , Prenom = "Richard", DateEmbauche = DateTime.Now},
                new Coach() {Nom = "Vida" , Prenom = "Thibault", DateEmbauche = DateTime.Now},
                new Coach() {Nom = "Vince" , Prenom = "Charles", DateEmbauche = DateTime.Now}
            });

            this.Gestionnaires.AddRange(new List<Gestionnaire>()
            {
                new Gestionnaire(){Nom="Smith" , Prenom ="John", DateEmbauche= DateTime.Now},
                new Gestionnaire(){Nom="Amira" , Prenom ="Mdghri", DateEmbauche= DateTime.Now},
                new Gestionnaire(){Nom="Hossame" , Prenom ="Sadeq", DateEmbauche= DateTime.Now}
            });
            //Sauvegarde les changements dans la Bdd
            this.SaveChanges();

            this.Equipements.AddRange(new List<Equipement>()
            {
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Banc de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Cage de musculation"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Set d'haltères"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo"},
                new Equipement(){ Nom = "Vélo elliptique"},
                new Equipement(){ Nom = "Vélo elliptique"},
                new Equipement(){ Nom = "Vélo elliptique"}
            });

            this.SaveChanges();

            this.Salles.AddRange(new List<Salle>()
            {
                new Salle(){Nom = "The Rock", Type = "Musculation", Equipements = Equipements.Where(e => (e.Nom == "Cage de musculation")
                || (e.Nom == "Set d'haltères") || (e.Nom == "Banc de musculation")).ToList() },
                new Salle(){Nom = "Maillot jaune", Type = "Cyclisme", Equipements = Equipements.Where(e => (e.Nom.Contains("Vélo"))).ToList()}
            });
            this.SaveChanges();

            this.Cours.AddRange(new List<Cours>()
            {
                new Cours(){Titre = "Musculation débutant", NbParticipants = 10, Prix = 23.5,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Frau") && (c.Prenom == "Richard")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Musculation avancé", NbParticipants = 7, Prix = 26.5,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Frau") && (c.Prenom == "Richard")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "The Rock") },
                new Cours(){Titre = "Cyclisme", NbParticipants = 5, Prix = 20,
                    Coach = Coachs.FirstOrDefault(c => (c.Nom == "Vida") && (c.Prenom == "Thibault")),
                    Salle = Salles.FirstOrDefault(s => s.Nom == "Maillot jaune") }
            });
            this.SaveChanges();

            this.CoursProgrammes.AddRange(new List<CoursProgramme>()
            {
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
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation avancé"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation avancé").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 9, 10, 30, 0), DateFin = new DateTime(2023, 11, 9, 11, 15, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants},
                new CoursProgramme(){ DateDebut = new DateTime(2023, 11, 8, 16, 0, 0), DateFin = new DateTime(2023, 11, 8, 16, 45, 0),
                    Cours = Cours.First(c => c.Titre == "Musculation débutant"),
                    PlacesLibres = Cours.First(c => c.Titre == "Musculation débutant").NbParticipants}
            });
            this.SaveChanges();
        }
    }
}
