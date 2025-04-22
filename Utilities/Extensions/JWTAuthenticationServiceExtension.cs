using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
	public static class JWTAuthenticationServiceExtension
	{
		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidAudience = configuration["JwtSettings:ValidAudience"],
				ValidIssuer = configuration["JwtSettings:ValidIssuer"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding
					.UTF8.GetBytes(configuration["JwtSettings:Key"])),
				ClockSkew = TimeSpan.Zero
			};


			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

			})
		   .AddJwtBearer(options =>
		   {
			   options.SaveToken = true;
			   options.TokenValidationParameters = tokenValidationParameters;

		   });
		}
	}
}
