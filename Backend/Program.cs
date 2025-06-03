using System.Text;
using Backend.Business;
using Backend.Data;
using Backend.Mapper;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Permission;
using Backend.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor(); // dependency for images
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EMSDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
);
//automapper dependency injection

builder.Services.AddAutoMapper(typeof(AutoMapperEMS));
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "NZ Walks Title", Version = "v1" });
        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },
                    Scheme = "Oauth2",
                    Name = "Authorization",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
    }
);

// configure redis connection strings from json file
// builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
// {
//     var redisConnectionString = builder.Configuration["Redis:ConnectionString"];
//     return ConnectionMultiplexer.Connect(redisConnectionString);
// });

// // add redis distributed cache to DI container
// builder.Services.AddStackExchangeRedisCache(Options =>
// {
//     Options.Configuration = builder.Configuration["Redis:ConnectionString"];
//     Options.InstanceName = "EMS";
// });

// add scoped
builder.Services.AddScoped<IAuth, AuthRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IJobRoleService, JobRoleService>();
builder.Services.AddScoped<IJWToken, JWTokenRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IAssetType, AssetTypeService>();
builder.Services.AddScoped<ISalaryStructure, SalaryStructureService>();
builder.Services.AddScoped<IContactDetails, ContactDetailsService>();
builder.Services.AddScoped<IAssetType, AssetTypeService>();
builder.Services.AddScoped<IFamilyService, FamilyDetailService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<ILeaveBalanceService, LeaveBalanceService>();
// builder.Services.AddScoped<I>();
builder.Services.AddDataProtection();


// Identity user
builder.Services.AddIdentityCore<IdentityUser>() // identityUser
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("EMS")
    .AddEntityFrameworkStores<EMSDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
}

);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    }
    );

builder.Services.AddAuthorization(options =>
{
    var permissionType = typeof(Permission);
    var permissions = permissionType.GetNestedTypes()
        .SelectMany(nested => nested.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy))
        .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
        .Select(fi => (string)fi.GetRawConstantValue())
        .ToList();
    options.AddPolicy("CreateUpdateEmployeeEducation", policy =>
                 policy.RequireAssertion(context =>
                    context.User.HasClaim("Permission", "Employee.Education.Create") ||
                    context.User.HasClaim("Permission","Employee.Education.Update")
                 ));
    foreach (var permission in permissions)
    {
        if (permission == "Employee.Education.Create" || permission == "Employee.Education.Update")
        {
            continue;   
        }
        options.AddPolicy(permission, policy => policy.RequireClaim("Permission", permission));
    }
}
);

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("ReactPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
