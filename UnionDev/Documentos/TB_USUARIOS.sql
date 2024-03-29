USE [UNIONDEV]
GO

/****** Object:  Table [dbo].[TB_USUARIOS]    Script Date: 21/10/2019 22:03:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TB_USUARIOS](
	[USU_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[USU_LOGIN] [varchar](150) NOT NULL,
	[USU_SENHA] [varchar](max) NOT NULL,
	[USU_ATIVO] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USU_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


