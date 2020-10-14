using System;

namespace POCMultiTenantMVC.Extensions
{
    public static class URIExtensions
    {
        public static string GetSubDomainFromDNS(this Uri uriRequest)
        {
            if (uriRequest == null)
                return "It's not a valid URI";

            if (uriRequest.HostNameType != UriHostNameType.Dns)
                return "It's not a dns Host Type";

            string host = uriRequest.Host;

            var nodes = host.Split('.');
            int startNode = 0;
            if (nodes[0] == "www") startNode = 1;

            return string.Format("{0}", nodes[startNode]);
        }
    }
}
