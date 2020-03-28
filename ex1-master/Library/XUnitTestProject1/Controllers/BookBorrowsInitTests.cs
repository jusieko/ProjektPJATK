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
    public class BookBorrowsInitTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
     

        public BookBorrowsInitTests()
        {
            _server = ServerFactory.GetServerInstance();
            _client = _server.CreateClient();


            using (var scope = _server.Host.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();



                _db.User.Add(new User
                {
                    IdUser = 4,
                    Email = "abc@abc.pl",
                    Name = "Janek",
                    Surname = "Osiecki",
                    Login = "jo",
                    Password = "haslo"
                });



                _db.BookBorrow.Add(new BookBorrow


                {   
                    IdUser=1,
                    IdBook= 1,
                    Comments="String1"
                    
                    
                });

               
                _db.SaveChanges();
            }
        }




        

        [Fact]
        public async Task PostBookBorrow_201Ok()
        {
            //Arrange i Act

            string payload = JsonConvert.SerializeObject(new
            {


                IdUser = 1,
                IdBook = 2,
                Comments = "String2"
            });

            var client = new HttpClient();
            var cont = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync($"{_client.BaseAddress.AbsoluteUri}api/book-borrows", cont);
            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();
            var bookBorrow = JsonConvert.DeserializeObject<BookBorrow>(content);
            // using (var scope = _server.Host.Services.CreateScope())
            // {
            //     var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            //     Assert.True(_db.User.Any());
            // }


            Assert.False(bookBorrow.IdBook== 1);
        }

        [Fact]
        public async Task PutBookBorrow_200Ok()
        {
            //Arrange i Act

            string payload = JsonConvert.SerializeObject(new
            {

                IdBook = 0,
                IdUser = 0,
                DateFrom = "2020-03-20T19:31:40.082Z",
                DateTo = "2020-03-20T19:31:40.082Z",
                Comments = "string"
            });

            var client = new HttpClient();
            var cont = new StringContent(payload, Encoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync($"{_client.BaseAddress.AbsoluteUri}api/book-borrows/4", cont);
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var bookBorrow = JsonConvert.DeserializeObject<BookBorrow>(content);
            // using (var scope = _server.Host.Services.CreateScope())
            // {
            //     var _db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            //     Assert.True(_db.User.Any());
            // }

            Assert.True(httpResponse.StatusCode == HttpStatusCode.OK);
        }





    }



    }

