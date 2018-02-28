using MyCompanyName.AbpZeroTemplate.Authorization.Accounts.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Models.Account
{
    public class EmailConfirmationViewModel : ActivateEmailInput
    {
        /// <summary>
        /// Tenant id.
        /// </summary>
        public int? TenantId { get; set; }
    }
}