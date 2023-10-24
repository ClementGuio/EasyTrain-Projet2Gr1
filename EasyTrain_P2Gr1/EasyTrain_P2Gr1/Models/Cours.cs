namespace EasyTrain_P2Gr1.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int NbParticipants { get; set; }
        public float Prix { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Salle Salle { get; set; }

    }
}
