#pragma checksum "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d49cd4b20c335247b953a8960dfc07e2d44ba6a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Edit), @"mvc.1.0.view", @"/Views/Admin/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\_ViewImports.cshtml"
using Seyu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\_ViewImports.cshtml"
using Seyu.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d49cd4b20c335247b953a8960dfc07e2d44ba6a6", @"/Views/Admin/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3b982110f2fc16963c2ae8240e8852c72afd105", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Laptop>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex position-absolute top-50 start-50 translate-middle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
 using (Html.BeginForm("Edit", "Admin", FormMethod.Post))
{




#line default
#line hidden
#nullable disable
            WriteLiteral("    <html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d49cd4b20c335247b953a8960dfc07e2d44ba6a66018", async() => {
                WriteLiteral("\r\n        <meta charset=\"utf-8\" />\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n        <title>");
#nullable restore
#line 11 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - SeYu</title>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d49cd4b20c335247b953a8960dfc07e2d44ba6a66655", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d49cd4b20c335247b953a8960dfc07e2d44ba6a67837", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi"" crossorigin=""anonymous"">
        <style>
            .flexbox-container {
                display: flex;
                /*align-items:center;*/
                align-items: stretch;
            }

            .box-1 {
                width: 280px;
            }

            .box-2 {
                width: max-content;
                flex-grow: 1;
            }
        </style>



    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d49cd4b20c335247b953a8960dfc07e2d44ba6a610333", async() => {
                WriteLiteral("\r\n        <nav class=\"navbar navbar-expand-lg bg-light\">\r\n            <div class=\"container-fluid\">\r\n                <a class=\"navbar-brand\"");
                BeginWriteAttribute("href", " href=\'", 1230, "\'", 1265, 1);
#nullable restore
#line 38 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 1237, Url.Action("Index", "Home"), 1237, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Seyu</a>
                <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#navbarSupportedContent"" aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                    <span class=""navbar-toggler-icon""></span>
                </button>
                <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d49cd4b20c335247b953a8960dfc07e2d44ba6a611557", async() => {
                    WriteLiteral(@"
                        <input class=""form-control me-2"" name=""search"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                        <button class=""btn btn-outline-success"" type=""submit"" name=""submitButton"" value=""Search"">Search</button>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                  \r\n                </div>\r\n            </div>\r\n        </nav>\r\n        <div class=\"flexbox-container\">\r\n            <div class=\"flexbox-item box-1 d-flex flex-column flex-shrink-0 p-3 bg-light\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d49cd4b20c335247b953a8960dfc07e2d44ba6a613775", async() => {
                    WriteLiteral(@"
                    <ul class=""nav nav-pills flex-column mb-auto"">
                     
                        <hr>
                        <li class=""text-center"">

                           
                            <a class=""btn btn active""");
                    BeginWriteAttribute("href", "  href=\'", 2588, "\'", 2623, 1);
#nullable restore
#line 60 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 2596, Url.Action("Add", "Admin"), 2596, 27, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@">Add Computer</a>
                        </li>
                        <br />
                        <li class=""text-center"">
                            <!-- web scrabing butonu burda-->
                            <button class=""btn btn active"" type=""submit"" name=""submitButton"" value=""WebScraping"">Web Scrabing</button>
                           
                        </li>

                    </ul>
                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <div class=\"flexbox-item box-2\" style=\"width:1500px;\">\r\n                <ul class=\"nav nav-pills flex-column mb-auto\">\r\n");
#nullable restore
#line 74 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                            <div class=\"card mb-3\">\r\n                                <div class=\"row g-0\">\r\n                                    <div class=\"col-md-4\">\r\n\r\n\r\n                                        <img");
                BeginWriteAttribute("src", " src=\"", 3540, "\"", 3557, 1);
#nullable restore
#line 82 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 3546, item.Resim, 3546, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""img-fluid rounded-start"" alt=""..."">
                                    </div>
                                    <div class=""col-md-8"">
                                        <div class=""card-body"">
                                            <h2>");
#nullable restore
#line 86 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                           Write(item.Marka);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n                                            <a class=\"card-title\"");
                BeginWriteAttribute("href", " href=\'", 3903, "\'", 3970, 1);
#nullable restore
#line 87 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 3910, Url.Action("Index", "Detail", new { baslik = item.Baslik }), 3910, 60, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 87 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                                                                                                 Write(item.Baslik);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </a>\r\n                                            <!-- CSS only   <a class=\"card-title\" asp-area=\"\" asp-controller=\"Detail\" asp-action=\"Index\">");
#nullable restore
#line 88 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                                                                                                    Write(item.Baslik);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>-->\r\n                                            <p class=\"card-text\" style=\"color:limegreen\" :\">");
#nullable restore
#line 89 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                                                       Write(item.Fiyat);

#line default
#line hidden
#nullable disable
                WriteLiteral(" TL</p>\r\n\r\n                                            <div class=\"btn-toolbar\" role=\"toolbar\" aria-label=\"Toolbar with button groups\">\r\n                                                <div class=\"btn-group me-2\" role=\"group\" aria-label=\"First group\">\r\n");
#nullable restore
#line 93 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                      
                                                        if (item.Url.Contains("trendyol"))
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\"");
                BeginWriteAttribute("href", " href=\"", 4788, "\"", 4804, 1);
#nullable restore
#line 96 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 4795, item.Url, 4795, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn active\" style=\"color:orange\">Trendyol</a>\r\n");
#nullable restore
#line 97 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\" href=\"#\" class=\"btn active\" style=\"color:orange\">Trendyol</a>\r\n");
#nullable restore
#line 101 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                        }
                                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                   \r\n\r\n                                                </div>\r\n                                                <div class=\"btn-group me-2\" role=\"group\" aria-label=\"Second group\">\r\n");
#nullable restore
#line 108 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                      
                                                        if (item.Url.Contains("n11"))
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\"");
                BeginWriteAttribute("href", " href=\"", 5802, "\"", 5818, 1);
#nullable restore
#line 111 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 5809, item.Url, 5809, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn active\" style=\"color:red\">n11</a>\r\n");
#nullable restore
#line 112 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"

                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\" href=\"#\" class=\"btn active\" style=\"color:red\">n11</a>\r\n");
#nullable restore
#line 117 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"

                                                        }
                                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </div>\r\n                                                <div class=\"btn-group\" role=\"group\" aria-label=\"Third group\">\r\n");
#nullable restore
#line 123 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                      
                                                        if (item.Url.Contains("vatan"))
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\"");
                BeginWriteAttribute("href", " href=\"", 6745, "\"", 6761, 1);
#nullable restore
#line 126 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 6752, item.Url, 6752, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn active\" style=\"color:blue\">Vatan</a>\r\n");
#nullable restore
#line 127 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"


                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\" href=\"#\" class=\"btn active\" style=\"color:blue\">Vatan</a>\r\n");
#nullable restore
#line 133 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"

                                                        }
                                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                </div>\r\n                                                <div class=\"btn-group\" role=\"group\" aria-label=\"Fourth group\">\r\n");
#nullable restore
#line 138 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                                                      
                                                        if (item.Url.Contains("mediamarkt"))
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\"");
                BeginWriteAttribute("href", " href=\"", 7700, "\"", 7716, 1);
#nullable restore
#line 141 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 7707, item.Url, 7707, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn active\" style=\"color:deeppink\">Media Markt</a>\r\n");
#nullable restore
#line 142 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"


                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <a type=\"button\" href=\"#\" class=\"btn active\" style=\"color: deeppink\">Media Markt</a>\r\n");
#nullable restore
#line 148 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"

                                                        }
                                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                </div>
                                            </div>
                                            <br>
                                            <br>
                                            <div class=""btn-toolbar"" role=""toolbar"">
                                                <div class=""btn-group me-2"" role=""group"" aria-label=""First group"">

                                                    <a  class=""btn active"" style=""color:darkred""");
                BeginWriteAttribute("href", " href=\'", 8733, "\'", 8797, 1);
#nullable restore
#line 159 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 8740, Url.Action("Sil", "Admin", new { baslik = item.Baslik }), 8740, 57, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Sil</a>
                                                   

                                                </div>
                                                <div class=""btn-group me-2"" role=""group"">
                                                    <a class=""btn active"" style=""color:green""");
                BeginWriteAttribute("href", " href=\'", 9103, "\'", 9171, 1);
#nullable restore
#line 164 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
WriteAttributeValue("", 9110, Url.Action("Update", "Admin", new { id = item.Id , bos="" }), 9110, 61, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Güncelle</a>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
");
#nullable restore
#line 173 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </html>\r\n");
#nullable restore
#line 181 "C:\Users\LENOVO\Desktop\Seyu\Seyu\Views\Admin\Edit.cshtml"


}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Laptop>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
