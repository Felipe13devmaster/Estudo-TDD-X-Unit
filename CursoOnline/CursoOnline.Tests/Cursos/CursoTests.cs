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
                CargaHoraria = 80,
                PublicoAlvo = "Estudantes",
                Valor = 950
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);// Substitui o assert e torna mais simples verificar se curso esperado corresponde a curso.
        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
