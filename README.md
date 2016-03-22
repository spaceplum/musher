# Musher

Get music recommendations. Explore artists and genres.

## Usage

Build the application from source (the `src` folder) or run the release build from the `dist` folder.

## Build manually

Build the solution with Visual Studio, run the `Musher.Web` web application and view it in your browser.
Enter the EchoNest API key into the `appsettings` section in the `AppSettings.config` file (see below).

## Run the release

Create a website in the Internet Information Services (IIS) and set its path to the `dist` folder.
Make sure the correct file system permissions are set for the folder.
Enter the EchoNest API key into the `appsettings` section in the `Web.config` file (see below).

### System requirements

Microsoft ASP .NET Framework 4.5.2.

## Configuration

Application settings are stored in the `Web.config` file (and the `AppSettings.config` file during development).

### Application settings

- `EchoNestApiUrl`:
Base url to the EchoNest API, e.g. http://developer.echonest.com/api/v4/

- `EchoNestApiKey`:
EchoNest API key, see http://developer.echonest.com/docs/v4/index.html#keys for info.

#### Development

To avoid storing application settings in source control the file `AppSettings.config` is used.
The application setting `EchoNestApiKey` should be defined in this file.

Create a file `AppSettings.config` in the Musher.Web folder with this content:

    <appSettings>
        <add key="EchoNestApiKey" value="EchoNest api key" />
    </appSettings>
