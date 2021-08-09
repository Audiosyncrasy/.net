# Multitracks.com Take-home Project

## Summary

### Implementing the artistDetails Page
I started by opening the solution in Visual Studio 2017. It immediately warned me that I needed to install .NET Framework 4.7.2 Developer Pack. After successfully installing the necessary framework, I ran the PowerShell command provided in the repo `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`. I was then able to run the project successfully and get to the landing page which prompted me to publish the database project and update the db connection string.

I published the database by targeting my local instance of SQL Server Express 2017. The database creation scripts ran, and I verified in SQL Server Management Studio (SSMS) that the following tables displayed and contained data:
- dbo.Album
- dbo.Artist
- dbo.Song

I also saw a table named `dbo.AssessmentSteps` that was associated with the embedded assessment tool.

After familiarizing myself with the code in the solution and the data structures, I began implementing the Artist Details page. On my first attempt, I created a new page named `artistDetails.aspx` in the root of the `multitracks.com` web project and copied the markup in the supplied `artist-details.html` file. I referenced the boilerplate configuration options and code in the `default.aspx` and `default.aspx.cs` files to update my `artistDetails.aspx` page, but when the page rendered, none of the styling was present. Looking at the `<link>` tag in the header, I determined the markup was expecting the static assets to be adjacent to the `.aspx` file. So, I moved the `artistDetails.aspx` file inside the `PageToSync` directory and the page loaded with the correct styling.

Next, I worked on crafting a draft stored procedure to collect the data I needed to feed to the front end. I utilized three of the MTDataAccess methods to execute the stored procedure and name each of the resulting tables:
- `DataAccess.SQL.Parameters.Add("@artistID", <id>)`
- `DataAccess.SQL.ExecuteStoredProcedureDS("GetArtistDetails")` (using stored procedure created above)
- `DataAccess.DataTableExtensions.SetTableNames("artistDetails", "songs", "albums")`

As I continued working, I adjusted the `GetArtistDetails` stored procedure to get the data I needed.

Next, I utilized the pattern established in the `default.aspx` page to bind the `<asp:Repeater>` element to a DataSource. In the sample markup (`artists-details.html`), the Top Songs section contains 3 tunes. So, I updated the stored procedure `GetArtistDetails` to only grab the top 3 items from the database. I didn't see a column that contained data related to a song's popularity, so I simply ordered alphabetically. In the Web Forms page, I took one of the example list items in the `#playlist` `<ul>` element to begin paramaterizing the data. As I was combing through the data, I realized the `timeSignature` column on the `Song` table appears to contain foreign keys to a `TimeSignature` table. For instance, it was immediately apparent that the id `3` references the `4/4` time signature.

### Implementing the API Project
I chose to implement the API project by creating an ASP.NET Web App within the Web directory using Web API and MVC. I ultimately settled on using attribute routing (versus conventional routing) to define the API routes. So, I updated the `WebApiConfig.cs` config file to correctly handle them (`config.MapHttpAttributeRoutes()`).

Then, I created the two controllers I would need:
- ArtistController
- SongController

I added a `using DataAccess` statement to the top of the controllers so I could utilize the MTDataAccess library to make SQL calls and manipulate DataTables.

Next, I focused on implementing the `artist/search` route. I chose to implement the methods called by the routes as interfaces (`IHttpActionResult`) so that I could send the correct HTTP response (i.e., 400 Bad Request) when an API consumer sends malformed query parameters. Both the `artist/search` and `song/list` endpoints implement error-checking.

For each of these routes, I also created corresponding stored procedures:
- GetArtistSearch (/artist/search)
- GetSongList (/song/list)
- AddArtist (/artist/add)

## Refactor Notes and Nit-picks

### multitracks.com Project
- The markdown contains an include for `footer.aspx`. However, I didn't see the path provided in the project (`#include virtual = "../includes/footer.aspx"`)
- I'm not very familiar with the preprocessor directives in ASP Web Forms (e.g., `<asp:repeater></asp:repeater`). For tables that return a single row, there *has* to be a better directive to display that row. It seems incorrect and inefficient to use the "repeater" directive to iterate through the table to grab only one row. If for some reason, the call returned more than one row, the artist tile section would not display as expected.
- I would trim zeros from the `bpm` column data. Currently, the frontend displays the bpm as a float with two trailing zeros. Based on the sample markup, it should display as an integer.
- In the artistDetails page, the `@artistID` parameter is hard-coded. Ideally, the parameters should be extracted from the URL (e.g., /PageToSync/artistDetails/{artistID})

### API Project
- The API project would be a great opportunity to use TDD. Ideally, unit tests should be implemented first as it's much easier than implementing them later, and they provide immediate feedback when the product code "breaks."
- None of the routes I implemented handle a route with no parameters. If a user were to try to POST to one of the routes with no parameters, I would expect it to return a useful error message indicating the request does not contain query parameters but should.
- I started creating a model class for Artist, but ultimately abandoned the effort for the sake of time - and because the data shapes were already defined in the database. Ideally, each data shape should have a corresponding model.
- Extract business logic from controller classes into their own classes.
- The `artst/add` endpoint doesn't have any error-checking on the query parameters. It should at least have the bare-minumum error-checking that `artist/search` and `song/list` have.
- Throughout development, I ran the API project as a separate instance from the multitracks.com project. The configuration should be updated to include the API project so it can communicate with the website project.

## Project Questions
- what is a "srcset" in the context of the Multitracks.com website? Is it used to present higher resolution images when the client calls for it?