

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using CCode.Authorization;

namespace CCode.Categories.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CategoryPermissions" /> for all permission names. Category
    ///</summary>
    public class CategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CategoryAuthorizationProvider()
		{

		}

        public CategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
            // 在这里配置了Category 的权限。
            //var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var pages = context.GetPermissionOrNull(PermissionNames.Pages_Categories) ?? context.CreatePermission(PermissionNames.Pages_Categories, L("Categories"));

            pages.CreateChildPermission(CategoryPermissions.Query, L("QueryCategory"));
            pages.CreateChildPermission(CategoryPermissions.Create, L("CreateCategory"));
            pages.CreateChildPermission(CategoryPermissions.Edit, L("EditCategory"));
            pages.CreateChildPermission(CategoryPermissions.Delete, L("DeleteCategory"));
            pages.CreateChildPermission(CategoryPermissions.BatchDelete, L("BatchDeleteCategory"));
            pages.CreateChildPermission(CategoryPermissions.ExportExcel, L("ExportExcelCategory"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, CCodeConsts.LocalizationSourceName);
		}
    }
}