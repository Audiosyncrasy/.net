using DataAccess;
using System;

public partial class ArtistDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] tableNames = new string[] { "artistDetails", "songs", "albums" };

        var sql = new SQL();

        sql.Parameters.Add("@artistID", 107);
        var data = sql.ExecuteStoredProcedureDS("GetArtistDetails").SetTableNames(tableNames);

        artistDetails.DataSource = data.Tables["artistDetails"];
        artistDetails.DataBind();

        topSongs.DataSource = data.Tables["songs"];
        topSongs.DataBind();

        albumList.DataSource = data.Tables["albums"];
        albumList.DataBind();

        artistBio.DataSource = data.Tables["artistDetails"];
        artistBio.DataBind();
    }
}