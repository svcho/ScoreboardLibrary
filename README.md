# Live Football World Cup Scoreboard Library

This is a simple library implementation for managing ongoing football matches and their scores, following the requirements provided in the task description. The library provides a way to start new matches, update scores, finish matches, and retrieve a summary of matches in progress ordered by their total score.

## Usage

To use this library, you can follow these steps:

1. Clone the repository or integrate the provided classes into your project.
2. Create an instance of the `Scoreboard` class to manage ongoing matches:

   ```csharp
   IScoreboard scoreboard = new Scoreboard();
   ```
3. Start matches, update scores, and finish matches using the provided methods:

   ```csharp
   // Start a new match
	scoreboard.StartMatch("Mexico", "Canada");

	// Update scores for a match
	scoreboard.UpdateScore("Mexico", "Canada", 0, 5);

	// Finish a match
	scoreboard.FinishMatch("Mexico", "Canada");
   ```
   
 4. Retrieve a summary of matches in progress ordered by their total score:

    ```csharp   
	var matchesInProgress = scoreboard.GetMatchesInProgressOrderedByScore();
	foreach (var match in matchesInProgress)
	{
		Console.WriteLine($"{match.HomeTeam} {match.HomeScore} - {match.AwayTeam} {match.AwayScore}");
	}
	```
 
 ## Running Tests
 
 The project includes unit tests to verify the functionality of the library. These tests are implemented using Xunit and can be run using a test runner of your choice.
 
 1. Install the Xunit NuGet package if not already installed:
 
     ```csharp   
	 dotnet add package Xunit
	```
	
2. Run the tests using the following command:
 
    ```csharp
	dotnet test	
	```

## Assumptions

Please note the following assumptions made during the implementation:

1. Match order identifiers are used to distinguish matches with the same total score. The higher the order identifier, the more recently the match was started.
2. Team names are case-sensitive and must not be empty or contain only whitespace.
3. Negative scores are not allowed for updates.
4. Matches between the same teams cannot be started simultaneously.

## Feedback and Improvements

If you have any feedback, suggestions for improvements, or encounter issues with the library, please feel free to open an issue on this repository.