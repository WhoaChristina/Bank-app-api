using BankApp.Api.Repos.Interfaces;
using BankApp.Api.Repos;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Services;
using BankApp.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<BankAppDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IAccountTypeService, AccountTypeService>();
builder.Services.AddTransient<ILoanService, LoanService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDispositionService, DispositionService>();

builder.Services.AddTransient<IAccountTypeRepo, AccountTypeRepo>();
builder.Services.AddTransient<ILoanRepo, LoanRepo>();
builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();
builder.Services.AddTransient<IAccountRepo, AccountRepo>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<IDispositionRepo, DispositionRepo>();

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
