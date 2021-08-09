CREATE PROCEDURE dbo.GetArtistSearch
	@name varchar(500)
AS
BEGIN
	
	SELECT
		artistID,
		dateCreation,
		title AS artistName,
		biography,
		imageURL,
		heroURL
	FROM dbo.Artist
	WHERE title LIKE CONCAT('%', @name, '%');

END