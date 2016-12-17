

using Step.Domain.Entity;
using System.Data.Entity.ModelConfiguration;
namespace Step.Mapping
{	
	/// <summary>
	/// t_admin_user
	/// </summary>	
	public class t_admin_userMap:EntityTypeConfiguration<t_admin_userEntity>
	{
	   public t_admin_userMap()
	   {
	      this.ToTable("t_admin_user");
		  this.HasKey(t=>t.user_id);
	   }
    }
	/// <summary>
	/// t_menu
	/// </summary>	
	public class t_menuMap:EntityTypeConfiguration<t_menuEntity>
	{
	   public t_menuMap()
	   {
	      this.ToTable("t_menu");
		  this.HasKey(t=>t.menu_id);
	   }
    }
	/// <summary>
	/// t_role
	/// </summary>	
	public class t_roleMap:EntityTypeConfiguration<t_roleEntity>
	{
	   public t_roleMap()
	   {
	      this.ToTable("t_role");
		  this.HasKey(t=>t.role_id);
	   }
    }
	/// <summary>
	/// t_role_menu
	/// </summary>	
	public class t_role_menuMap:EntityTypeConfiguration<t_role_menuEntity>
	{
	   public t_role_menuMap()
	   {
	      this.ToTable("t_role_menu");
		  this.HasKey(t=>t.menu_id);
	   }
    }
}



