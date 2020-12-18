using CursoOnline.Domain.Entidades;
using CursoOnline.Domain.Enums;

namespace CursoOnline.Tests.Builders
{
    public class CursoBuilder
    {
        private string _nome = "Informática";
        private string _descricao = "Curso básico.";
        private double _cargaHoraria = 80;
        private EPublicoAlvo _publicoAlvo = EPublicoAlvo.Estudante;
        private decimal _valor = 950;

        public static CursoBuilder CriarNovoCurso()
        {
            return new CursoBuilder();//Retorna o proprio ctor
        }

        public CursoBuilder DefinirNome(string nome)
        {
            _nome = nome;
            return this;//retorna o proprio ctor da classe
        }

        public CursoBuilder DefinirDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder DefinirCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder DefinirPublicoAlvo(EPublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder DefinirValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
