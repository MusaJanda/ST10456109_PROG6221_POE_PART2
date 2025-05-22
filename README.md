# ST10456109_PROG6221_POE_PART2
# Cybersecurity Chatbot

A console-based chatbot designed to provide information and tips on various cybersecurity topics. This bot aims to educate users on online safety, common threats, and best practices in a friendly and interactive way.

## Table of Contents

* [Features](#features)
* [Getting Started](#getting-started)
    * [Prerequisites](#prerequisites)
    * [Setup Instructions](#setup-instructions)
* [How to Use the Chatbot](#how-to-use-the-chatbot)
* [Troubleshooting](#troubleshooting)
* [Contact](#contact)

## Features

* **Interactive Q&A:** Ask questions about various cybersecurity terms and topics.
* **Randomized Responses:** Receives different responses for the same question (from a predefined list), making interactions feel less repetitive.
* **Contextual Follow-ups:** Supports general follow-up questions like "tell me more" or "what about that" based on the previous topic.
* **Sentiment Detection:** The bot can detect certain user sentiments (e.g., worried, frustrated) and respond empathetically before providing information.
* **Personalized Greeting:** Greets the user by name.
* **Visual Elements:** Displays an ASCII art logo and can convert an image to ASCII art upon startup.
* **Audio Greeting:** Plays a voice greeting when the application starts.

## Getting Started

To run this chatbot, you'll need a C# development environment.

### Prerequisites

* **.NET SDK (e.g., .NET 6.0 or later):** You can download it from the official Microsoft .NET website.
* **Visual Studio (Recommended) or VS Code:** For easy development and compilation.
* **`System.Drawing.Common` NuGet Package:** This package is required for displaying the ASCII image, especially on non-Windows operating systems.

### Setup Instructions

1.  **Clone or Download the Repository:**
    (If this is a local project, just navigate to your project folder)

2.  **Open in Visual Studio/VS Code:**
    * Open the solution (`.sln` file) in Visual Studio, or open the project folder in VS Code.

3.  **Install NuGet Package:**
    * **For `System.Drawing.Common`:**
        * In Visual Studio: Go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution...`. Search for `System.Drawing.Common` and install it for your project.
        * In VS Code (using Terminal): Navigate to your project directory (where your `.csproj` file is) and run:
            ```bash
            dotnet add package System.Drawing.Common --version 8.0.0 # Or the latest stable version
            ```

4.  **Place `greeting.wav` (for Audio):**
    * Ensure you have a `.wav` audio file named `greeting.wav` in the same directory as your compiled executable (e.g., `CybersecurityBot/bin/Debug/netX.0/greeting.wav`).
    * **Important:** The application expects this file to be present for the audio greeting. If it's missing, you may see an error related to audio playback, but the rest of the chatbot will still function.

5.  **Place your image file (for ASCII Art Display):**
    * The application attempts to display an ASCII art representation of an image from a specific path. Ensure the image file (`Screenshot 2025-04-14 175844.png`) is located at `C:\\Users\\lab_services_student\\Desktop\\`.
    * **Note:** If this file is missing or in a different location, the ASCII image display part will not work, but the chatbot's text-based interaction will proceed normally.

6.  **Build the Project:**
    * In Visual Studio: `Build > Build Solution`.
    * In VS Code (using Terminal): Navigate to your project directory and run:
        ```bash
        dotnet build
        ```

## How to Use the Chatbot

1.  **Run the application:**
    * In Visual Studio: Press `F5` or click the "Start" button.
    * In VS Code (using Terminal): Navigate to your `bin/Debug/netX.0` (or `Release`) folder and run:
        ```bash
        dotnet CybersecurityBot.dll
        ```
    * Or, from the root project directory:
        ```bash
        dotnet run
        ```

2.  **Interact with the bot:**
    * The bot will first play a greeting sound (if available) and display the ASCII art logo and image (if image file is found).
    * It will then ask for your name. Type your name and press Enter.
    * You can then ask questions about cybersecurity.

**Examples of Questions you can ask:**

* "Tell me about **passwords**."
* "What is **phishing**?"
* "I'm **worried** about scams."
* "I feel **confused** about malware prevention."
* "Give me **password tips**."
* "What about **online safety**?"
* "Tell me **more details**." (after a previous question)
* "What about that?" (after a previous question)
* "How are you?"
* "What is your purpose?"
* "Thank you."
* "Exit."

## Troubleshooting

* **"Error playing voice greeting":**
    * Ensure the `greeting.wav` file is present in the expected location (same directory as the executable, or the hardcoded path in `AudioPlayer.cs`).
    * Verify the `.wav` file is not corrupted.
* **"Error converting image to ASCII" or no image displayed:**
    * Check if the image file (`Screenshot 2025-04-14 175844.png`) exists at `C:\\Users\\lab_services_student\\Desktop\\`.
    * Ensure the `System.Drawing.Common` NuGet package is correctly installed for your project.
    * The user running the application must have read permissions to the image file.
* **ASCII Art looks distorted or wrapped:**
    * Maximize your console window.
    * Ensure your console font is a monospaced font (like Consolas, Courier New, Lucida Console).
* **Bot doesn't recognize my question:**
    * The bot responds to specific keywords. Try rephrasing your question to include common cybersecurity terms like "password", "phishing", "malware", "virus", "scam", "privacy", "firewall", "backup", "encryption", "update", "VPN", "authentication", "social engineering", "data breach", "ransomware", "spyware", "adware", "keylogger", "DoS attack", or "cyber attack".
    * For specific tips, try phrases like "password tips" or "phishing awareness".
* **Sentiment not detected:**
    * The bot recognizes basic sentiments based on keywords like "worried", "frustrated", "curious", "confused", "overwhelmed", or "unsure". Include these words in your question.
  ## License

This project is open-source and available under the [MIT License](LICENSE.md)

## Contact

For any questions or suggestions, please contact [Musa Janda/ST10456109@imconnect.edu.za/GitHub Profile Link].
