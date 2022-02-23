using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void TestaValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Mateus Marques da Costa";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vinho";
            veiculo.Modelo = "Uno";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Mateus Marques", "ASD-1498", "Vinho", "Uno")]
        [InlineData("Carolina Mascarenhas", "POL-9242", "Azul", "Gol")]
        [InlineData("Yuri Marques", "GDR-6524", "Preto", "Opala")]
        public void TesteValidaFaturamentoVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Mateus Marques", "ASD-1498", "Vinho", "Uno")]
        public void TesteLocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        /*[Fact]
        public void TesteAlterarDadosVeiculo()
        {
            //Arrenge
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Mateus Marques";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculo.Proprietario = "Mateus Marques";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Preto"; //Alterado
            veiculo.Modelo = "Opala";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado); 

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }*/
    }
}
