# StyleMate

StyleMate is a web application that helps users find matching clothing items based on a selected piece of clothing. For example, if you select a brown t-shirt, the application will suggest pants and shoes that match well with it.

## Features

- Add new clothing items with a type selection (e.g., T-shirt, Pants, Shoes).
- View a list of all added clothing items.
- Find matching clothing items for a selected piece of clothing.
- Responsive design with Razor Pages for front-end.

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
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

2. Use the navigation menu to add new clothing items and find matches.

## Project Structure

- `ClothingMatcher/` - Main project directory
  - `Pages/` - Contains Razor Pages
    - `Index.cshtml` - Home page
    - `Create.cshtml` - Page to add new clothing items
    - `Delete.cshtml` - Page to delete clothing item
    - `Details.cshtml` - Page to view details and find matches
    - `Edit.cshtml` - Page to edit clothing item
    - `FindMatches.cshtml` - Page to view matching pairs for select cloth item.
  - `wwwroot/` - Static files (CSS, JS, images)
  - `Data/` - Contains the data service and in-memory storage
  - `Models/` - Contains the Clothing model

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please contact:

- Name: Harshil Patel
- Email: 26harshilpatel@gmail.com

## Certificate

[Microsoft Azure Developer Certificate (AZ204)](https://learn.microsoft.com/en-us/users/harshilpatel-1280/credentials/certification/azure-developer?tab=credentials-tab)

