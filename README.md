# WeatherApp
A robust ASP.NET Core web application that fetches and displays weather information using the OpenWeatherMap API. This project demonstrates API integration, error handling, logging, and a responsive user interface.

## Features
- **Fetch Current Weather Data**: Enter a city name to retrieve real-time weather information, including temperature, humidity, and weather conditions.
- **Error Handling**: Comprehensive error handling to manage invalid city names, network issues, and unexpected API responses.
- **Logging**: Integrated logging to track API requests, responses, and any errors encountered during the data fetch process.
- **Responsive UI**: Modern, user-friendly interface styled with Bootstrap for a polished and accessible user experience.
- **Unit Testing**: Includes unit tests for core functionality to ensure the application works as expected.
- **Search History**: Automatically saves the last five cities searched for easy access to previously viewed weather information.
- **Data Persistence**: Search history is stored in an SQLite database to provide a seamless experience.

## Setup Instructions
1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/Kidddevon98/WeatherApp.git
2. **Open the Project**:
   Launch the project in Visual Studio Code.
3. **Configure API Key**:
   Open [WeatherService.cs] and replace ["your-api-key"] with your OpenWeatherMap API key by creating an account on [OpenWeatherMap] (https://openweathermap.org/).
4. **Restore Dependencies**:
   ```bash
   dotnet restore
5. **Apply Migrations**:
    ```bash
    dotnet ef database update
6. **Run the Project**:
   ```bash
   dotnet run

## Database Setup
This project uses SQLite for database interaction. Follow these steps to set up the database:

1. **Install Dependencies**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite


## How to Use
- **Enter a City**: Type in a city name and click "Get Weather" to fetch and display the weather information.
- **View Weather Information**: The app displays temperature, feels-like temperature, weather description, humidity, wind speed, visibility, pressure, and sunrise/sunset times.
- **Recent Searches**: See the most recent five city searches displayed for quick access. 

## Testing
- **Run Unit Tests**:
  ```bash
  dotnet test
 - Unit tests are provided to verify the functionality of the WeatherService and ensure reliable performance

## Technologies Used
- **ASP.NET Core**: Framework for building the web application.
- **Entity Framework Core**: For database interactions and managing search history.
- **SQLite**: Lightweight database used for storing search history.
- **Bootstrap**: Frontend framework for styling and layout.
OpenWeatherMap API: Used for fetching real-time weather data.

## Logging and Debugging
- **Logs**: The application uses built-in logging to output information about API requests and error handling. Logs are helpful for debugging and monitoring the app's performance.

## Future Improvements
- **Additional Features**: Add weather forecast for multiple days or integrate more advanced visual components.
- **Enhanced Error Messages**: Provide more specific feedback based on the type of error encountered.
- **Deployment**: Consider deploying the app to Azure or another cloud service for wider accessibility.

## Data Privacy
- **Weather Search Data**: We store the names of cities and timestamps of your searches for a better user experience. This information is stored locally and is not shared with third parties.
- **API Usage**: The app uses the OpenWeatherMap API, and data privacy terms are governed by OpenWeatherMap.