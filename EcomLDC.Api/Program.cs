using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Orders;
using EcomLDC.Application.Interfaces.Products;
using EcomLDC.Application.Interfaces.Users;
using EcomLDC.Application.Security;
using EcomLDC.Application.UseCases.Carts.Commands.Update;
using EcomLDC.Application.UseCases.Carts.Query;
using EcomLDC.Application.UseCases.Users.Login;
using EcomLDC.Application.UseCases.Users.Register;  //34an awsil lel Validators/Commands 34an a3ml register lel user
using EcomLDC.Application.UseCases.Users.Register.Commands;
using EcomLDC.Infrastructure;
using EcomLDC.Infrastructure.Persistence;
using EcomLDC.Infrastructure.Repositories.Orders;
using EcomLDC.Infrastructure.Repositories.Products;
using EcomLDC.Infrastructure.Repositories.Users;
using EcomLDC.Infrastructure.Security;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore; // Add this using directive at the top of the file
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DbContext (المigrations في Infrastructure)
builder.Services.AddDbContext<EcomLDCDbContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("Default") ??
        "Server=.;Database=EcomLDC;Trusted_Connection=True;TrustServerCertificate=True",
        b => b.MigrationsAssembly(typeof(EcomLDCDbContext).Assembly.FullName))); //34an awsil lel EcomLDCDbContext (hya el DbContext bta3t al project w mwgoda fl Infrastructure)

// MediatR 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly)); //34an awsil lel Handlers (RegisterUserCommandHandler, LoginUserQueryHandler)
// MediatR + Validators 
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetMyCartQuery).Assembly)); //34an awsil lel Handlers (GetMyCartHandler) 
builder.Services.AddValidatorsFromAssembly(typeof(UpdateCartItemQtyValidator).Assembly); //34an awsil lel Validators (UpdateCartItemQtyValidator)


// FluentValidation 
builder.Services.AddFluentValidationAutoValidation(); //34an a3ml auto validation lel requests (Commands, Queries)
builder.Services.AddValidatorsFromAssembly(typeof(RegisterUserCommand).Assembly); //34an awsil lel Validators (RegisterUserCommandValidator, LoginUserQueryValidator)

// Infrastructure implementations
builder.Services.AddScoped<IUserRepository, UserRepository>(); //34an awsil lel UserRepository (implementation bta3t IUserRepository)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //34an awsil lel UnitOfWork (implementation bta3t IUnitOfWork)
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>(); //34an awsil lel BcryptPasswordHasher (implementation bta3t IPasswordHasher)
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>(); //34an awsil lel JwtTokenService (implementation bta3t IJwtTokenService)
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //34an awsil lel ProductRepository (implementation bta3t IProductRepository)
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); //34an awsil lel OrderRepository (implementation bta3t IOrderRepository)

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddAuthorization();
//  Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
