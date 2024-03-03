CREATE TABLE [dbo].[Choices]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
    [Content] VARCHAR(MAX) NOT NULL, 
    [IsCorrect] BIT NOT NULL, 
    [QuestionId] INT NOT NULL
)
