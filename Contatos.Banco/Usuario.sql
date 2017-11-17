﻿CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Token] UNIQUEIDENTIFIER NULL, 
    [Nome] VARCHAR(150) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Senha] VARCHAR(10) NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY(Id),
	CONSTRAINT UN_Usuario_Email UNIQUE(Email)
)