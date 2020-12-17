using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Tests.Cursos
{
    public class CursoTests

    {
        [Fact(DisplayName = "Deve_Criar_Curso")]
        public void Deve_Criar_Curso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática",
                CargaHoraria = (double)80,//É neccessario informar o tipo explicitamnte pois o toExpected n possui inteligencia para diferenciar tipos numericos.
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);// Substitui o assert e torna mais simples verificar se curso esperado corresponde a curso.
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
