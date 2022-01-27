namespace backend_test.Services
{
    public class CreditInverse : ICreditInverseService
    {
        public double Calcul_Montant_Achat(double frais_achat)
        {
            return frais_achat * 10;
        }
    }
}
