using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SMSDigitalCodingProject.Controllers;
using SMSDigitalCodingProject.Model;
using SMSDigitalCodingProject.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSDigitalTest
{
    public class UnitTestController
    {
        #region Property  
        public Mock<ICityDetailRepo> mock = new Mock<ICityDetailRepo>();
        #endregion

        // Logger mock 
        ILogger<CityController> logger = Mock.Of<ILogger<CityController>>();


        #region Get City Details

        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            mock.Setup(_ => _.GetCityDetails()).ReturnsAsync(MockData.GetAllCities());
            var city = new CityController(logger, mock.Object);

            /// Act
            var result = (OkObjectResult)await city.GetCities();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }
        #endregion


        #region Get City Detail by Id

        [Fact]
        public async Task GetCityDetailById_Async_ShouldReturn200Status()
        {
            /// Arrange
            mock.Setup(_ => _.GetCityDetailById(1)).ReturnsAsync(MockData.GetAllCities()[0]);
            var city = new CityController(logger, mock.Object);

            /// Act
            var result = (OkObjectResult)await city.GetCity(1);


            // Assert
            result.StatusCode.Should().Be(200);
        }

        #endregion

        #region Save City Detail


        [Fact]
        public async Task SaveAsync_ShouldCall_ICityDetailRepo_SaveAsync_AtleastOnce()
        {
            /// Arrange
            var newTodo = MockData.NewCity();
            var city = new CityController(logger, mock.Object);

            /// Act
            var result = await city.AddCity(newTodo);

            /// Assert
            mock.Verify(_ => _.AddCityDetail(newTodo), Times.Exactly(1));
        }
        #endregion

        #region Delete City Detail by Id

        [Fact]
        public async Task DeleteCityDetailById_Async_ShouldReturn200Status()
        {
            /// Arrange
            var city = new CityController(logger, mock.Object);

            /// Act
            var result = await city.DeleteCity(1);

            /// Assert
            mock.Verify(_ => _.DeleteCityDetail(1), Times.Exactly(1));
        }

        #endregion

        #region Update City Detail


        [Fact]
        public async Task UpdateAsync_ShouldCall_ICityDetailRepo_SaveAsync_AtleastOnce()
        {
            // Arrange
             var newTodo = MockData.NewCity();
            var city = new CityController(logger, mock.Object);

            // Act
            var result = await city.UpdateCity(newTodo);

            // Assert
            mock.Verify(_ => _.UpdateCityDetail(newTodo), Times.Exactly(1));
        }
        #endregion

    }
}