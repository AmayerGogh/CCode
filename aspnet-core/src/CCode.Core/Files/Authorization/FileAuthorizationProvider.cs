

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using CCode.Authorization;

namespace CCode.Files.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="FilePermissions" /> for all permission names. File
    ///</summary>
    public class FileAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public FileAuthorizationProvider()
		{

		}

        public FileAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public FileAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{          
            var entityPermission = context.GetPermissionOrNull(PermissionNames.Pages_Files) ?? context.CreatePermission(PermissionNames.Pages_Files, L("Files"));
           
			entityPermission.CreateChildPermission(FilePermissions.Query, L("QueryFile"));
			entityPermission.CreateChildPermission(FilePermissions.Create, L("CreateFile"));
			entityPermission.CreateChildPermission(FilePermissions.Edit, L("EditFile"));
			entityPermission.CreateChildPermission(FilePermissions.Delete, L("DeleteFile"));
			entityPermission.CreateChildPermission(FilePermissions.BatchDelete, L("BatchDeleteFile"));
			entityPermission.CreateChildPermission(FilePermissions.ExportExcel, L("ExportExcelFile"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, CCodeConsts.LocalizationSourceName);
		}
    }
}