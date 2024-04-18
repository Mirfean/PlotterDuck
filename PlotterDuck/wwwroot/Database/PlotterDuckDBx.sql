CREATE TABLE [dbo].Character
(
	[Id] INT NOT NULL PRIMARY KEY,
	[FName] NVARCHAR(50) NULL,
	[LName] NVARCHAR(50) NULL,
	[Age] INT NULL,
	[Race] NVARCHAR(50),
	[Class] NVARCHAR(50),
	[Fraction] NVARCHAR(50),
	[Date_of_creation] DATETIME
)
