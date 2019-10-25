USE [UNIONDEV]
GO

/****** Object:  Table [dbo].[TB_CLIENTES]    Script Date: 21/10/2019 22:26:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TB_CLIENTES](
	[CLI_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[CLI_RAZAO_SOCIAL] [varchar](100) NOT NULL,
	[CLI_CNPJ] [varchar](14) NOT NULL,
	[CLI_RAMO] [varchar](200) NOT NULL,
	[CLI_ENDCODIGO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CLI_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


