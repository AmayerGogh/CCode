

namespace CCode.Files.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="FileAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class FilePermissions
	{
		/// <summary>
		/// File权限节点
		///</summary>
		public const string Node = "Pages.File";

		/// <summary>
		/// File查询授权
		///</summary>
		public const string Query = "Pages.File.Query";

		/// <summary>
		/// File创建权限
		///</summary>
		public const string Create = "Pages.File.Create";

		/// <summary>
		/// File修改权限
		///</summary>
		public const string Edit = "Pages.File.Edit";

		/// <summary>
		/// File删除权限
		///</summary>
		public const string Delete = "Pages.File.Delete";

        /// <summary>
		/// File批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.File.BatchDelete";

		/// <summary>
		/// File导出Excel
		///</summary>
		public const string ExportExcel="Pages.File.ExportExcel";

		 
		 
         
    }

}

