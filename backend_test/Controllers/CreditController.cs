using backend_test.Models;
using backend_test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_test.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CreditController : ControllerBase
    {
        private readonly ILogger<CreditController> _logger;

        private readonly ICreditService _creditService;
        public CreditController(ILogger<CreditController> logger, ICreditService creditService)
        {
            _logger = logger;
            _creditService = creditService;
        }

        [HttpPost(Name = "CalculCapital")]
        public Result Post([FromBody] Credit credit)
        {
            Result result = new Result();


            result.Frais_achat = _creditService.Calcul_FraisAchat(credit);
            result.Montant_Brut = _creditService.Calcul_Brut(result.Frais_achat, credit.montant_achat, credit.fonds_propres);
            result.Frais_hypotheque = _creditService.Calcul_hypotheque(result.Montant_Brut);
            result.Montant_Net = _creditService.Calcul_Net(result.Montant_Brut, result.Frais_hypotheque);
            result.Taux_mensuel = _creditService.Calcul_Interet(credit.taux_annuel);
            result.Mensualite = _creditService.Calcul_Mensualite(result.Montant_Net, result.Taux_mensuel, credit.duree_credit);
            result.amortissements = _creditService.Calcul_Ammortissement(result.Montant_Net, result.Mensualite, result.Taux_mensuel, credit.duree_credit);



            return result;
        }


    }
}
