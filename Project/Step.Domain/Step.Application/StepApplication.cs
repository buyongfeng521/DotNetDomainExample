


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step.Domain.Entity;
using Step.Domain.IRepository;
using Step.Repository;
using System.Linq.Expressions;
namespace Step.Application
{	
	/// <summary>
	/// t_admin_userApp
	/// </summary>	
	public partial class t_admin_userApp
	{
	    private It_admin_userRepository service=new t_admin_userRepository();

		public List<t_admin_userEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

		public List<t_admin_userEntity> GetList(Expression<Func<t_admin_userEntity, bool>> expression)
        {
            return service.IQueryable(expression).ToList();
        }

		public List<t_admin_userEntity> GetList<TKey>(Expression<Func<t_admin_userEntity, bool>> expression,Expression<Func<t_admin_userEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderBy(order).ToList();
		}

		public List<t_admin_userEntity> GetListByDesc<TKey>(Expression<Func<t_admin_userEntity, bool>> expression,Expression<Func<t_admin_userEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderByDescending(order).ToList();
		}

	    public t_admin_userEntity GetEntity(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

		public t_admin_userEntity GetEntity(Expression<Func<t_admin_userEntity, bool>> expression)
        {
            return service.FindEntity(expression);
        }

        public void Delete(t_admin_userEntity entity)
        {
            service.Delete(entity);
        }

		public void Delete(Expression<Func<t_admin_userEntity, bool>> expression)
        {
            service.Delete(expression);
        }


		public void Insert(t_admin_userEntity entity)
		{
			service.Insert(entity);
		}
		public void Update(t_admin_userEntity entity)
		{
			service.Update(entity);
		}


    }
	/// <summary>
	/// t_menuApp
	/// </summary>	
	public partial class t_menuApp
	{
	    private It_menuRepository service=new t_menuRepository();

		public List<t_menuEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

		public List<t_menuEntity> GetList(Expression<Func<t_menuEntity, bool>> expression)
        {
            return service.IQueryable(expression).ToList();
        }

		public List<t_menuEntity> GetList<TKey>(Expression<Func<t_menuEntity, bool>> expression,Expression<Func<t_menuEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderBy(order).ToList();
		}

		public List<t_menuEntity> GetListByDesc<TKey>(Expression<Func<t_menuEntity, bool>> expression,Expression<Func<t_menuEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderByDescending(order).ToList();
		}

	    public t_menuEntity GetEntity(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

		public t_menuEntity GetEntity(Expression<Func<t_menuEntity, bool>> expression)
        {
            return service.FindEntity(expression);
        }

        public void Delete(t_menuEntity entity)
        {
            service.Delete(entity);
        }

		public void Delete(Expression<Func<t_menuEntity, bool>> expression)
        {
            service.Delete(expression);
        }


		public void Insert(t_menuEntity entity)
		{
			service.Insert(entity);
		}
		public void Update(t_menuEntity entity)
		{
			service.Update(entity);
		}


    }
	/// <summary>
	/// t_roleApp
	/// </summary>	
	public partial class t_roleApp
	{
	    private It_roleRepository service=new t_roleRepository();

		public List<t_roleEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

		public List<t_roleEntity> GetList(Expression<Func<t_roleEntity, bool>> expression)
        {
            return service.IQueryable(expression).ToList();
        }

		public List<t_roleEntity> GetList<TKey>(Expression<Func<t_roleEntity, bool>> expression,Expression<Func<t_roleEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderBy(order).ToList();
		}

		public List<t_roleEntity> GetListByDesc<TKey>(Expression<Func<t_roleEntity, bool>> expression,Expression<Func<t_roleEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderByDescending(order).ToList();
		}

	    public t_roleEntity GetEntity(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

		public t_roleEntity GetEntity(Expression<Func<t_roleEntity, bool>> expression)
        {
            return service.FindEntity(expression);
        }

        public void Delete(t_roleEntity entity)
        {
            service.Delete(entity);
        }

		public void Delete(Expression<Func<t_roleEntity, bool>> expression)
        {
            service.Delete(expression);
        }


		public void Insert(t_roleEntity entity)
		{
			service.Insert(entity);
		}
		public void Update(t_roleEntity entity)
		{
			service.Update(entity);
		}


    }
	/// <summary>
	/// t_role_menuApp
	/// </summary>	
	public partial class t_role_menuApp
	{
	    private It_role_menuRepository service=new t_role_menuRepository();

		public List<t_role_menuEntity> GetList()
        {
            return service.IQueryable().ToList();
        }

		public List<t_role_menuEntity> GetList(Expression<Func<t_role_menuEntity, bool>> expression)
        {
            return service.IQueryable(expression).ToList();
        }

		public List<t_role_menuEntity> GetList<TKey>(Expression<Func<t_role_menuEntity, bool>> expression,Expression<Func<t_role_menuEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderBy(order).ToList();
		}

		public List<t_role_menuEntity> GetListByDesc<TKey>(Expression<Func<t_role_menuEntity, bool>> expression,Expression<Func<t_role_menuEntity, TKey>> order)
		{
			return service.IQueryable(expression).OrderByDescending(order).ToList();
		}

	    public t_role_menuEntity GetEntity(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

		public t_role_menuEntity GetEntity(Expression<Func<t_role_menuEntity, bool>> expression)
        {
            return service.FindEntity(expression);
        }

        public void Delete(t_role_menuEntity entity)
        {
            service.Delete(entity);
        }

		public void Delete(Expression<Func<t_role_menuEntity, bool>> expression)
        {
            service.Delete(expression);
        }


		public void Insert(t_role_menuEntity entity)
		{
			service.Insert(entity);
		}
		public void Update(t_role_menuEntity entity)
		{
			service.Update(entity);
		}


    }
}



