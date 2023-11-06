namespace EasyTrain_P2Gr1.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual CoursProgramme CoursProgramme { get; set; }
        public virtual Client Client {  get; set; }
    }


}
