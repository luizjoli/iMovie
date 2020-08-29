using Xunit;
using iMovie.Facade.Omdb.Domain;
using iMovie.Facade.Omdb;
using System;
using Moq;

namespace iMovie.Facade.Tests.Omdb
{
    public class OmdbApiTest
    {

        private readonly OmdbApi omdbApi;

        public OmdbApiTest(){
            var mock = new Mock<OmdbApi>();
            omdbApi = mock.Object;
        }

        [Fact(DisplayName = "Omdb - Busca um titulo no serviço")]
        [Trait("Omdb", "Omdb - Busca um titulo no serviço")]
        public async void GetByIdOrTitleAsync_ByTitle_OneResult()
        {
            //Arrange
            var parameter = new ParameterIdTitle(null, "Titanic");         
            //var omdbApi = new OmdbApi("http://www.omdbapi.com", "c19cd964");
            
            //Act
            var result = await omdbApi.GetByIdOrTitleAsync(parameter);
            //Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Omdb - Busca um titulo inválido no serviço")]
        [Trait("Omdb", "Omdb - Busca um titulo inválido no serviço")]
        public async void GetByIdOrTitleAsync_ByTitle_NoneResult()
        {
            //Arrange
            var parameter = new ParameterIdTitle(null, Guid.NewGuid().ToString());            
            //Act
            var result = await omdbApi.GetByIdOrTitleAsync(parameter);
            //Assert
            Assert.Null(result.Actors);
        }

        [Fact(DisplayName = "Omdb - Busca um id válido no serviço")]
        [Trait("Omdb", "Omdb - Busca um id válido no serviço")]
        public async void GetByIdOrTitleAsync_ById_OneResult()
        {
            //Arrange
            var parameter = new ParameterIdTitle("tt0120338", null);            
            //Act
            var result = await omdbApi.GetByIdOrTitleAsync(parameter);
            //Assert
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Omdb - Busca um id inválido no serviço")]
        [Trait("Omdb", "Omdb - Busca um id inválido no serviço")]
        public async void GetByIdOrTitleAsync_ById_NoneResult()
        {
            //Arrange
            var parameter = new ParameterIdTitle(Guid.NewGuid().ToString(), null);            
            //Act
            var result = await omdbApi.GetByIdOrTitleAsync(parameter);
            //Assert
            Assert.Null(result.Actors);
        }

        [Fact(DisplayName = "Omdb - Busca um termo válido no serviço")]
        [Trait("Omdb", "Omdb - Busca um termo válido no serviço")]
        public async void GetBySearchAsync_BySearch_Valid()
        {
            //Arrange
            var parameter = new ParameterSearch("Titanic");            
            //Act
            var result = await omdbApi.GetBySearchAsync(parameter);
            //Assert
            Assert.NotNull(result);
            Assert.True(result.Search.Count > 1);
        }

        [Fact(DisplayName = "Omdb - Busca um termo inválido no serviço")]
        [Trait("Omdb", "Omdb - Busca um termo inválido no serviço")]
        public async void GetBySearchAsync_BySearch_Invalid()
        {
            //Arrange
            var parameter = new ParameterSearch("yyyyy");            
            //Act
            var result = await omdbApi.GetBySearchAsync(parameter);
            //Assert
            Assert.NotNull(result);
            Assert.True(result.Search.Count == 0);
        }
    }
}
