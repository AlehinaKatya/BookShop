using System.Net;
using BookShop.BL.Auth.Entities;
using BookShop.DataAccess;
using BookShop.DataAccess.Entities;
using FluentAssertions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BookShop.WebAPI.UnitTests.Customers.Authorization
{
    public class LoginCustomerTests : BookShopWebAPITestsBaseClass
    {
        [Test]
        public async Task SuccessFullResult()
        {
            var user = new CustomerEntity()
            {
                UserName = "test@test",
                Surname = "Test",
                Name = "Test",
                Patronymic = "Test",
                PhoneNumber = "Test",
                Email = "test@test",
                PasswordHash = "Test",
                DateOfBith = new DateTime(2000, 1, 1),
                PersonalisedDiscount = 9
            };
            var password = "Password1@";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CustomerEntity>>();
            var result = await userManager.CreateAsync(user, password);

            //execute
            var query = $"?email={user.UserName}&password={password}";
            var requestUri =
                BookShopApiEndpoints.AuthorizeCustomerEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            var responseContentJson = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<TokensResponse>(responseContentJson);

            content.Should().NotBeNull();
            content.AccessToken.Should().NotBeNull();
            content.RefreshToken.Should().NotBeNull();


            var requestToGetAllProducts =
                new HttpRequestMessage(HttpMethod.Get, BookShopApiEndpoints.GetAllProductsEndpoint);

            var clientWithToken = TestHttpClient;
            client.SetBearerToken(content.AccessToken);
            var getAllCustomersResponse = await client.SendAsync(requestToGetAllProducts);

            getAllCustomersResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task BadRequestUserNotFoundResultTest()
        {
            // prepare: (imagine_login, imagine_password) => execute (try to login) => assert (BadRequest user not found)
            //prepare
            var login = "not_existing@mail.ru";
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<CustomerEntity>>();
            var user = userRepository.GetAll().FirstOrDefault(x => x.UserName.ToLower() == login.ToLower());
            if (user != null)
            {
                userRepository.Delete(user);
            }

            var password = "password";
            //100% confidence
            //execute
            var query = $"?email={login}&password={password}";
            var requestUri =
                BookShopApiEndpoints.AuthorizeCustomerEndpoint + query; // /auth/login?login=test@test&password=password
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await TestHttpClient.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task PasswordIsIncorrectResultTest()
        {
            var customer = new CustomerEntity()
            {
                Email = "test@test",
                UserName = "test@test",
            };
            var password = "password";

            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<CustomerEntity>>();
            await userManager.CreateAsync(customer, password);

            var incorrect_password = "kvhdbkvhbk";

            //execute
            var query = $"?email={customer.UserName}&password={incorrect_password}";
            var requestUri =
                BookShopApiEndpoints.AuthorizeCustomerEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }

        [Test]
        [TestCase("", "")]
        [TestCase("qwe", "")]
        [TestCase("test@test", "")]
        [TestCase("", "password")]
        public async Task LoginOrPasswordAreInvalidResultTest(string login, string password)
        {
            //execute
            var query = $"?login={login}&password={password}";
            var requestUri =
                BookShopApiEndpoints.AuthorizeCustomerEndpoint + query; // /auth/login?login=test@test&password=kvhdbkvhbk
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var client = TestHttpClient;
            var response = await client.SendAsync(request);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest); // with some message
        }

    }
}
