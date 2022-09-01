SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtVerdict](
	[Seq] [int] IDENTITY(1,1) NOT NULL,
	[JID] [nvarchar](80) NULL,
	[JYear] [nvarchar](5) NULL,
	[JCase] [nvarchar](20) NULL,
	[JNo] [varchar](20) NULL,
	[JDate] [nvarchar](10) NULL,
	[JTitle] [nvarchar](500) NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyUser] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourtVerdict] ADD  CONSTRAINT [PK_CourtVerdict] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'Seq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判別書ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JCase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'號次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'十戈衣判日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'裁判案由' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'建立人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'異動人員序號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'判決書資料' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict'
GO
