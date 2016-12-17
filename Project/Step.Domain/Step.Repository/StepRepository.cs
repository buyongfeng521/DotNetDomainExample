


using Step.Data;
using Step.Domain.Entity;
using Step.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Repository
{	
	/// <summary>
	/// t_admin_userRepository
	/// </summary>	
	public class t_admin_userRepository:RepositoryBase<t_admin_userEntity>,It_admin_userRepository
	{

    }
	/// <summary>
	/// t_menuRepository
	/// </summary>	
	public class t_menuRepository:RepositoryBase<t_menuEntity>,It_menuRepository
	{

    }
	/// <summary>
	/// t_roleRepository
	/// </summary>	
	public class t_roleRepository:RepositoryBase<t_roleEntity>,It_roleRepository
	{

    }
	/// <summary>
	/// t_role_menuRepository
	/// </summary>	
	public class t_role_menuRepository:RepositoryBase<t_role_menuEntity>,It_role_menuRepository
	{

    }
}



