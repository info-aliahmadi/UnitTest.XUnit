using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using XUnit.Api.Controllers;
using XUnit.Infrastructure;
using XUnit.Service.Models;

namespace Nitro.Web.Test.Cms
{
    public class AuthorControllerTests : IClassFixture<ApiWebApplicationFactory>
    {
        readonly Fixture fixture;
        readonly AuthorController authorController;
        public AuthorControllerTests()
        {
            //Arrange
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            authorController = fixture.Build<AuthorController>().OmitAutoProperties().Create();
        }

        [Fact]
        public async void GET_retrieves_authors()
        {

            //Arrange
            var expectedList = fixture.Create<ActionResult<IEnumerable<AuthorModel>>>();


            //Act
            var resultList = await authorController.GetAuthors();

            //Assert
            resultList.Should().BeOfType<ActionResult<IEnumerable<AuthorModel>>>();
        }
        [Theory]
        [InlineData(0)]
        public async void GET_retrieve_author_by_zero(int id)
        {

            //Act
            var resultList = await authorController.GetAuthor(id);

            //Assert
            resultList.Should().BeOfType<NotFoundResult>();
        }
        [Theory]
        [InlineData(1)]
        public async void GET_retrieve_author_by_id(int id)
        {

            //Act
            var resultList = await authorController.GetAuthor(id);

            //Assert
            resultList.Should().BeOfType<OkObjectResult>();
        }
        [Theory, AutoData]
        public async void POST_add_author(AuthorModel authorModel)
        {

            //Act
            var resultList = await authorController.Add(authorModel);

            //Assert
            resultList.Should().BeOfType<OkObjectResult>();
        }
        [Theory, AutoData]
        public async void POST_update_author(AuthorModel authorModel)
        {

            //Act
            var resultList = await authorController.Update(authorModel);

            //Assert
            resultList.Should().BeOfType<ActionResult<AuthorModel>>();
        }
        [Theory, AutoData]
        public async void POST_delete_author(int authorId)
        {

            //Act
            var resultList = await authorController.Delete(authorId);

            //Assert
            resultList.Should().BeOfType<ActionResult<bool>>();
        }
    }
}