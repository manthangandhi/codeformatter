# Code Formatter App

**Version:** v1.0

## Overview

The Code Formatter App is a lightweight Windows Forms application designed to format source code for various languages (C#, VB.NET, SQL). It leverages built-in formatting libraries—such as Roslyn for C# and VB.NET—to ensure your code is clean, consistent, and easy to read.

## Features

- **Multi-Language Support:** Format code written in C#, VB.NET, and SQL.
- **User-Friendly Interface:** Simple UI with text boxes for inputting source code and displaying formatted output.
- **Progress Indicator:** Visual progress bar during formatting.
- **Robust Logging:** Logs key actions and errors for easier troubleshooting.
- **Error Handling:** Displays user-friendly error messages.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Visual Studio Code (or your preferred C# IDE)
- Git (for source control)

### Installation

1. **Clone the Repository:**
    
    ```
    git clone https://github.com/yourusername/codeformatter.git
    cd codeformatter

2. **Restore NuGet Packages:**
    
    ```
    dotnet restore

3.	**Build the Project:**

If you have multiple project or solution files in the repository, specify the project file:


    dotnet build ocodeformat.csproj

### Running the app

For Windows Forms applications, you can run the app using the following command:

    dotnet run --project ocodeformat.csproj

Alternatively, open the project in your IDE and run it directly.

### Usage

1.	**Launch the Application:** 
Open the app via Visual Studio Code or run the executable found in the bin/Debug/net8.0-windows directory.

2.	**Select a Language:**
Choose the code language (C#, VB.NET, or SQL) from the dropdown menu.

3.	**Input Code:**
Paste or type your unformatted source code into the “Source Code” text box.

4.	**Format Code:**
Click the “Format” button. The formatted code will appear in the output text box.

5.	**Clear Code:**
Use the “Clear” option to reset your input and output fields.

6.	**Contact Information:**
For any issues or feedback, select the “Contact” option in the menu to view support information.

### Contributing

Contributions to Code Formatter App are welcome! If you have ideas for improvements or bug fixes, please submit an issue or pull request via GitHub.

### License

This project is licensed under the MIT License.

### Contact

For any issues, queries, or feedback, please contact:
 - Manthan Gandhi
 - Email: manthann@gmail.com

Thank you for using Code Formatter App!
