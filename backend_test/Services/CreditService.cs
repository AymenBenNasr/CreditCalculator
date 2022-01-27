using backend_test.Models;

namespace backend_test.Services
{
    public class CreditService : ICreditService
    {
        public double Calcul_FraisAchat(Credit credit)
        {
            return credit.montant_achat * 0.1;
        }
        //Montant à emprunter Brut

        public double Calcul_Brut(double fraisAchat, double montantAchat, double fondPropre)
        {
            return montantAchat - fondPropre + fraisAchat;
        }
        public double Calcul_hypotheque(double brut)
        {
            return brut * 0.02;
        }

        //Montant à emprunter Net
        public double Calcul_Net(double brut, double hypotheque)
        {
            return brut + hypotheque;
        }

        //Taux d'intérêt mensuel
        public double Calcul_Interet(double taux_ann)
        {
            return Math.Round(Math.Pow(((taux_ann / 100) + 1), (double)1 / (double)12) - 1, 3);
        }

        //Mensualité
        public double Calcul_Mensualite(double capital, double taux_mensuel, int duree)
        {
            var m = Math.Pow((1 + taux_mensuel), duree);
            return Math.Round(((capital * taux_mensuel * m) / (m - 1)), 2);
        }

        //Tableau d'ammortissement
        public List<Amortissement> Calcul_Ammortissement(double net, double mensualite, double taux_men, double duree)
        {
            List<Amortissement> amortissements = new List<Amortissement>();

            var solde_debut = net;

            for (int i = 1; i <= duree; i++)
            {
                var interet = solde_debut * taux_men;
                var capitalR = mensualite - interet;
                var solde_fin = solde_debut - capitalR;
                amortissements.Add(new Amortissement()
                {
                    periode = i,
                    Solde_debut = Math.Round(solde_debut, 2),
                    Mensualite = mensualite,
                    Interet = Math.Round(interet, 2),
                    Capitale_rembourse = Math.Round(capitalR, 2),
                    Solde_Fin = Math.Round(solde_fin, 2)
                });

                solde_debut = solde_fin;
            }
            return amortissements;


        }

    }
}
