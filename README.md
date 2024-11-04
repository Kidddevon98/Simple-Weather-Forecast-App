# WeatherApp
A robust ASP.NET Core web application that fetches and displays weather information using the OpenWeatherMap API. This project demonstrates API integration, error handling, logging, and a responsive user interface.

## Features
- **Fetch Current Weather Data**: Enter a city name to retrieve real-time weather information, including temperature, humidity, and weather conditions.
- **Error Handling**: Comprehensive error handling to manage invalid city names, network issues, and unexpected API responses.
- **Logging**: Integrated logging to track API requests, responses, and any errors encountered during the data fetch process.
- **Responsive UI**: Modern, user-friendly interface styled with Bootstrap for a polished and accessible user experience.
- **Unit Testing**: Includes unit tests for core functionality to ensure the application works as expected.

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
5. **Run the Project**:
   ```bash
   dotnet run

## How to Use
- **Enter a City**: Type in a city name and click "Get Weather" to fetch and display the weather information.
- **Error Messages**: If the city name is invalid or data cannot be fetched, a user-friendly error message will be displayed. 

## Testing
- **Run Unit Tests**:
  ```bash
  dotnet test
 - Unit tests are provided to verify the functionality of the WeatherService and ensure reliable performance

## Technologies Used
- **ASP.NET Core**: Backend framework for building the web application.
- **HttpClient**: For making API requests to OpenWeatherMap.
- **Newtonsoft.Json**: Parsing JSON data from the API response.
- **Bootstrap**: Styling the user interface.
- **xUnit**: Testing framework for unit tests.

## Logging and Debugging
- **Logs**: The application uses built-in logging to output information about API requests and error handling. Logs are helpful for debugging and monitoring the app's performance.

## Future Improvements
- **Data Persistence**: Save search history or favorite cities for future reference.
- **Enhanced Error Messages**: Provide more specific feedback based on the type of error encountered.
- **Deployment**: Consider deploying the app to Azure or another cloud service for wider accessibility.