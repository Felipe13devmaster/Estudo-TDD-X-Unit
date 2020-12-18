using CursoOnline.Domain.Enums;
using System;

namespace CursoOnline.Domain.Entidades
{
    public class Curso
    {
        public Curso(string nome, string descricao, double cargaHoraria, EPublicoAlvo publicoAlvo, decimal valor)
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
        public EPublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
