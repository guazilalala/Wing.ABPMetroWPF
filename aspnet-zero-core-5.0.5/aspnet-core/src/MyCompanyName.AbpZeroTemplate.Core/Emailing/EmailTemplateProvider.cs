﻿using System.Text;
using Abp.Dependency;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Reflection.Extensions;
using MyCompanyName.AbpZeroTemplate.Url;

namespace MyCompanyName.AbpZeroTemplate.Emailing
{
    public class EmailTemplateProvider : IEmailTemplateProvider, ITransientDependency
    {
        private readonly IWebUrlService _webUrlService;

        public EmailTemplateProvider(
            IWebUrlService webUrlService)
        {
            _webUrlService = webUrlService;
        }

        public string GetDefaultTemplate(int? tenantId)
        {
            using (var stream = typeof(EmailTemplateProvider).GetAssembly().GetManifestResourceStream("MyCompanyName.AbpZeroTemplate.Emailing.EmailTemplates.default.html"))
            {
                var bytes = stream.GetAllBytes();
                var template = Encoding.UTF8.GetString(bytes, 3, bytes.Length - 3);
                return template.Replace("{EMAIL_LOGO_URL}", GetTenantLogoUrl(tenantId));
            }
        }

        private string GetTenantLogoUrl(int? tenantId)
        {
            if (!tenantId.HasValue)
            {
                return _webUrlService.GetServerRootAddress().EnsureEndsWith('/') + "TenantCustomization/GetTenantLogo?skin=light";
            }

            return _webUrlService.GetServerRootAddress().EnsureEndsWith('/') + "TenantCustomization/GetTenantLogo?skin=light&tenantId=" + tenantId.Value;
        }
    }
}