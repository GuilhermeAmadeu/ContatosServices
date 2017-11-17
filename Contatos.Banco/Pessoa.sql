CREATE TABLE [dbo].[Pessoa]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdUsuario] INT NULL, 
    [Nome] VARCHAR(150) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Telefone] VARCHAR(20) NULL, 
    [Observacao] VARCHAR(250) NULL, 
    [DataNascimento] DATE NULL, 
    [Cep] VARCHAR(9) NULL, 
    [Endereco] VARCHAR(150) NULL, 
    [Numero] VARCHAR(10) NULL, 
    [Bairro] VARCHAR(50) NULL, 
    [Cidade] VARCHAR(150) NULL, 
    [Uf] CHAR(2) NULL,
	CONSTRAINT PK_Pessoa PRIMARY KEY(Id),
	CONSTRAINT FK_Pessoa_Usuario
	   FOREIGN KEY(IdUsuario) REFERENCES Usuario(Id)
)
