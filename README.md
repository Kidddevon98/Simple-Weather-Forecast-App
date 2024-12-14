# WeatherApp
A robust ASP.NET Core web application that fetches and displays weather information using the OpenWeatherMap API. This project demonstrates API integration, error handling, logging, and a responsive user interface.

## Features
- **Fetch Current Weather Data**: Enter a city name to retrieve real-time weather information, including temperature, humidity, and weather conditions.
- **Error Handling**: Comprehensive error handling to manage invalid city names, network issues, and unexpected API responses.
- **Logging**: Integrated logging to track API requests, responses, and any errors encountered during the data fetch process.
- **Responsive UI**: Modern, user-friendly interface styled with Bootstrap for a polished and accessible user experience on desktop and mobile devices.
- **Unit Testing**: Includes unit tests for core functionality to ensure the application works as expected.
- **Search History**: Automatically saves the last five cities searched for easy access to previously viewed weather information.
- **Data Persistence**: Search history is stored in an SQLite database to provide a seamless experience.

## Setup Instructions
1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/Kidddevon98/WeatherApp.git
2. **Open the Project**: Navigate to the project directory:
   Launch the project in Visual Studio Code or your preferred IDE.
   ```bash
   cd WeatherApp
3. **Configure API Key**:
   - Open [WeatherService.cs] and replace ["your-api-key"] with your OpenWeatherMap API key. 
   - Obtain an API key from [OpenWeatherMap] (https://openweathermap.org/).
4. **Restore Dependencies**: Run this command in the terminal:
   ```bash
   dotnet restore
5. **Apply Migrations**: Set up the database using:
    ```bash
    dotnet ef database update
6. **Run the Project**: Start the application using:
   ```bash
   dotnet run
7. **Open your browser**: 
   - navigate to `http://localhost:5000` (or the port displayed in the terminal).

## Testing
- **Run Unit Tests**: Use the following command:
  ```bash
  dotnet test

- **Example Test Results**:
  ```bash
  Passed! - All tests ran successfully.

## Deployment
- Due to quota restrictions on free hosting platforms and budget constraints, the WeatherApp is not currently deployed online. However, it can be run locally by following the instructions in the "Setup Instructions" section above.

## Troubleshooting
- Ensure you have .NET 8.0 installed.
- Verify your API key is correctly configured in `WeatherService.cs`.
- Run `dotnet ef database update` if you encounter database errors.
- If you receive a "port already in use" error:
  - Stop any other applications running on the same port.
  - Use a different port by running:
    ```bash
    dotnet run --urls "http://localhost:5001"
    ```
- Clear your database file if migrations fail, then reapply migrations.

## Future Improvements
- **Additional Features**: Add support for hourly and weekly forecasts, or implement location-based weather detection.
- **Enhanced Error Messages**: Provide users with clear, actionable feedback for network or API errors.
- **Deployment**: Explore alternative hosting platforms like AWS or Heroku for wider accessibility.

## Application Screenshot
Below are screenshots demonstrating the WeatherApp in action:

1. Fetching Weather Data:
   ![Fetching Weather Data](Screenshots/app-running.png)
2. Search History:
   ![Search History](Screenshots/search-history-functionality.png)
3. Error Handling:
   ![Error Handling](Screenshots/error-handling.png)

## Database Setup
This project uses SQLite for database interaction. Follow these steps to set up the database:

1. **Install Dependencies**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
2. **Apply Migrations**: Set up the database using:
    ```bash
    dotnet ef database update

## How to Use
- **Enter a City**: Type in a city name and click "Get Weather" to fetch and display the weather information.
- **View Weather Information**: The app displays temperature, feels-like temperature, weather description, humidity, wind speed, visibility, pressure, and sunrise/sunset times.
- **Recent Searches**: See the most recent five city searches displayed for quick access. 

## Technologies Used
- **ASP.NET Core**: Framework for building the web application.
- **Entity Framework Core**: For database interactions and managing search history.
- **SQLite**: Lightweight database used for storing search history.
- **Bootstrap**: Frontend framework for styling and layout.
- **OpenWeatherMap API**: Used for fetching real-time weather data.

## Logging and Debugging
- **Logs**: The application uses built-in logging to output information about API requests and error handling. Logs are helpful for debugging and monitoring the app's performance.

## Data Privacy
- **Weather Search Data**: We store the names of cities and timestamps of your searches for a better user experience. This information is stored locally and is not shared with third parties.
- **API Usage**: The app uses the OpenWeatherMap API, and data privacy terms are governed by OpenWeatherMap.