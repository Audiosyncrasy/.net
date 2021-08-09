CREATE PROCEDURE dbo.GetSongList
	@pageSize int,
	@pageNumber int
AS
BEGIN

		SELECT
			song.songID,
			song.title AS songTitle,
			album.title AS albumTitle,
			artist.title AS artistName,
			song.bpm
		FROM dbo.Song song
		INNER JOIN dbo.Artist artist ON artist.artistID = song.artistID
		INNER JOIN dbo.Album album ON song.albumID = album.albumID
		ORDER BY
			artistName ASC,
			albumTitle ASC
		OFFSET (@pageNumber - 1)*@pageSize ROWS
		FETCH NEXT @pageSize ROWS ONLY

END