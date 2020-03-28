using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Entities;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace XUnitTestProject1.Controllers
{
    public class UsersInitTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;


        public UsersInitTests()
        {
            _server = ServerFactory.GetServerInstance();
            _client = _server.CreateClient();


            using (var scope = _server.Host.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();

                _db.User.Add(new User
                {
                    Email = "abc@a.pl",
                    Name = "Janek",
                    Surname = "safs",
                    Login = "aa",
                    Password = "haslo"
                });

                _db.SaveChanges();
            }
        }


        [Fact]
        public async Task GetUsers_200Ok()
        {
            //Arrange i Act
            var httpResponse = await _client.GetAsync($"{_client.BaseAddress.AbsoluteUri}api/users");

            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(content);
            // using (var scope = _server.Host.Services.CreateScope())
            // {
            //     var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            //     Assert.True(_db.User.Any());
            // }


            Assert.True(users.ElementAt(0).Login == "aa");
        }


        [Fact]
        public async Task GetUser_200Ok()
        {
            //Arrange i Act\


            var httpResponse = await _client.GetAsync($"{_client.BaseAddress.AbsoluteUri}api/users/1");

            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);
            // using (var scope = _server.Host.Services.CreateScope())
            // {
            //     var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            //     Assert.True(_db.User.Any());
            // }
            Assert.True(httpResponse.StatusCode == HttpStatusCode.OK);
            Assert.True(user.Login == "aa");


        }

        [Fact]
        public async Task PostUsers_200Ok()
        {
            //Arrange i Act

            string payload = JsonConvert.SerializeObject(new
            {
                Email = "abc@ada.pl",
                Name = "Janek",
                Surname = "oss",
                Login = "oj",
                Password = "haslo"
            });

            var client = new HttpClient();
            var cont = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync($"{_client.BaseAddress.AbsoluteUri}api/users", cont);

            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);
            // using (var scope = _server.Host.Services.CreateScope())
            // {
            //     var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            //     Assert.True(_db.User.Any());
            // }

            Assert.True(httpResponse.StatusCode == HttpStatusCode.Created);

            Assert.True(user.Name == "Janek");
        }







    }



}

