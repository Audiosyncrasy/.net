CREATE PROCEDURE [dbo].[GetArtistDetails]
	@artistID INT
AS
BEGIN

	SELECT *
	FROM dbo.Artist
	WHERE artistID = @artistID;

	SELECT a.title AS artistName, s.title
	FROM dbo.Song s
	LEFT JOIN dbo.Artist a ON s.artistID = a.artistID
	WHERE a.artistID = @artistID;

	SELECT *
	FROM dbo.Album
	WHERE artistID = @artistID;

END
GO