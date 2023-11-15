
# Project Template

This project template is designed to provide a starting point for .NET 7 projects using a layered architecture with a WebAPI, a Blazor WebAssembly client, and separate class library projects for Business Logic Layer (BLL) and Data Access Layer (DAL).

## Forking the Template

To use this template for a new project, you can fork the repository and then clone it to your local machine.

```bash
$ git clone https://github.com/your-username/Project-Template.git
$ cd Project-Template
```

## Setup Instructions

1. **Database Configuration:**
   Update the connection string in `appsettings.json` and `appsettings.Development.json` to match your database settings.

2. **Install Dependencies:**
   Ensure that all NuGet packages are restored properly by running:

   ```bash
   $ dotnet restore
   ```

3. **Run Migrations:**
   Apply the Entity Framework migrations to create your database schema:

   ```bash
   $ dotnet ef database update
   ```

4. **Run the Projects:**
   Start the WebAPI and the Blazor WebAssembly projects:

   ```bash
   $ dotnet run --project ./WebAPI/WebAPI.csproj
   $ dotnet run --project ./UI/UI.csproj
   ```

## Development Notes

- When developing, use the development app settings provided in `appsettings.Development.json`.
- For testing, configure and run the xUnit test project using your preferred test runner.
- Use the provided `swagger` configuration to test your WebAPI endpoints.

## Customization

- Modify the `MappingProfile` in the BLL project to define object mappings.
- Implement your business logic in the services defined under the BLL project's `Services` folder.

## Deployment

Before deploying the application, ensure the production connection string and any other environment-specific settings are configured correctly in the production app settings file.

## Contributing

If you wish to contribute to the template, consider the following steps:

1. Create a branch for your feature or fix.
2. Implement your changes.
3. Write tests to cover the new functionality.
4. Create a pull request targeting the main branch.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.
