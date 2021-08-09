CREATE PROCEDURE dbo.AddArtist
	@title varchar(100),
	@biography varchar(max),
	@imageURL varchar(500),
	@heroURL varchar(500)
AS
BEGIN

	INSERT INTO dbo.Artist (
		title,
		biography,
		imageURL,
		heroURL
	)
	VALUES (
		@title,
		@biography,
		@imageURL,
		@heroURL
	)
	SELECT CAST(SCOPE_IDENTITY() AS int) AS artistID;

END
