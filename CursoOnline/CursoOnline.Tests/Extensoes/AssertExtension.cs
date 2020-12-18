using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Tests.Extensoes
{
    public static class AssertExtension
    {
        public static void ValidarMensagem(this ArgumentException argumentException, string mensagem)
        {
            if (argumentException.Message == mensagem)
                Assert.True(true);
            else
                Assert.False(true);
        }
    }
}
