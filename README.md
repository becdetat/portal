# Servs-up portal

This uses:
- ASP.NET Core
- .NET 7
- SQLite
- Vue
- TypeScript


This is a devcontainer, so use VS Code to start the Docker container. (See **Environment** for more details.)

Rather than use Vite to serve the frontend, we're using it to build the frontend statically (in a watch loop) and write it to the `wwwroot` folder within the API. The API then serves the frontend statically from the root request path. This keeps things simple - a single server, a consistent production deploy story, and no annoying CSRF issues in development.


## Initial setup and getting runnint
### Environment
As this is a devcontainer, it needs a Docker container for it to work in development.

1. Install Docker
2. Install the `Dev Containers` extension in VS Code

To run commands within the container use the terminal in VS Code.


### Frontend
1. `cd frontend`
2. `npm install`
3. `npm run build-and-watch`

The `npm run build-and-watch` command enters a watch loop which builds the frontend and writes it to `../backend/wwwroot` (which is served by the API).


### Backend
1. `cd backend/Api`
2. `dotnet run`

The API serves the `wwwroot` folder using `app.UseDefaultFiles(); app.UseStaticFiles();` in `Program.cs`.


## EF Migrations
It uses a SQLite database, currently just stored at `backend/Domain/portal.db`. This will need to be moved to somewhere where it can be treated as a volume by Docker, for persistence across docker compose runs.

Install the EF tooling: `dotnet tool install --global dotnet-ef`

To update after a model change:

```
dotnet ef migrations add <name-of-migration>
dotnet ef database update
```




<p class="attribution">"<a target="_blank" rel="noopener noreferrer" href="https://www.flickr.com/photos/14681861@N00/9846971334">Purple Star Cluster</a>" by <a target="_blank" rel="noopener noreferrer" href="https://www.flickr.com/photos/14681861@N00">Michael Taggart Photography</a> is licensed under <a target="_blank" rel="noopener noreferrer" href="https://creativecommons.org/licenses/by-nc/2.0/?ref=openverse">CC BY-NC 2.0 <img src="https://mirrors.creativecommons.org/presskit/icons/cc.svg" style="height: 1em; margin-right: 0.125em; display: inline;"></img><img src="https://mirrors.creativecommons.org/presskit/icons/by.svg" style="height: 1em; margin-right: 0.125em; display: inline;"></img><img src="https://mirrors.creativecommons.org/presskit/icons/nc.svg" style="height: 1em; margin-right: 0.125em; display: inline;"></img></a>. </p>





