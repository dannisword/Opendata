SET ANSI_NULLS ON
GO
DROP TABLE [dbo].[JList]
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
    [ListDate] [datetime] NOT NULL,
    [ListItem] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyUser] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JList] ADD  CONSTRAINT [PK_JList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁決書異動日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'ListDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁決書異動ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'ListItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JList', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
