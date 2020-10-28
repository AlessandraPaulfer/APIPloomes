using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using APIPloomes.Models;

namespace APIPloomes
{
    class Program
    {
        static void Main(string[] args)
        {
            var exame = new InterviewPloomes();
            exame.RunInterviewPloomes();

        }
    }

}

