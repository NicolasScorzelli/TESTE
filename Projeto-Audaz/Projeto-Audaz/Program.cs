using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;
using System.Globalization;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            //ATRIBUIR UM NOVO GUID PARA TARIFA

            var tarifa = new Fare();
            tarifa.Id = Guid.NewGuid();

            // ATRIBUIR UM NOVO GUID PARA OPERADOR

            var operador = new Operator();
            operador.Id = Guid.NewGuid();

            // RECEBER ENTRADA DE DADOS DE TARIFA

            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            tarifa.Value = double.Parse(fareValueInput, CultureInfo.InvariantCulture);

            // RECEBER ENTRADA DE DADOS DO OPERADOR

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();
            operador.Code = operatorCodeInput;

            // ENVIA OS DADOS PARA O CONTROLLER DA TARIFA 

            var fareController = new FareController();
            fareController.CreateFare(tarifa, operador.Code);

            // CONFIRMAÇÃO DE CADASTRO PARA O USUÁRIO

            Console.WriteLine("Tarifa cadastrada com sucesso!");
            Console.Read();
        }
    }
}
