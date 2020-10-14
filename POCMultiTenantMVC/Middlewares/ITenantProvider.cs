using POCMultiTenantMVC.Models;

namespace POCMultiTenantMVC.Middlewares
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
