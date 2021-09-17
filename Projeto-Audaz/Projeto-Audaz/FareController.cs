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

        public FareController()
        {
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var _operator = new Operator();
            _operator.Id = Guid.NewGuid();

            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorId = _operator.Id;

            FareService.Create(fare);
        }
    }
}
