using _26_BuiVanToan_Slot6.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace _26_BuiVanToan_Slot6.CustomFomatters
{

    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/cvs"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        =>typeof(Blog).IsAssignableFrom(type)|| typeof(IEnumerable<Blog>).IsAssignableFrom(type);
        
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
             var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<Blog>) {
            foreach(var Blog in(IEnumerable<Blog>)context.Object) {
                    FormatCsv(buffer, Blog);
                }
            }
            else
            {
                FormatCsv(buffer,(Blog)context.Object);
            }
            return Task.CompletedTask;
        }

        private void FormatCsv(StringBuilder buffer, Blog blog)
        {
            throw new NotImplementedException();
        }
    }






}
