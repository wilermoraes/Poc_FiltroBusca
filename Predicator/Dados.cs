using System;
using System.Collections.Generic;

namespace Predicator
{
    public static class Dados
    {
        public static List<Pessoa> ObterPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Maria José", Sexo = "F", DataNascimento = new DateTime(1990, 01, 25) });
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Antônio Carlos", Sexo = "M", DataNascimento = new DateTime(1940, 03, 12) });
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Pedro Henrique", Sexo = "M", DataNascimento = new DateTime(1955, 09, 15) });
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Paulo Antônio", Sexo = "M", DataNascimento = new DateTime(1980, 03, 11) });
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Antonieta das Neves", Sexo = "F", DataNascimento = new DateTime(2000, 11, 05) });
            pessoas.Add(new Pessoa() { Id = Guid.NewGuid(), Nome = "Micaela Jordania", Sexo = "F", DataNascimento = new DateTime(1999, 05, 30) });

            return pessoas;
        }

    }
}
