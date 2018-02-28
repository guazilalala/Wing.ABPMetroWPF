﻿using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

        private readonly AbpZeroTemplateDbContext _context;

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            var tenantId = AbpZeroTemplateConsts.MultiTenancyEnabled ? null : (int?)1;
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(tenantId, "en", "English", "famfamfam-flags gb"),
                new ApplicationLanguage(tenantId, "ar", "العربية", "famfamfam-flags sa"),
                new ApplicationLanguage(tenantId, "de", "Deutsch", "famfamfam-flags de"),
                new ApplicationLanguage(tenantId, "it", "Italiano", "famfamfam-flags it"),
                new ApplicationLanguage(tenantId, "fr", "Français", "famfamfam-flags fr"),
                new ApplicationLanguage(tenantId, "pt-BR", "Português (Brasil)", "famfamfam-flags br"),
                new ApplicationLanguage(tenantId, "tr", "Türkçe", "famfamfam-flags tr"),
                new ApplicationLanguage(tenantId, "ru", "Pусский", "famfamfam-flags ru"),
                new ApplicationLanguage(tenantId, "zh-CN", "简体中文", "famfamfam-flags cn"),
                new ApplicationLanguage(tenantId, "es-MX", "Español (México)", "famfamfam-flags mx"),
                new ApplicationLanguage(tenantId, "es", "Español (Spanish)", "famfamfam-flags es")
            };
        }

        public DefaultLanguagesCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);

            _context.SaveChanges();
        }
    }
}