CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[FK_idAddress] INT NULL, 
	[FK_idPhone] INT NULL,
    [Name] VARCHAR(255) NULL, 
    [Branch] VARCHAR(255) NULL, 
    [Owner] VARCHAR(255) NULL 
)
