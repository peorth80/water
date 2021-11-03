using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Water.API
{
	public class Startup
	{
		readonly string CORSPolicy = "AlwaysAllow";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			//we need to add the CORS logic so we can call the API from React
			services.AddCors(options =>
			{
				options.AddPolicy(name: CORSPolicy,
								  builder =>
								  {
									  builder.WithOrigins("http://localhost:3000",
														  "https://localhost:3000");
								  });
			});

			services.AddControllers();

			services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
			services.AddAWSService<IAmazonDynamoDB>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(CORSPolicy);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
