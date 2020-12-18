using Bogus;
using CursoOnline.Tests.Builders;
using CursoOnline.Tests.Extensoes;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Tests.Cursos
{
    public class CursoTests : IDisposable
    {
        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly decimal _valor;

        public CursoTests()//O construtor no xUnit difere do ctor de uma classe normal, pois o mesmo é executado novamente antes de cada metodo da classe de testes.
        {//Esta parte é chamada de setup da classe de teste
            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(50, 100);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Decimal(100, 1000);
        }

        public void Dispose()// é executado novamente depois de cada metodo da classe de testes.
        {//Esta parte é chamada de clean up da classe de teste
            
        }

        [Fact(DisplayName = "Deve_Criar_Curso")]
        public void Deve_Criar_Curso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);// Substitui o assert e torna mais simples verificar se curso esperado corresponde a curso.
        }

        [Theory(DisplayName = "Nome_Do_Curso_Nao_Deve_Ser_Vazio")]//Testa as teorias enviado inlinedata como argumento
        [InlineData("")]
        [InlineData(null)]
        public void Nome_Do_Curso_Nao_Deve_Ser_Vazio_Ou_Nulo(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.CriarNovoCurso().DefinirNome(nomeInvalido).Build())
                .ValidarMensagem("Nome inválido."); ;
        }

        [Theory(DisplayName = "Curso_Nao_Deve_Ter_Carga_Horaria_Menor_Que_1_Hora")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Curso_Nao_Deve_Ter_Carga_Horaria_Menor_Que_1_Hora(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.CriarNovoCurso().DefinirCargaHoraria(cargaHorariaInvalida).Build())
                .ValidarMensagem("Carga horaria inválida."); 
        }

        [Theory(DisplayName = "Curso_Nao_Deve_Ter_Valor_Menor_Que_1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void Curso_Nao_Deve_Ter_Valor_Menor_Que_1(decimal valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.CriarNovoCurso().DefinirValor(valorInvalido).Build())
                .ValidarMensagem("Valor inválido.");
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
        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido.");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria inválida.");

            if (valor < 1)
                throw new ArgumentException("Valor inválido.");
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
