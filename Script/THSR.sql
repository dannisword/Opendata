USE [EQC_NEW]
GO
DROP TABLE [dbo].[THSR]
/****** Object:  Table [dbo].[THSR]    Script Date: 2022/8/24 �W�� 06:56:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[THSR](
	[Seq] [int] IDENTITY(1,1) NOT NULL,
	[Direction] [tinyint] NULL,
	[CarNo] [varchar](6) NULL,
	[StartStationName] [nvarchar](10) NULL,
	[DepartureTime] [varchar](5) NULL,
	[EndingStationName] [nvarchar](10) NULL,
	[ArrivalTime] [varchar](5) NULL,
	[Memo] [nvarchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
 CONSTRAINT [PK_THSR] PRIMARY KEY CLUSTERED 
(
	[Seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'Seq'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��V(1:�_�W, 2:�n�U)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'Direction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'CarNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�_��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'StartStationName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�w�p�X�o�ɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'DepartureTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���I��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'EndingStationName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�w�p��F�ɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'ArrivalTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'Memo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إ߮ɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�إߤH���Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʮɶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʤH���Ǹ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���K��T' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'THSR'
GO


