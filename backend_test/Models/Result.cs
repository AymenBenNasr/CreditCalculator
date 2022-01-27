namespace backend_test.Models
{
    public class Result
    {
        public double Frais_achat { get; set; }
        public double Montant_Brut { get; set; }
        public double Montant_Net { get; set; }
        public double Frais_hypotheque { get; set; }
        public double Taux_mensuel { get; set; }
        public double Mensualite { get; set; }
        public ICollection<Amortissement> amortissements { get; set; }

    
    }
}
