using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                string logpath = @"./Logs/logs.txt";
                if (!File.Exists(logpath))
                {
                    File.Create(logpath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(logpath))
                {
                    sw.WriteLine("Error logging");
                    sw.WriteLine("Start" + DateTime.Now);
                    sw.WriteLine("Error message: " + ex.Message);
                    sw.WriteLine("Stack Trace: " + ex.StackTrace);
                    sw.WriteLine("End" + DateTime.Now);
                }
            }
            
        }
    }
}
