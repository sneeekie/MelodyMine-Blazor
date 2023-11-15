
# Project Template TODO

Ensure the following tasks are completed before using the template for a new project:

- [ ] Update `appsettings.json` with the correct connection string for the target database.
- [ ] Configure Dependency Injection in `Startup.cs` or `Program.cs` for:
    - [ ] Repositories
    - [ ] Services
    - [ ] AutoMapper / AutoMapper Profile
    - [ ] Any other services required by the application
- [ ] Run Entity Framework migrations to set up the database schema:
    - [ ] `dotnet ef migrations add InitialCreate`
    - [ ] `dotnet ef database update`
- [ ] Review and update the `LICENSE` file to match the intended use of the project.
- [ ] Fill out the `README.md` with:
    - [ ] Project description
    - [ ] Setup instructions
    - [ ] Usage instructions
- [ ] Ensure all project references are correct and necessary NuGet packages are installed.
- [ ] Remove or update namespace references to match the new project's structure.
- [ ] Set up the initial unit tests and ensure they pass.
- [ ] Check API endpoints and ensure they are correctly wired up.
- [ ] Verify that the Blazor UI is correctly communicating with the WebAPI.
- [ ] Configure the CI/CD pipeline for automated testing and deployment.
- [ ] Review the entire solution for any template placeholders or default values that need to be customized.
- [ ] Remove root/README.md and replace docs/README.md