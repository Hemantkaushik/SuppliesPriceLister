﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuppliesPriceLister.DataManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace buildxact_supplies
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigurationSetting>(Configuration.GetSection("Settings"));
            services.AddAutoMapper(cfg => { cfg.AddProfile(new DataManagerProfile()); }, typeof(DataManagerProfile));
            services.AddAutoMapper(cfg => { cfg.AddProfile(new ServiceProfile()); }, typeof(ServiceProfile));
        }
    }
}
