﻿using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;

namespace PseudoRMI_DatabaseServer
{
    public class DatabaseServer
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.WebHost.UseUrls("http://192.168.50.183:8080");
            builder.WebHost.UseUrls("http://localhost:8080");

            builder.Services.AddServiceModelServices();
            builder.Services.AddServiceModelMetadata();

            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

            var app = builder.Build();

            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<DatabaseService>();

                serviceBuilder.AddServiceEndpoint<DatabaseService, IDatabaseService>(
                    new BasicHttpBinding(),
                    "/DatabaseService"
                );

                var metadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
                metadataBehavior.HttpGetEnabled = true;
                metadataBehavior.HttpsGetEnabled = false;
                metadataBehavior.HttpGetUrl = new Uri("http://192.168.50.183:8080/DatabaseService/mex");
            });

            app.Run();
        }
    }
}