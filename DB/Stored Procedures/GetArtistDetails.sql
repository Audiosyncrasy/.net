CREATE PROCEDURE [dbo].[GetArtistDetails]
	@artistID INT
AS
BEGIN

	SELECT
		title AS artistName,
		biography,
		imageURL,
		heroURL
	FROM dbo.Artist
	WHERE artistID = @artistID;

	SELECT TOP(3)
		artist.title AS artistName,
		song.title AS songTitle,
		album.title AS albumTitle,
		song.bpm,
		song.timeSignature,
		album.imageURL
	FROM dbo.Artist artist
	INNER JOIN dbo.Song song ON artist.artistID = song.artistID
	INNER JOIN dbo.Album album ON song.albumID = album.albumID
	WHERE artist.artistID = @artistID
	ORDER BY song.title ASC;

	SELECT 
		album.title AS albumTitle,
		album.imageURL, 
		artist.title AS artistName
	FROM dbo.Album album
	INNER JOIN dbo.Artist artist ON artist.artistID = album.artistID
	WHERE artist.artistID = @artistID;

END
GO