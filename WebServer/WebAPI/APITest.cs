using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebServer.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class APITest : ControllerBase
    {
        [HttpGet]
        public string Test()
        {
            return "test success";
        }
        [HttpGet("urltest")]
        public string Get()
        {
            return "urltest";
        }
        [HttpGet("{id}")]
        public string Geta()
        {
            return "urltest";
        }
        [HttpGet("{n}")]
        public string Getb(string s)
        {
            return s;
        }
        [HttpPost("post")]
        public string Info()
        {
            return "Post info";
        }
    }
}
