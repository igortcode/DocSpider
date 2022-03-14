using DS.Business.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DS.Business.Test
{
    public class ArquivoTest
    {
        [Fact]
        public void ArquivoFactory_Criar_DeveRetornarTipoDerivadoEntity()
        {
            var arquivo = new Arquivo();

            Assert.IsAssignableFrom<Entity>(arquivo);
        }

        [Theory]
        [InlineData(30,02,2022)]
        [InlineData(32,12,2022)]
        [InlineData(30, 13, 2022)]
        public void ArquivoDataCriacao_Criar_DeveRetornarErroDataInvalida(int dia, int mes, int ano)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTime(dia, mes, ano));
        }

    }
}
