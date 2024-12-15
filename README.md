# WeatherApp
A robust ASP.NET Core web application that fetches and displays weather information using the OpenWeatherMap API. This project demonstrates API integration, error handling, logging, and a responsive user interface.

## Features
- **Fetch Current Weather Data**: Enter a city name and state to retrieve real-time weather information, including temperature, humidity, and weather conditions.
- **Error Handling**: Handles invalid input, network issues, and unexpected API responses gracefully.
- **File-Based Logging**: Logs all errors and critical events to a file for tracking and debugging.
- **Responsive UI**: The interface is designed using Bootstrap for a modern, responsive layout. It adapts seamlessly to both desktop and mobile devices. Use browser developer tools (F12 → Mobile Emulator) to test on different screen sizes.
- **Search History**: Automatically saves the last five cities searched for easy access to previously viewed weather information.
- **Data Persistence**: Recent search history is stored locally using SQLite.

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

- # WeatherApp
A robust ASP.NET Core web application that fetches and displays weather information using the OpenWeatherMap API. This project demonstrates API integration, error handling, logging, and a responsive user interface.

## Implemented Features 
- **Fetch Current Weather Data**: Enter a city name and state to retrieve real-time weather information, including temperature, humidity, and weather conditions.
- **Error Handling**: Handles invalid input, network issues, and unexpected API responses gracefully.
- **File-Based Logging**: Logs all errors and critical events to a file for tracking and debugging.
- **Responsive UI**: The interface is designed using Bootstrap for a modern, responsive layout. It adapts seamlessly to both desktop and mobile devices. Use browser developer tools (F12 → Mobile Emulator) to test on different screen sizes.
- **Search History**: Automatically saves the last five cities searched for easy access to previously viewed weather information.
- **Data Persistence**: Recent search history is stored locally using SQLite.

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
- Troubleshooting Logs: If issues occur, check the logs/weatherapp.log file for details on errors and API responses. 

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
- **Enter a City and State**: Type in a city name and state code (e.g., Lexington,KY) and select your preferred temperature unit (Fahrenheit or Celsius). Click "Get Weather" to fetch and display the weather information.
- **View Weather Information**: The app displays temperature, feels-like temperature, weather description, humidity, wind speed, visibility, pressure, and sunrise/sunset times.
- **Recent Searches**: See the most recent five city searches displayed for quick access. 

## Technologies Used
- **ASP.NET Core**: Framework for building the web application.
- **Entity Framework Core**: For database interactions and managing search history.
- **SQLite**: Lightweight database used for storing search history.
- **Bootstrap**: Frontend framework for styling and layout.
- **OpenWeatherMap API**: Used for fetching real-time weather data.

## Logging and Debugging
- **Logs**: The application implements file-based logging to track API requests, errors, and other critical events. Logs are stored locally in a file located at:
/Logs/weatherapp.log.
This allows for easier error tracking and debugging.

## Data Privacy
- **Weather Search Data**: We store the names of cities and timestamps of your searches for a better user experience. This information is stored locally and is not shared with third parties.
- **API Usage**: The app uses the OpenWeatherMap API, and data privacy terms are governed by OpenWeatherMap.

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
- Troubleshooting Logs: If issues occur, check the logs/weatherapp.log file for details on errors and API responses. 

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
- **Enter a City and State**: Type in a city name and state code (e.g., Lexington,KY) and select your preferred temperature unit (Fahrenheit or Celsius). Click "Get Weather" to fetch and display the weather information.
- **View Weather Information**: The app displays temperature, feels-like temperature, weather description, humidity, wind speed, visibility, pressure, and sunrise/sunset times.
- **Recent Searches**: See the most recent five city searches displayed for quick access. 

## Technologies Used
- **ASP.NET Core**: Framework for building the web application.
- **Entity Framework Core**: For database interactions and managing search history.
- **SQLite**: Lightweight database used for storing search history.
- **Bootstrap**: Frontend framework for styling and layout.
- **OpenWeatherMap API**: Used for fetching real-time weather data.

## Logging and Debugging
- **Logs**: The application implements file-based logging to track API requests, errors, and other critical events. Logs are stored locally in a file located at:
/Logs/weatherapp.log.
This allows for easier error tracking and debugging.

## Data Privacy
- **Weather Search Data**: We store the names of cities and timestamps of your searches for a better user experience. This information is stored locally and is not shared with third parties.
- **API Usage**: The app uses the OpenWeatherMap API, and data privacy terms are governed by OpenWeatherMap.