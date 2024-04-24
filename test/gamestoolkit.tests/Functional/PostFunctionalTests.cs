using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gamestoolkit.tests.Functional
{
    public class PostFunctionalTests : BaseFunctionalTest
    {
        const string ENDPOINT = "/api/posts";

        [Fact]
        public async Task GetByUsername_UnexistingUser_ReturnsError()
        {
            // Execute
            var response = await _client.GetAsync(
                $"{ ENDPOINT }/101");
            var content = await response.Content.ReadAsStringAsync();

            // Check
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
