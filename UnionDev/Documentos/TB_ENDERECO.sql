USE [UNIONDEV]
GO

/****** Object:  Table [dbo].[TB_ENDERECO]    Script Date: 21/10/2019 22:26:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TB_ENDERECO](
	[END_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[END_LOGRADOURO] [varchar](100) NOT NULL,
	[END_NUMERO] [varchar](10) NOT NULL,
	[END_BAIRRO] [varchar](100) NOT NULL,
	[END_CIDADE] [varchar](100) NOT NULL,
	[END_ESTADO] [varchar](100) NOT NULL,
	[END_CEP] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[END_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

