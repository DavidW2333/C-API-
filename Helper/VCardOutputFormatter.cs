using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS335_A1.Dtos;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CS335_A1.Helper
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            StaffOutDtos card = (StaffOutDtos)context.Object;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:4.0");
            builder.Append("FN:").AppendLine(card.LastName + card.FirstName);
            builder.Append("UID:").AppendLine(card.Id + "");
            builder.Append("CATEGORIES:").AppendLine(card.Research);
            //builder.Append("PHOTO;ENCODING=BASE64;TYPE=").Append(card.PhotoType).Append(":").AppendLine(card.);
            builder.AppendLine("END:VCARD");
            string outString = builder.ToString();
            byte[] outBytes = selectedEncoding.GetBytes(outString);
            var response = context.HttpContext.Response.Body;
            return response.WriteAsync(outBytes, 0, outBytes.Length);
        }
    }
}
