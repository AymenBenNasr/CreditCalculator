namespace backend_test.Models
{
    public class Amortissement
    {
        public int periode { get; set; }    
        public double Solde_debut { get; set; }
        public double Interet { get; set; }

        public double Mensualite { get; set; }
        public double Capitale_rembourse { get; set; }
        public double Solde_Fin { get; set; }   
    }
}
