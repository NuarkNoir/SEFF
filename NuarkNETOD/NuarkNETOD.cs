using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NuarkNETOD
{
    public class NuarkNeToD
    {
        public static bool Forf;

        public static string GetResponse(string uri)
        {
            Forf = false;
            try
            {
                var sb = new StringBuilder();
                var buf = new byte[8192];
                var request = (HttpWebRequest)WebRequest.Create(uri);

                var response = (HttpWebResponse)request.GetResponse();
                var resStream = response.GetResponseStream();
                var count = 0;
                do
                {
                    if (resStream != null) count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        sb.Append(Encoding.UTF8.GetString(buf, 0, count));
                    }
                } while (count > 0);
                return sb.ToString();
            }
            catch (WebException ex)
            {
                Forf = true;
                var webResponse = (HttpWebResponse)ex.Response;
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return "404";
                    case HttpStatusCode.Forbidden:
                        return "403";
                    case HttpStatusCode.BadGateway:
                        return "502";
                }
                throw;
            }
        }
    }
}
