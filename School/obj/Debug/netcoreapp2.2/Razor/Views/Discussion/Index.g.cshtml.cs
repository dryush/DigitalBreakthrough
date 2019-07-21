#pragma checksum "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1659d4efc91111424f6f982a3d0d75f22e733b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Discussion_Index), @"mvc.1.0.view", @"/Views/Discussion/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Discussion/Index.cshtml", typeof(AspNetCore.Views_Discussion_Index))]
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
#line 1 "C:\Users\Poas\source\repos\School\School\Views\_ViewImports.cshtml"
using School;

#line default
#line hidden
#line 2 "C:\Users\Poas\source\repos\School\School\Views\_ViewImports.cshtml"
using School.Models;

#line default
#line hidden
#line 1 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
using School.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1659d4efc91111424f6f982a3d0d75f22e733b5", @"/Views/Discussion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4035b931494fa1549d6ea6f2e0dd8aa05ecfb9a6", @"/Views/_ViewImports.cshtml")]
    public class Views_Discussion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dictionary<School.Data.Models.DiscussionStatus, List<School.Data.Models.Discussion>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(121, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
  
    ViewData["Title"] = "Discussion";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(216, 91, true);
            WriteLiteral("\r\n\r\n<h1>Обсуждения <a href=\"./Create\"><i class=\"fa fa-plus float-right\"></i></a></h1>\r\n\r\n\r\n");
            EndContext();
#line 13 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
 foreach (var collection in Model.Select( v => v).OrderBy( v => (int)v.Key))
{

#line default
#line hidden
            BeginContext(388, 19, true);
            WriteLiteral("    <hr>\r\n    <h2> ");
            EndContext();
            BeginContext(409, 125, false);
#line 16 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
     Write(collection.Key == DiscussionStatus.CLOSE ? "Завершённые" : collection.Key == DiscussionStatus.FIRE ? "Срочные" : "В процессе");

#line default
#line hidden
            EndContext();
            BeginContext(535, 36, true);
            WriteLiteral("</h2>\r\n    <div class=\"card-deck\">\r\n");
            EndContext();
#line 18 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
         foreach (var discuc in collection.Value)
        {


#line default
#line hidden
            BeginContext(635, 142, true);
            WriteLiteral("            <div class=\"card\" style=\"max-width:18rem;\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\"> ");
            EndContext();
            BeginContext(778, 11, false);
#line 23 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
                                       Write(discuc.Name);

#line default
#line hidden
            EndContext();
            BeginContext(789, 12, true);
            WriteLiteral(" <a href=\"#\"");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 801, "\"", 954, 5);
            WriteAttributeValue("", 809, "float-right", 809, 11, true);
            WriteAttributeValue(" ", 820, "badge", 821, 6, true);
            WriteAttributeValue(" ", 826, "badge-", 827, 7, true);
#line 23 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
WriteAttributeValue("", 833, collection.Key == DiscussionStatus.CLOSE ? "success" : collection.Key == DiscussionStatus.FIRE ? "danger" : "warning", 833, 120, false);

#line default
#line hidden
            WriteAttributeValue(" ", 953, "", 954, 1, true);
            EndWriteAttribute();
            BeginContext(955, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(958, 123, false);
#line 23 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
                                                                                                                                                                                                                           Write(collection.Key == DiscussionStatus.CLOSE ? "Завершённа" : collection.Key == DiscussionStatus.FIRE ? "Срочно" : "В процессе");

#line default
#line hidden
            EndContext();
            BeginContext(1082, 79, true);
            WriteLiteral("</a> </h5>\r\n                    <p class=\"card-text\">\r\n                        ");
            EndContext();
            BeginContext(1162, 18, false);
#line 25 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
                   Write(discuc.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1180, 70, true);
            WriteLiteral("\r\n                    </p>\r\n                    <a class=\"float-right\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1250, "\"", 1277, 2);
            WriteAttributeValue("", 1257, "./Details/", 1257, 10, true);
#line 27 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
WriteAttributeValue("", 1267, discuc.Id, 1267, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1278, 63, true);
            WriteLiteral(">К обсуждению</a>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 30 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1352, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 32 "C:\Users\Poas\source\repos\School\School\Views\Discussion\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1367, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dictionary<School.Data.Models.DiscussionStatus, List<School.Data.Models.Discussion>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
