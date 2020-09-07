using iMovie.Domain.Service.Omdb;
using Xunit;

namespace iMovie.Facade.Tests.Omdb
{
    public class ParameterIdTitleTest
    {
        [Fact(DisplayName = "Parametro Id e Título - Titulo Ok")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Titulo Ok")]
        public void ValidateIdOrTitle_ByTitle_IsValid()
        {
            //Arrange
            var parameters = new ParameterIdTitle(string.Empty, "Titanic");
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);

        }

        [Fact(DisplayName = "Parametro Id e Título - Id Ok")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Id Ok")]
        public void ValidateIdOrTitle_ById_IsValid()
        {
            //Arrange
            var parameters = new ParameterIdTitle("tt7363104", string.Empty);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);

        }

        [Fact(DisplayName = "Parametro Id e Título - Id e Titulos Inválidos")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Id e Titulos Inválidos")]
        public void ValidateIdOrTitle_ByIdTitle_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterIdTitle(string.Empty, string.Empty);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);

        }

        [Fact(DisplayName = "Parametro Id e Título - Todos Parametros Válidos")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Todos Parametros Válidos")]
        public void ValidateIdOrTitle_AllFilled_IsValid()
        {
            //Arrange
            var parameters = new ParameterIdTitle("tt0120338", "Titanic", "movie", 1997, "full", "xml", "2");
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Id e Título - Alguns Parametros Válidos")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Alguns Parametros Válidos")]
        public void ValidateIdOrTitle_NotAllFilled_IsValid()
        {
            //Arrange
            var parameters = new ParameterIdTitle("tt0120338", "Titanic", null, null, null, "xml", "2");
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Id e Título - Todos Parametros Inválidos")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Todos Parametros Inválidos")]
        public void ValidateIdOrTitle_AllFilled_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterIdTitle(string.Empty, string.Empty, "cd", -1000, "little", "yaml", string.Empty);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Parametro Id e Título - Todos Parametros Nulos")]
        [Trait("Omdb", "Omdb - Parametro Id e Título - Todos Parametros Nulos")]
        public void ValidateIdOrTitle_AllNullables_IsInvalid()
        {
            //Arrange
            var parameters = new ParameterIdTitle(null, null, null, null, null, null, null);
            //Act
            var result = parameters.IsOk();
            //Assert
            Assert.False(result.IsValid);
        }
    
    }
}
