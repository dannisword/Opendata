USE [EQC_NEW]
GO
DROP TABLE [dbo].[CourtVerdict]
/****** Object:  Table [dbo].[CourtVerdict]    Script Date: 2022/8/24 �W�� 12:45:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CourtVerdict](
	[Seq] [int] IDENTITY(1,1) NOT NULL,
	[JID] [varchar](20) NULL,
	[JYear] [nvarchar](5) NULL,
	[JCase] [nvarchar](20) NULL,
	[JNo] [varchar](20) NULL,
	[JDate] [nvarchar](10) NULL,
	[JTitle] [nvarchar](500) NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
 CONSTRAINT [PK_CourtVerdict] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'Seq'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�P�O��ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�~��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JYear'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�r��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JCase'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Q���P���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���P�ץ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'JTitle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إ߮ɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إߤH���Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʮɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʤH���Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�P�M�Ѹ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CourtVerdict'
GO


