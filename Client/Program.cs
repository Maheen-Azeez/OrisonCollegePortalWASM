using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OrisonCollegePortal.Client;
using OrisonCollegePortal.Client.Contracts;
using OrisonCollegePortal.Client.Concretes;
using OrisonCollegePortal.Client.Services;
using OrisonCollegePortal.Client.Shared;
using Syncfusion.Blazor;
using Microsoft.JSInterop;
using System.Globalization;
using OrisonCollegePortal.Client.Contracts.Finance;
using OrisonCollegePortal.Client.Logics.Concrete.Students;
using OrisonCollegePortal.Client.Concretes.Finance;
using OrisonCollegePortal.Client.Concretes.BoldReport;
using OrisonCollegePortal.Client.Contracts.BoldReport;
using OrisonCollegePortal.Client.Contracts.PaymentLink;
using OrisonCollegePortal.Client.Concretes.PaymentLink;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjg4MTM1NEAzMjMzMmUzMDJlMzBqRmVQakZoOElPUTRIeVZMUzdYdkxnVnlHSFJPdkdZNkxFc3FDeGhVYXB3PQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Package Services
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredSessionStorage();
//Package Services

//For Arabic Language
builder.Services.AddLocalization();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
var host = builder.Build();

var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
CultureInfo culture;
if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await jsInterop.InvokeVoidAsync("cultureInfo.set", "en-US");
}
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
//For Arabic Language



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddTransient<IUserLoginManager, UserLoginManager>();
builder.Services.AddTransient<IStudentManager, StudentManager>();
builder.Services.AddTransient<IMiscellaneousMasterManager, MiscellaneousMasterManager>();
builder.Services.AddTransient<IDocumentManager, DocumentManager>();
builder.Services.AddTransient<IFeePostingManager, FeePostingManager>();
builder.Services.AddTransient<IClassMaster, ClassMaster>();
builder.Services.AddTransient<IInvAccounts, InvAccountsManager>();
builder.Services.AddTransient<IInvoiceRegisterManager,InvoiceRegisterManager>();
builder.Services.AddTransient<IPostingManager, PostingManager>();
builder.Services.AddTransient<IStudentFeeManager,StudentFeeManager>();
builder.Services.AddTransient<IStudentMaster, StudentMaster>();
builder.Services.AddTransient<IVoucherAllocationManagers, VoucherAllocationManagers>();
builder.Services.AddTransient<IBoldReportManager, BoldReportManager>();
builder.Services.AddTransient<ISchoolTaxInvoiceManager, SchoolTaxInvoiceManager>();
builder.Services.AddTransient<IAdditionalFeeMaster, AdditionalFeeMaster >();
builder.Services.AddTransient<IAdditionalPayment,AdditionalPaymentMaster>();
builder.Services.AddTransient<IDiscountManager,DiscountManager>();
builder.Services.AddTransient<IFeeMaster,FeeMaster>();
builder.Services.AddTransient<IFeeSchedule,FeeSchedule>();
builder.Services.AddTransient<ILinkGeneration,LinkGeneration>();
builder.Services.AddTransient<IShortCutsManager,ShortCutsManager>();

builder.Services.AddScoped<GeneralServices>();
builder.Services.AddScoped<GlobalStudentService>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<CacheVersionService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<UserRightsService>();
builder.Services.AddScoped<AmountInWords>();
builder.Services.AddScoped<clsDBOperationService>();
builder.Services.AddScoped<SendMailService>();
builder.Services.AddScoped<PaymentService>();

await builder.Build().RunAsync();
