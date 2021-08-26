using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Predicator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = Dados.ObterPessoas();
            Filtro filtro = MontarFiltro();

            Console.WriteLine("======== BUSCA COM IF ========");

            pessoas = BuscaComIf(filtro, pessoas);
            GerarResposta(pessoas);

            Console.WriteLine("======== ************ ========");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("======== BUSCA COM LINQ ========");

            pessoas = BuscaComLinq(filtro, pessoas);
            GerarResposta(pessoas);

            Console.WriteLine("======== ************ ========");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("======== BUSCA COM REFLECTION ========");

            pessoas = BuscaComReflection(filtro, pessoas);
            GerarResposta(pessoas);

            Console.WriteLine("======== ************ ========");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.ReadKey();
        }

        private static Filtro MontarFiltro()
        {
            Filtro filtro = new Filtro();

            Console.WriteLine("Nome: ");
            filtro.Nome = Console.ReadLine();

            Console.WriteLine("Sexo: ");
            filtro.Sexo = Console.ReadLine();

            return filtro;
        }

        private static void GerarResposta(List<Pessoa> pessoas)
        {
            foreach(var pessoa in pessoas)
            {
                Console.WriteLine($"{pessoa.Nome} - {pessoa.Sexo}");
            }
        }

        private static List<Pessoa> BuscaComIf(Filtro filtros, List<Pessoa> pessoas)
        {
            if (!string.IsNullOrEmpty(filtros.Nome))
                pessoas = pessoas.Where(p => p.Nome.ToLower().Contains(filtros.Nome.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filtros.Sexo))
                pessoas = pessoas.Where(p => p.Sexo == filtros.Sexo).ToList();

            return pessoas;
        }

        private static List<Pessoa> BuscaComLinq(Filtro filtros, List<Pessoa> pessoas)
        {
            return pessoas.Where(p => (!string.IsNullOrEmpty(filtros.Nome) && p.Nome.ToLower().Contains(filtros.Nome.ToLower())) ||
                                      (!string.IsNullOrEmpty(filtros.Sexo) && p.Sexo == filtros.Sexo)).ToList();
        }

        private static List<Pessoa> BuscaComReflection(Filtro filtros, List<Pessoa> pessoas)
        {
            Type type = filtros.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo p in properties)
            {
                var nomeCampo = p.Name;
                var valorCampo = p.GetValue(filtros, null).ToString();

                if (!string.IsNullOrEmpty(valorCampo))
                {
                    pessoas = pessoas.Where(p => p.GetType().GetProperties().Where(x => x.Name == nomeCampo).FirstOrDefault().GetValue(p, null).ToString().Contains(valorCampo)).ToList();
                }
            }

            return pessoas;
        }
    }
}
