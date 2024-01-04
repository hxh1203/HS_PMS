USE [HS.Argus.CloseLoopDataBaseA]
GO

/****** Object:  Table [dbo].[HS_SYS_USER]    Script Date: 2023/12/13 22:42:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HS_SYS_USER](
	[ID] [nvarchar](50) NOT NULL,
	[LoginName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[DeptID] [nvarchar](50) NULL,
	[DeptName] [nvarchar](50) NULL,
	[PosName] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
	[AuthorityLevel] [nvarchar](50) NULL,
	[UpdateDateTime] [datetime] NULL,
	[InsertDateTime] [datetime] NULL,
 CONSTRAINT [PK_HS_SYS_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HS_SYS_USER] ADD  CONSTRAINT [DF_HS_SYS_USER_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[HS_SYS_USER] ADD  CONSTRAINT [DF_HS_SYS_USER_UpdateDateTime]  DEFAULT (getdate()) FOR [UpdateDateTime]
GO

ALTER TABLE [dbo].[HS_SYS_USER] ADD  CONSTRAINT [DF_HS_SYS_USER_InsertDateTime]  DEFAULT (getdate()) FOR [InsertDateTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'LoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'Password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'Mobile'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'DeptID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'DeptName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'PosName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'Role'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'AuthorityLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'UpdateDateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'插入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER', @level2type=N'COLUMN',@level2name=N'InsertDateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HS_SYS_USER'
GO


