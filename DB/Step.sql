if exists (select * from sysobjects where id = OBJECT_ID('[sysdiagrams]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sysdiagrams]

CREATE TABLE [sysdiagrams] (
[name] [nvarchar]  (128) NOT NULL,
[principal_id] [int]  NOT NULL,
[diagram_id] [int]  IDENTITY (1, 1)  NOT NULL,
[version] [int]  NULL,
[definition] [varbinary]  (MAX) NULL)

ALTER TABLE [sysdiagrams] WITH NOCHECK ADD  CONSTRAINT [PK_sysdiagrams] PRIMARY KEY  NONCLUSTERED ( [name],[principal_id],[diagram_id] )
SET IDENTITY_INSERT [sysdiagrams] ON

INSERT [sysdiagrams] ([name],[principal_id],[diagram_id],[version],[definition]) VALUES ( N'Diagram_0',1,1,1,System.Byte[])

SET IDENTITY_INSERT [sysdiagrams] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[t_admin_user]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [t_admin_user]

CREATE TABLE [t_admin_user] (
[user_id] [varchar]  (50) NOT NULL,
[role_id] [varchar]  (50) NULL,
[user_name] [varchar]  (25) NULL,
[user_psw] [varchar]  (50) NULL,
[user_salt] [varchar]  (20) NULL,
[user_realname] [nvarchar]  (20) NULL,
[last_login_time] [datetime]  NULL,
[create_time] [datetime]  NULL)

ALTER TABLE [t_admin_user] WITH NOCHECK ADD  CONSTRAINT [PK_t_admin_user] PRIMARY KEY  NONCLUSTERED ( [user_id] )
INSERT [t_admin_user] ([user_id],[role_id],[user_name],[user_psw],[user_salt],[last_login_time],[create_time]) VALUES ( N'a3cf0b6460c74005933232d459435f18',N'd3d56952313e4e2ab077ce57f3007e1d',N'admin',N'D849C85BEA99E307DACF76F102ECB175',N'9ea320dce12c0c00',N'2016/12/16 16:51:08',N'2016/12/16 16:50:58')
INSERT [t_admin_user] ([user_id],[role_id],[user_name],[user_psw],[user_salt],[last_login_time],[create_time]) VALUES ( N'b253f0e6e9854963ae9bb0219e6deefe',N'd3d56952313e4e2ab077ce57f3007e1d',N'buyf',N'EBC05B33D2598FF84703B95A6B450351',N'ef7fce78906d0de6',N'2016/12/16 18:13:58',N'2016/12/16 13:57:01')
if exists (select * from sysobjects where id = OBJECT_ID('[t_menu]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [t_menu]

CREATE TABLE [t_menu] (
[menu_id] [varchar]  (50) NOT NULL,
[menu_name] [nvarchar]  (25) NULL,
[menu_value] [varchar]  (20) NULL,
[menu_url] [varchar]  (256) NULL,
[menu_order] [tinyint]  NULL,
[menu_icon] [varchar]  (20) NULL,
[parent_id] [varchar]  (50) NULL,
[menu_area] [varchar]  (20) NULL,
[menu_controller] [varchar]  (20) NULL,
[menu_action] [varchar]  (20) NULL,
[menu_style] [varchar]  (20) NULL,
[create_time] [datetime]  NULL)

ALTER TABLE [t_menu] WITH NOCHECK ADD  CONSTRAINT [PK_t_menu] PRIMARY KEY  NONCLUSTERED ( [menu_id] )
INSERT [t_menu] ([menu_id],[menu_name],[menu_value],[menu_url],[menu_order],[parent_id],[menu_area],[menu_controller],[menu_action],[create_time]) VALUES ( N'54191f1bab724507b50b6988a5ed29ee',N'管理员列表',N'settings_admin',N'/Admin/Settings/AdminUserList',10,N'ac3d86008ae549af8fa95c8246a74d98',N'Admin',N'Settings',N'AdminList',N'2016/12/14 15:00:51')
INSERT [t_menu] ([menu_id],[menu_name],[menu_value],[menu_url],[menu_order],[parent_id],[menu_area],[menu_controller],[menu_action],[create_time]) VALUES ( N'787a4af445d140e7969160bc8b1ee3ca',N'角色管理',N'settings_role',N'/Admin/Settings/RoleList',11,N'ac3d86008ae549af8fa95c8246a74d98',N'Admin',N'Settings',N'RoleList',N'2016/12/14 15:49:00')
INSERT [t_menu] ([menu_id],[menu_name],[menu_value],[menu_url],[menu_order],[parent_id],[menu_area],[menu_controller],[menu_action],[create_time]) VALUES ( N'78d746680b8a43739b459ef190607c2f',N'菜单管理',N'settings_menu',N'/Admin/Settings/MenuList',12,N'ac3d86008ae549af8fa95c8246a74d98',N'Admin',N'Settings',N'MenuList',N'2016/12/14 15:50:14')
INSERT [t_menu] ([menu_id],[menu_name],[menu_value],[menu_url],[menu_order],[menu_icon],[parent_id],[menu_area],[menu_controller],[menu_action],[create_time]) VALUES ( N'82b42cf802a24cc9994ea260b8d3e433',N'控制台',N'MenuIndex',N'/admin/home/index',1,N'icon-dashboard',N'0',N'Admin',N'Home',N'Index',N'2016/12/14 13:21:04')
INSERT [t_menu] ([menu_id],[menu_name],[menu_value],[menu_url],[menu_order],[menu_icon],[parent_id],[create_time]) VALUES ( N'ac3d86008ae549af8fa95c8246a74d98',N'设置',N'MenuSettings',N'#',10,N'icon-cog',N'0',N'2016/12/14 14:57:29')
if exists (select * from sysobjects where id = OBJECT_ID('[t_role]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [t_role]

CREATE TABLE [t_role] (
[role_id] [varchar]  (50) NOT NULL,
[role_name] [nvarchar]  (25) NULL,
[create_time] [datetime]  NULL)

ALTER TABLE [t_role] WITH NOCHECK ADD  CONSTRAINT [PK_t_role] PRIMARY KEY  NONCLUSTERED ( [role_id] )
INSERT [t_role] ([role_id],[role_name],[create_time]) VALUES ( N'd3d56952313e4e2ab077ce57f3007e1d',N'管理员',N'2016/12/14 17:31:43')
if exists (select * from sysobjects where id = OBJECT_ID('[t_role_menu]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [t_role_menu]

CREATE TABLE [t_role_menu] (
[role_id] [varchar]  (50) NOT NULL,
[menu_id] [varchar]  (50) NOT NULL)

ALTER TABLE [t_role_menu] WITH NOCHECK ADD  CONSTRAINT [PK_t_role_menu] PRIMARY KEY  NONCLUSTERED ( [role_id],[menu_id] )
INSERT [t_role_menu] ([role_id],[menu_id]) VALUES ( N'd3d56952313e4e2ab077ce57f3007e1d',N'54191f1bab724507b50b6988a5ed29ee')
INSERT [t_role_menu] ([role_id],[menu_id]) VALUES ( N'd3d56952313e4e2ab077ce57f3007e1d',N'787a4af445d140e7969160bc8b1ee3ca')
