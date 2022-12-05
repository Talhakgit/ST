using Autofac;

using Autofac.Extensions.DependencyInjection;


using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;

using Core.Utilities.Security.Jwt;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();





builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));



builder.Services.AddCors(p => p.AddPolicy("AllowOrigin", builder =>

{

    builder.WithOrigins("https://localhost:***").AllowAnyMethod().AllowAnyHeader(); // yýldýzlar yerine kendi localhost adresinizi girin örnek: "https://localhost:1111"

}));

var Configuration = builder.Configuration;

var tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();

object value = builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>

{

    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters

    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidIssuer = tokenOptions.Issuer,

        ValidAudience = tokenOptions.Audience,

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)



    };




var app = builder.Build();





// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}



app.UseCors("AllowOrigin");

app.UseHttpsRedirection();



app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();



app.Run();