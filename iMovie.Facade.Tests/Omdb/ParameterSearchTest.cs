using System;
using Xunit;
using iMovie.Facade.Omdb.Domain;

namespace iMovie.Facade.Tests.Omdb
{
    public class ParameterSearchTest
    {
        [Fact(DisplayName = "Validar Parametros de Busca - Busca Valida")]
        [Trait("Omdb", "Validar Parametros de busca - Busca Ok")]
        public void ValidateSearch_BySearch_IsValid()
        {
            //Arrange
            var parameters = new ParameterSearch("Titanic");
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);

        }

        [Fact(DisplayName = "Parametro Busca - Busca Inválida")]
        [Trait("Omdb", "Omdb - Parametro Busca - Busca Inválida")]
        public void ValidateSearch_BySearch_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterSearch(string.Empty);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);

        }

        [Fact(DisplayName = "Parametro Busca - Todos Parametros Inválidos")]
        [Trait("Omdb", "Omdb - Parametro Busca - Todos Parametros Inválidos")]
        public void ValidateSearch_AllFilled_IsValid()
        {
            //Arrange
            var parameters = new ParameterSearch("Titanic", "movie", 1997, "xml", 1, 2);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Busca - Alguns Parametros Válidos")]
        [Trait("Omdb", "Omdb - Parametro Busca - Alguns Parametros Válidos")]
        public void ValidateSearch_NotAllFilled_IsValid()
        {
            //Arrange
            var parameters = new ParameterSearch("Titanic", null, null, "xml", 2, 2);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Busca - Todos Parametros Inválidos")]
        [Trait("Omdb", "Omdb - Parametro Busca - Todos Parametros Inválidos")]
        public void ValidateSearch_AllFilled_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterSearch(string.Empty, "cd", -1000, "yaml", -1, -1);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Busca - Todos Parametros Nulos")]
        [Trait("Omdb", "Omdb - Parametro Busca - Todos Parametros Nulos")]
        public void ValidateSearch_AllNullables_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterSearch(null, null, null, null, null, null);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);
        }
    }
}
