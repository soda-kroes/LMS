#pragma checksum "D:\SODA.IT\Rupp_Y3\Project\LMS-Csharp\Views\AdminDash\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "182f67cf5a91f1b2863bc6e5760a8d15c9bbe7cfbbf6843c5998e804af294db9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminDash_Index), @"mvc.1.0.view", @"/Views/AdminDash/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\SODA.IT\Rupp_Y3\Project\LMS-Csharp\Views\_ViewImports.cshtml"
using LMS_RUPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SODA.IT\Rupp_Y3\Project\LMS-Csharp\Views\_ViewImports.cshtml"
using LMS_RUPP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"182f67cf5a91f1b2863bc6e5760a8d15c9bbe7cfbbf6843c5998e804af294db9", @"/Views/AdminDash/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"078e39f0fe300daf87b5179286d1dfd745090c4e5c566204fd601bd401e72bf6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_AdminDash_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\SODA.IT\Rupp_Y3\Project\LMS-Csharp\Views\AdminDash\Index.cshtml"
  
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
    ViewData["Title"] = "LoginPage";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""d-sm-flex align-items-center justify-content-between mb-4"">
            <h1 class=""h3 mb-0 text-gray-800"">Dashboard</h1>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-success shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">
                               Borrowed Books
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">200</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fa-solid fa-book fa-2x text-gray-300""></i> 
                        </div>
                    </div>
          ");
            WriteLiteral(@"      </div>
            </div>
        </div>


        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                               Returned Book
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">18</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fa-solid fa-rotate-left fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-info shadow h-100 py-2"">
                <di");
            WriteLiteral(@"v class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-info text-uppercase mb-1"">
                                Total Books
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">18</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fa-solid fa-arrow-up-wide-short fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-danger shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""te");
            WriteLiteral(@"xt-xs font-weight-bold text-danger text-uppercase mb-1"">
                                Pending Request
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">18</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fa-solid fa-hourglass-start fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class=""row mt-2"">
        <div class=""col-md-6"">
            <div class=""calendar calendar-first"" id=""calendar_first"">
                <div class=""calendar_header"">
                    <button class=""switch-month switch-left""> <i class=""fa fa-chevron-left""></i></button>
                    <h2></h2>
                    <button class=""switch-month switch-right""> <i class=""fa fa-chevron-right""></i></button>
                </div>
                <div class=""cal");
            WriteLiteral(@"endar_weekdays""></div>
                <div class=""calendar_content""></div>
            </div>
        </div>
        <div class=""col-md-6"" style=""margin-top:100px;"">
            <a href=""https://logwork.com/current-time-in-phnom-penh-cambodia"" class=""clock-widget-text"" data-timezone=""Asia/Phnom_Penh"" data-language=""en"">Phnom Penh, Cambodia</a>
        </div>


    </div>


</div>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
