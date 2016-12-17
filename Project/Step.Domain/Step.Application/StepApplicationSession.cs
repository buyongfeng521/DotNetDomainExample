


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step.Domain.Entity;
using Step.Domain.IRepository;
using Step.Repository;

namespace Step.Application
{	
  public class ApplicationSession
  {
	
		private t_admin_userApp t_admin_userapp;
		public t_admin_userApp t_admin_userApp
		{
			get
			{
				if(t_admin_userapp == null)
				{
					t_admin_userapp = new t_admin_userApp();
				}
				return t_admin_userapp;
			}
			set{}
		}
        

	
		private t_menuApp t_menuapp;
		public t_menuApp t_menuApp
		{
			get
			{
				if(t_menuapp == null)
				{
					t_menuapp = new t_menuApp();
				}
				return t_menuapp;
			}
			set{}
		}
        

	
		private t_roleApp t_roleapp;
		public t_roleApp t_roleApp
		{
			get
			{
				if(t_roleapp == null)
				{
					t_roleapp = new t_roleApp();
				}
				return t_roleapp;
			}
			set{}
		}
        

	
		private t_role_menuApp t_role_menuapp;
		public t_role_menuApp t_role_menuApp
		{
			get
			{
				if(t_role_menuapp == null)
				{
					t_role_menuapp = new t_role_menuApp();
				}
				return t_role_menuapp;
			}
			set{}
		}
        

		}
  }