using DataAccess;
using System;

public partial class ArtistDetails : MultitracksPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();

        sql.Parameters.Add("@artistID", 5);
        var data = sql.ExecuteStoredProcedureDS("GetArtistDetails");

        artistDetails.DataSource = data;
        artistDetails.DataBind();

    }
}