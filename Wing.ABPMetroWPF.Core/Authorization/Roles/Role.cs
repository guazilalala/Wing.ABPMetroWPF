using Abp.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wing.ABPMetroWPF.Authorization.Users;

namespace Wing.ABPMetroWPF.Authorization.Roles
{
	/// <summary>
	/// Represents a role in the system.
	/// </summary>
	public class Role : AbpRole<User>
	{
		//Can add application specific role properties here

		public Role()
		{

		}

		public Role(int? tenantId, string displayName)
			: base(tenantId, displayName)
		{

		}

		public Role(int? tenantId, string name, string displayName)
			: base(tenantId, name, displayName)
		{

		}
	}
}
