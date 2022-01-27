using backend_test.Models;

namespace backend_test.Services
{
    public interface ICreditService
    {

        public double Calcul_Interet(double taux_ann);
        public double Calcul_Mensualite(double capital, double taux_mensuel, int duree);
        public double Calcul_Net(double brut, double hypotheque);
        public double Calcul_hypotheque(double brut);
        public double Calcul_Brut(double fraisAchat, double montantAchat, double fondPropre);
        public double Calcul_FraisAchat(Credit credit);
        public List<Amortissement> Calcul_Ammortissement(double net, double mensualite, double taux_men, double duree);





    }
}
