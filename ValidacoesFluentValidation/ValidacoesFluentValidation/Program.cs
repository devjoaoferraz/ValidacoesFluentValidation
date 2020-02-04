using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacoesFluentValidation.Entidades;
using ValidacoesFluentValidation.Validacao;

namespace ValidacoesFluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemVenda item1 = new ItemVenda()
            {
                Descricao = "Cabo USB 2.5m",
                Preco = 35,
                Quantidade = 1
            };

            ItemVenda item2 = new ItemVenda()
            {
                Descricao = "Pendrive",
                Preco = 20,
                Quantidade = 1
            };

            Venda venda = new Venda();
            venda.Data = DateTime.Today.AddDays(0);
            venda.Tipo = TipoVenda.Padrao;
            venda.Total = 55;
            venda.Itens = new List<ItemVenda>(new[] { item1, item2 });

            VendaValidator validador = new VendaValidator();
            //ValidationResult resultado = validador.Validate(venda);

            try
            {
                validador.ValidateAndThrow(venda);
            }
            catch (ValidationException excecao)
            {
                Console.WriteLine("Venda inválida.");
                excecao.Errors
                       .ToList()
                       .ForEach(e => Console.WriteLine($"{e.PropertyName} : {e.ErrorMessage}"));
            }

            Console.ReadKey();
        }
    }
}
