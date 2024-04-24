using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamestoolkit.tests.Functional
{
    public class BaseFunctionalTest
    {
        protected readonly WebCustomFactory<Program> _factory;
        protected readonly HttpClient _client;

        public BaseFunctionalTest()
        {
            _factory = new WebCustomFactory<Program>();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
