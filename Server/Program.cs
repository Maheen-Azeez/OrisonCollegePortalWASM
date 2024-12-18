using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using OrisonCollegePortal.Server.Contracts.General;
using OrisonCollegePortal.Server.Concretes.General;
using OrisonCollegePortal.Server.Controllers.General;
using OrisonCollegePortal.Server.Entities;
using OrisonCollegePortal.Server.Contracts;
using OrisonCollegePortal.Server.Concretes;
using OrisonCollegePortal.Server.Controllers;
using OrisonCollegePortal.Controller;
using OrisonCollegePortal.Server.Concretes.Finance;
using OrisonCollegePortal.Server.Contracts.Finance;
using OrisonCollegePortal.Server.Concrete.Students;
using OrisonCollegePortal.Server.Concretes.Inventory;
using OrisonCollegePortal.Server.Contracts.Inventory;
using OrisonCollegePortal.Server.Contracts.BoldReport;
using OrisonCollegePortal.Server.Concretes.BoldReport;
using OrisonCollegePortal.Server.Contracts.PaymentLink;
using OrisonCollegePortal.Server.Concretes.PaymentLink;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddTransient<IDapperManager, DapperManager>();
builder.Services.AddTransient<IUserLoginManager, UserLoginManager>();
builder.Services.AddTransient<IUserRightsManager, UserRightsManager>();
builder.Services.AddTransient<IDBOperation, DBOperation>();
builder.Services.AddTransient<IStudentManager, StudentManager>();
builder.Services.AddTransient<IDocImageEntry, DocImageEntry>();
builder.Services.AddTransient<IDocumentEntry, DocumentEntry>();
builder.Services.AddTransient<IDocumentManager, DocumentManager>();
builder.Services.AddTransient<IFeeManager, FeeManager>();
builder.Services.AddTransient<IFeePostingManager, FeePostingManager>();
builder.Services.AddTransient<IVoucherEntryManager, VoucherEntryManager>();
builder.Services.AddTransient<IStudentMainManager, StudentMainManager>();
builder.Services.AddTransient<IParentManager, ParentManager>();
builder.Services.AddTransient<IStudentTransManager, StudentTransManager>();
builder.Services.AddTransient<IMiscellaneousMasterManager, MiscellaneousMasterManager>();
builder.Services.AddTransient<IAccountManager, AccountManager>();
builder.Services.AddTransient<IPostingManager, PostingManager>();
builder.Services.AddTransient<IDocumentImageEntry,DocumentImageEntry>();
builder.Services.AddTransient<IDocumentsEntry,DocumentsEntry>();
builder.Services.AddTransient<IImageEntry,ImageEntry>();
builder.Services.AddTransient<IInvAccounts,InvAccountsManager>();
builder.Services.AddTransient<IInvoiceRegisterManager,InvoiceRegisterManager>();
builder.Services.AddTransient<INoteEntry,NoteEntry>();
builder.Services.AddTransient<IParentEntry,ParentEntry>();
builder.Services.AddTransient<IParentAccEntry, ParentAccEntry>();
builder.Services.AddTransient<IRelationEntry,RelationEntry>();
builder.Services.AddTransient<IStudentAccEntry,StudentAccEntry>();
builder.Services.AddTransient<IStudentArabicEntry,StudentArabicEntry>();
builder.Services.AddTransient<IStudentEntry,StudentEntry>();
builder.Services.AddTransient<IStudentFeeManager,StudentFeeManager>();
builder.Services.AddTransient<IStudentMaster,StudentMaster>();
builder.Services.AddTransient<IStudentTranEntry,StudentTranEntry>();
builder.Services.AddTransient<IVoucherAllocationManagers,VoucherAllocationManagers>();
builder.Services.AddTransient<IVoucherManager,VoucherManager>();
builder.Services.AddTransient<IClassMaster, ClassMasterManager>();
builder.Services.AddTransient<IUserTrack, UserTrackEntry>();
builder.Services.AddTransient<IBoldReportManager, BoldReportManager>();
builder.Services.AddTransient<ISchoolTaxInvoiceManager, SchoolTaxInvoiceManager>();
builder.Services.AddTransient<IInvVoucherManager, InvVoucherManager>();
builder.Services.AddTransient<IAdditionalFeeMaster,AdditionalFeeMaster>();
builder.Services.AddTransient<IAdditionalPayment,AdditionalPaymentMaster>();
builder.Services.AddTransient<IDiscountManager,DiscountManager>();
builder.Services.AddTransient<IFeeMaster,FeeMaster>();
builder.Services.AddTransient<IFeeSchedule,FeeSchedule>();
builder.Services.AddTransient<ILinkGeneration,LinkGeneration>();
builder.Services.AddTransient<IShortCutManager,ShortCutManager>();
builder.Services.AddTransient<UploadController>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
