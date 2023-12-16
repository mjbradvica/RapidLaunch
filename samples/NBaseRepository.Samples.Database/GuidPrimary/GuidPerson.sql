﻿CREATE TABLE [dbo].[GuidPerson]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Age] INT NOT NULL, 
    [GuidAnimalId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [GuidAnimalId] FOREIGN KEY ([GuidAnimalId]) REFERENCES [GuidAnimal]([Id]) ON DELETE CASCADE ON UPDATE CASCADE
)