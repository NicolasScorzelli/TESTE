using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService;


        // FUNÇÃO PARA REALIZAR A INSERÇÃO DE INFORMAÇÕES DO OPERADOR
        public FareController()
        {
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare tarifa, string operatorCode)
        {

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode); // - VALIDA O CÓDIGO DO OPERADOR NA FUNÇÃO GetOperatorByCode
            tarifa.OperatorId = selectedOperator.Id; // - 'tarifa.OperatorId' RECEBE O CÓDIGO DO OPERADOR
            var selectedTarifa = FareService.GetFareById(tarifa.Id);


            if (!(tarifa.Status != 1))
            {
                FareService.Create(tarifa);
            }

            else
            {
                throw new Exception("Já existe uma tarifa ativa");
            }
        }
    }
}
