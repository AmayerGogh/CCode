using Abp.Authorization;
using Abp.Localization;
using CCode.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCode.Blogs.Authorization
{
    public class ArticleAppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages_Blogs) ?? context.CreatePermission(PermissionNames.Pages_Blogs, L("Blogs"));
            pages
                .CreateChildPermission(ArticleAppPermissions.Article, L("Article"))
                .CreateChildPermission(ArticleAppPermissions.Article_CreateArticle, L("CreateArticle"))
                .CreateChildPermission(ArticleAppPermissions.Article_EditArticle, L("EditArticle"))
                .CreateChildPermission(ArticleAppPermissions.Article_DeleteArticle, L("DeleteArticle"));
        }

        private static ILocalizableString L(string name)
        {            
            return new LocalizableString(name, CCodeConsts.LocalizationSourceName);
        }
    }
}
