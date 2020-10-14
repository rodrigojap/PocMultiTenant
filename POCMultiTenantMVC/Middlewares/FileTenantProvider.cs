using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using POCMultiTenantMVC.Extensions;
using POCMultiTenantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCMultiTenantMVC.Middlewares
{
    public class FileTenantProvider : ITenantProvider
    {
        private Tenant _tenant;

        public FileTenantProvider(IHttpContextAccessor accessor)
        {            
            var currentRequest = accessor?.HttpContext?.Request;
            var uriRequest = new Uri(currentRequest.GetDisplayUrl());
            var subDomain = uriRequest.GetSubDomainFromDNS();

            SetTenant(subDomain, uriRequest.Host);             
        }

        private void SetTenant(string subDomain, string host)
        {
            var existingTenant = this.GetTenantsList().FirstOrDefault(t => t.Value.Equals(subDomain));

            if (existingTenant == null)
            {                
                _tenant = new Tenant { Description = $"Dominio não cadastrado! Voce está num sei onde [{subDomain}]", BackGroundColor = "", Host = host };
                return;
            }

            _tenant = existingTenant;
            _tenant.Host = host;
        }

        public Tenant GetTenant()
        {
            return _tenant;
        }        

        public List<Tenant> GetTenantsList()
        {
            return new List<Tenant>
            {
                new Tenant { Value = "principal", Description = "Vc está no dominio principal da loja!", BackGroundColor = "red"},
                new Tenant { Value = "loja1", Description = "Vc está em um subdominio loja1!", BackGroundColor = "green"},
                new Tenant { Value = "loja2", Description = "Vc está em um subdominio loja2!", BackGroundColor = "blue"},
                new Tenant { Value = "suporte", Description = "Vc está em um subdominio de fazendodeploy!", BackGroundColor = "black"},
                new Tenant { Value = "localhost", Description = "Vc está no localhost!", BackGroundColor = "black"}
            };
        }
    }
}
