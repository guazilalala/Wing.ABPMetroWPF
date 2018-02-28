﻿using Abp.AspNetCore.Mvc.Controllers;
using Abp.Auditing;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Install;
using MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host;
using MyCompanyName.AbpZeroTemplate.Web.Models.Install;

namespace MyCompanyName.AbpZeroTemplate.Web.Controllers
{
    [DisableAuditing]
    public class InstallController : AbpController
    {
        private readonly IInstallAppService _installAppService;
        private readonly IApplicationLifetime _applicationLifetime;

        public InstallController(
            IInstallAppService installAppService, 
            IApplicationLifetime applicationLifetime)
        {
            _installAppService = installAppService;
            _applicationLifetime = applicationLifetime;
        }

        [UnitOfWork(IsDisabled = true)]
        public ActionResult Index()
        {
            var appSettings = _installAppService.GetAppSettingsJson();

            if (DatabaseCheckHelper.Exist(appSettings.ConnectionString))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new InstallViewModel
            {
                Languages = DefaultLanguagesCreator.InitialLanguages,
                AppSettingsJson = appSettings
            };
            
            return View(model);
        }

        public ActionResult Restart()
        {
            _applicationLifetime.StopApplication();
            return View();
        }
    }
}