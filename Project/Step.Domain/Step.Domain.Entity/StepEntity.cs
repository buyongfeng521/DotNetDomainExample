

using System;
using System.ComponentModel.DataAnnotations;
namespace Step.Domain.Entity
{	
    
    public partial class t_admin_userEntity
    {
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string user_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string role_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string user_name { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string user_psw { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string user_salt { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string user_realname { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		public DateTime? last_login_time { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		public DateTime? create_time { get; set; }
         


    }

    public partial class t_menuEntity
    {
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_name { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_value { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_url { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		public byte? menu_order { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_icon { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string parent_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_area { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_controller { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_action { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_style { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		public DateTime? create_time { get; set; }
         


    }

    public partial class t_roleEntity
    {
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string role_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string role_name { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		public DateTime? create_time { get; set; }
         


    }

    public partial class t_role_menuEntity
    {
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string role_id { get; set; }
        /// <summary>
        /// 
        /// </summary>       
		 
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string menu_id { get; set; }
         


    }
}



