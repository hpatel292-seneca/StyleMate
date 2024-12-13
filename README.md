# StyleMate

StyleMate is a web application that helps users manage their wardrobe and find matching clothing items. Users can securely add, view, edit, and delete their clothing items. The application also suggests matching clothing items based on a selected piece of clothing. Additionally, StyleMate leverages GROQ LLM to generate intelligent responses and suggestions and integrates real-time weather insights to personalize recommendations based on the current conditions.

Product Demo: https://www.youtube.com/watch?v=7gpc8KWD5GI

## Features

- **User Authentication and Authorization**:
  - Secure login and registration functionality using ASP.NET Core Identity.
  - Only authenticated users can access the application's features.
  - Each user can only view, add, edit, and delete their own clothing items.

- **User-Specific Clothing Management**:
  - Add clothing items that are associated with the logged-in user.
  - View a list of clothing items that belong to the authenticated user.
  - Edit and delete clothing items securely, ensuring only the item's owner can modify or delete it.

- **Clothing Matching Suggestions**:
  - Find matching clothing items for a selected piece of clothing based on the type (e.g., suggest pants and shoes that match a selected top).
  - **AI-Powered Recommendations**: StyleMate integrates GROQ LLM, a large language model, to generate intelligent suggestions and responses, enhancing the matching process and overall user experience with personalized insights.
  - **Weather-Based Recommendations**: The application integrates a real-time weather API to suggest outfits tailored to the current weather in the user's location, providing practical and context-aware advice.
 
- **Pipeline and Deployment**:
  - A **CI/CD pipeline** has been set up to deploy the application directly to an Azure Web App.
  - Since the free version of Azure Web App does not support deployment slots, a separate staging web app (`stylemate-staging`) was created.
  - The pipeline deploys the application to the staging web app and runs Playwright E2E tests on it. If all tests pass, the pipeline then deploys the application to the production web app.

- **Unit and E2E Testing**:
  - Comprehensive unit tests using xUnit and Moq for ensuring reliability of core logic.
  - End-to-end tests using Selenium to validate the application's UI and user flows.

- **Responsive Design**:
  - Built with Razor Pages for a responsive and user-friendly front-end.

---

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recommended) or any other code editor of your choice

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/ClothingMatcher.git
    cd ClothingMatcher
    ```

2. Open the project in Visual Studio 2022.

3. Restore the dependencies:
    ```bash
    dotnet restore
    ```

4. Build and run the project:
    ```bash
    dotnet run
    ```

### Running the Application

1. Open your browser and navigate to `https://localhost:5001` or the specified URL in your terminal.

2. Register a new user account or log in if you already have an account.

3. Use the navigation menu to:
   - Add new clothing items.
   - View your wardrobe.
   - Find AI-powered matches for your clothing items.
   - Get weather-based outfit suggestions.

---

## Project Structure

- `StyleMate/` - Project directory
  - `StyleMate/` - Main project directory 
    - `Pages/` - Contains Razor Pages
      - `Index.cshtml` - Home page showing user-specific items
      - `Create.cshtml` - Page to add new clothing items
      - `Delete.cshtml` - Page to delete a clothing item (only accessible to item owner)
      - `Details.cshtml` - Page to view details and find matches (only accessible to item owner)
      - `Edit.cshtml` - Page to edit a clothing item (only accessible to item owner)
      - `FindMatches.cshtml` - Page to view AI-powered matching pairs for selected clothing items, now including weather-based recommendations
    - `wwwroot/` - Static files (CSS, JS, images)
    - `Data/` - Contains the data service and database context
    - `Models/` - Contains the Clothing model and Identity user configuration for ownership association
    - `Services/` - Contains business logic for handling clothing items, weather API integration, and GROQ LLM interactions
    - `Tests/` - Contains unit and E2E tests for the application
  - `Stylemate.Tests/` - Xunit testing project
  - `StyleMate.E2ETests` - Playwright tests
---

## Security

- **ASP.NET Core Identity**: Manages authentication and authorization, ensuring only registered and logged-in users can access the application's features.
- **Role-Based Access Control**: Only authorized users can view, edit, or delete their own clothing items, preventing unauthorized access to other users' data.

---

## AI-Powered Insights and Weather Integration

- **GROQ LLM Integration**:
  - StyleMate uses GROQ LLM to generate intelligent responses and suggestions, enhancing the matching process by providing AI-powered recommendations and insights tailored to the user's wardrobe and preferences.

- **Real-Time Weather API**:
  - Integrates a weather API to fetch real-time weather data based on the user's location.
  - Provides weather-aware clothing recommendations, ensuring practicality and comfort.

---

## Testing and Quality Assurance

- **Unit Testing**:
  - Tests for core logic using xUnit.
  - Mocking services with Moq for isolated testing of Razor Page models and business logic.

- **End-to-End Testing**:
  - Playwright-based tests to validate critical user flows, including adding clothing, finding matches, and weather-based recommendations.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

For any inquiries or support, please contact:

- Name: Harshil Patel
- Email: 26harshilpatel@gmail.com

---

## Certificate

[Microsoft Azure Developer Certificate (AZ204)](https://learn.microsoft.com/en-us/users/harshilpatel-1280/credentials/certification/azure-developer?tab=credentials-tab)
