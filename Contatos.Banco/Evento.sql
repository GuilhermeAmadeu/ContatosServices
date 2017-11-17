CREATE TABLE [dbo].[Evento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[IdUsuario] INT NOT NULL, 
    [Nome] VARCHAR(150) NOT NULL,
	[DataHoraInicio] DATETIME2(7) NOT NULL,
	[DataHoraTermino] DATETIME2(7) NOT NULL,
    [Status] VARCHAR(20) NOT NULL,
    [IdParticipante] UNIQUEIDENTIFIER NULL, 
    [Anotacoes] VARCHAR(250) NULL, 
    [Cep] VARCHAR(9) NULL, 
    [Endereco] VARCHAR(150) NULL, 
    [Numero] VARCHAR(10) NULL, 
    [Bairro] VARCHAR(50) NULL, 
    [Cidade] VARCHAR(150) NULL, 
    [Uf] CHAR(2) NULL,
    CONSTRAINT PK_Evento PRIMARY KEY(Id),
	CONSTRAINT FK_Evento_Usuario FOREIGN KEY(IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_Evento_Participante FOREIGN KEY(IdParticipante) REFERENCES Pessoa(Id),
	CONSTRAINT CK_Evento_Status
	CHECK(Status IN ('Ocupado','Disponivel','Provisório','Atividade Externa'))
);
