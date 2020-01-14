--CREATE DATABASE AnagramFinder
--GO

USE AnagramFinder
GO

DROP PROC [dbo].[GetWordStatistics]
DROP FUNCTION [dbo].[GetAllOccurrences]
DROP FUNCTION [dbo].[GetCharacters]
DROP PROC [dbo].[FindMatchngAnagrams]
DROP VIEW [dbo].[vw_WordStatistic]
DROP TABLE [dbo].[WordStatistic]
DROP TABLE [dbo].[Word]
DROP TABLE [dbo].[Character]

CREATE TABLE [dbo].[Character] (
  [Id] INT NOT NULL IDENTITY(1,1)
	CONSTRAINT PK_Character PRIMARY KEY
 ,[Index] INT NOT NULL
 ,[Value] CHAR(1) CONSTRAINT IQ_Character UNIQUE
 ,[Score] TINYINT NOT NULL
)

CREATE TABLE [dbo].[Word] (
	[Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Word PRIMARY KEY
	,[Value] VARCHAR(1700) NOT NULL
		CONSTRAINT IQ_Word UNIQUE
	,[Length] BIGINT NOT NULL
)

CREATE TABLE [dbo].[WordStatistic]  (
	 [CharacterId] INT NOT NULL
		CONSTRAINT FK_WordStatistic_Character
		REFERENCES [dbo].[Character]
	,[WordId] INT NOT NULL
		CONSTRAINT FK_WordStatistic_Word
		REFERENCES [dbo].[Word]
	,[TotalOccurrences] INT NOT NULL
	,CONSTRAINT PK_WordStatistic 
		PRIMARY KEY ([CharacterId],[WordId])
)

GO

CREATE FUNCTION [dbo].[GetAllOccurrences] (@searchExpression VARCHAR(MAX), @searchSource VARCHAR(MAX))
RETURNS BIGINT
AS
BEGIN
	DECLARE @current_location BIGINT = CHARINDEX(@searchExpression, @searchSource)
	DECLARE @occurence_count BIGINT = 0
	WHILE (@current_location > 0)
	BEGIN
		SET @current_location = @current_location + 1
		SET @occurence_count = @occurence_count + 1
		SET @current_location = CHARINDEX(@searchExpression, @searchSource, @current_location)
	END

	RETURN @occurence_count
END

GO


DECLARE @counter TINYINT = 65
WHILE @counter < 91
BEGIN
	INSERT INTO [Character]
	(
	    [Index],
		[Value],
		[Score]
	)
	VALUES
	(@counter, CHAR(@counter), 0)

	SET @counter = @counter + 1
END

GO

CREATE FUNCTION [dbo].[GetCharacters](@word VARCHAR(MAX))
RETURNS VARCHAR(MAX)
AS
BEGIN	
	DECLARE @characters VARCHAR(MAX)
	
	SELECT @characters = CONCAT(@characters, ',', [Character])
			FROM [dbo].[vw_WordStatistic]
			WHERE [Word] = @word

	SET @characters = TRIM(',' FROM @characters)

	RETURN @characters
END

GO

CREATE PROCEDURE [dbo].[FindMatchngAnagrams]
	@word VARCHAR(MAX)
AS BEGIN
	
	EXEC dbo.GetWordStatistics @word = @word, @bulk_insert = 1

	DECLARE @characters VARCHAR(MAX)
	SET @characters = [dbo].[GetCharacters](@word)

	SELECT DISTINCT [Word] FROM dbo.vw_WordStatistic
	WHERE Characters LIKE CONCAT('%', @characters, '%' )
	OR @characters LIKE CONCAT('%', [Characters], '%' )
END


GO

CREATE VIEW [dbo].[vw_WordStatistic]
AS SELECT [word].[Value] [Word], [character].[Value] [Character], [wordStatistic].TotalOccurrences, dbo.GetCharacters([word].[Value]) [Characters]
		FROM [dbo].[WordStatistic] [wordStatistic]
		INNER JOIN dbo.Word [word]
			ON [word].[Id] = [wordStatistic].[WordId]
		INNER JOIN [dbo].[Character] [character]
			ON [character].[Id] = [wordStatistic].[CharacterId]
GO

CREATE PROC [dbo].[GetWordStatistics]
	 @word VARCHAR(MAX)
	 ,@bulk_insert BIT = 0
AS
BEGIN
	IF EXISTS(SELECT [Id] = @word 
		FROM [dbo].[Word] 
		WHERE [Value] = @word)
	BEGIN
	--Try Simple Query
		IF @bulk_insert = 0
			SELECT [Character], TotalOccurrences 
			FROM [dbo].[vw_WordStatistic]
			WHERE [Word] = @word

		RETURN 0;
	END

	BEGIN TRAN AddWordTran
	BEGIN TRY
		INSERT INTO [dbo].[Word]
		(
			[Value],
			[Length]
		)
		VALUES
		(   @word, -- Value - varchar(max)
			LEN(@word)   -- Length - bigint
		)

		DECLARE @wordId INT = SCOPE_IDENTITY()

		INSERT INTO dbo.WordStatistic
		(
			CharacterId,
			WordId,
			TotalOccurrences
		)
		SELECT Id, @wordId, dbo.GetAllOccurrences([Value],@word) [count] 
		FROM [dbo].[Character]
		WHERE dbo.GetAllOccurrences([Value],@word) > 0

		COMMIT TRAN AddWordTran

		IF @bulk_insert = 1
			RETURN 0;

		SELECT [Character], TotalOccurrences 
		FROM [dbo].[vw_WordStatistic]
		WHERE [Word] = @word

		RETURN 0;
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN AddWordTran

		DECLARE @errorMessage VARCHAR(MAX)
		DECLARE @errorCode INT

		SET @errorMessage = ERROR_MESSAGE()
		SET @errorCode = ERROR_NUMBER();

		THROW 50001, @errorMessage, @errorCode;

		RETURN @errorCode
	END CATCH
END
