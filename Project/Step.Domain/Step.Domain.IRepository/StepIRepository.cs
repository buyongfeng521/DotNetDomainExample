

using Step.Data;
using Step.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Domain.IRepository
{	
	/// <summary>
	/// It_admin_userRepository
	/// </summary>	
	public interface It_admin_userRepository:IRepositoryBase<t_admin_userEntity>
	{
		
    }
	/// <summary>
	/// It_menuRepository
	/// </summary>	
	public interface It_menuRepository:IRepositoryBase<t_menuEntity>
	{
		
    }
	/// <summary>
	/// It_roleRepository
	/// </summary>	
	public interface It_roleRepository:IRepositoryBase<t_roleEntity>
	{
		
    }
	/// <summary>
	/// It_role_menuRepository
	/// </summary>	
	public interface It_role_menuRepository:IRepositoryBase<t_role_menuEntity>
	{
		
    }
}



