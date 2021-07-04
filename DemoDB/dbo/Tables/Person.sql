CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(255) NOT NULL, 
    [LastName] NVARCHAR(255) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [PartnerNumber] BIGINT NOT NULL, 
    [CroatianPIN] BIGINT NULL, 
    [PartnerTypeId] INT NOT NULL, 
    [CreatedAtUtc] DATETIME NOT NULL, 
    [CreateByUser] NVARCHAR(20) NOT NULL, 
    [IsForeign] BIT NULL, 
    [ExternalCode] NVARCHAR(20) NULL, 
    [Gender] CHAR NULL 
)
