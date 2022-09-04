SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JUDoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
    [Attachments] [nvarchar](2000) NOT NULL,
    [JFullX] [nvarchar](max) NOT NULL,
    [JID] [nvarchar](200)  NOT NULL,
    [JYear] [nvarchar](3)  NOT NULL,
    [JCase] [nvarchar](80)  NOT NULL,
    [JNO] [nvarchar](10)  NOT NULL,
    [JDate] [nvarchar](10) NOT NULL,
    [JTitle] [nvarchar](255) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyUser] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JUDoc] ADD  CONSTRAINT [PK_JUDoc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判書附檔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'Attachments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判書全文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JFullX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判書 ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字別' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JCase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'號次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判案由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'JTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JUDoc', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
