BEGIN TRY  
DROP TABLE [dbo].[RfPessoaJuridica];
DROP TABLE [dbo].[RfEndereco];
DROP TABLE [dbo].[RfTelefone];
DROP TABLE [dbo].[RfPessoaJuridicaCnaeSubclasse];

END TRY
BEGIN CATCH 
END CATCH;

CREATE TABLE [dbo].[RfPessoaJuridica](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Cnpj] [bigint] NOT NULL,
	[RazaoSocial] [nvarchar](150) NULL,
	[NomeFantasia] [nvarchar](150) NULL,
	[CapitalSocial] [decimal](18, 2) NULL,
	[DataInicioAtividades] [date] NULL,
	[CnaeFiscal] [nvarchar](7) NULL,
	[SituacaoCadastral] [nvarchar](2) NULL,
	[DataSituacaoCadastral] [date] NULL,
	[MotivoSituacaoCadastral] [nvarchar](2) NULL,
	[NaturezaJuridica] [bigint] NULL,
	[OptanteMei] [bit] NULL,
	[OptanteSimples] [bit] NULL,
	[Email] [nvarchar](400) NULL,
	[DataBaseImportacao] [date] NULL,
) ;



CREATE TABLE [dbo].[RfEndereco](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Cnpj] [bigint] NOT NULL,
	[Cep] [bigint] NULL,
	[TipoLogradouro] [nvarchar](20) NULL,
	[Logradouro] [nvarchar](60) NULL,
	[Numero] [nvarchar](6) NULL,
	[Complemento] [nvarchar](156) NULL,
	[Bairro] [nvarchar](50) NULL,
	[IdMunicipio] [bigint] NULL,
	[Uf] [nvarchar](10) NULL,
	[Municipio] [nvarchar](50) NULL,
);


CREATE TABLE [dbo].[RfTelefone](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Cnpj] [bigint] NOT NULL,
	[Telefone] [nvarchar](50) NULL
);


CREATE TABLE [dbo].[RfPessoaJuridicaCnaeSubclasse](
	[Id] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[Cnpj] [bigint] NOT NULL,
	[IdCnaeSubClasse] [nvarchar](7) NULL
);

CREATE INDEX irf1 ON [RfPessoaJuridica] ([Cnpj]);
CREATE INDEX irf2 ON [RfEndereco] ([Cnpj]);
CREATE INDEX irf3 ON [RfTelefone] ([Cnpj]);