# HackerNews-API

# The .NET Version Used

1. Language C#
2. .NET Core ver 10

# Environment of Development OR IDE user for Developement

Visual Studio Community 2026

# Set the correct project Run/Execute

1. Locate the "CodingExercise.Santander.HackerNews.slnx" file. And Open in Visual Studio Community 2026 or Higher IDE
2. Ensure the project CodingExercise.Santander.HackerNews.WebAPI is a Startup project
	If Not
	a. Select the project in the Solution Explorer
	b. Then right click Project "CodingExercise.Santander.HackerNews,WebAPI"
	c. In the context/popup menu select the option "Set as Startup Project"

# Run / Execute the Project

1. After completing or following the above steps. We are set to run the project
2. Either click the Green Play Button with "https" in the Toolbar
OR
2. Navigate and Click the following menu item from the top menu bar i.e.
	Click "Debug->Start Debugging"
OR
3. Press "F5" key on the keyboard

This will run the project and will show open a Console window.

# Test the application working

1. Open a browser of your choice and copy either of the links listed below Click one of the links shown in the 
	"https://localhost:7266/scalar/"
	OR 
	"http://localhost:5263/scalar/"
2. On the left hand, the UI lists the Controllers and its functions available for calling/testing. It also lists the Models that the API is using or exposes.
3. Click on the "HNBestStories" -> "/api/HNBestStories/GetTopNBestStories"
4. Step 3 will navigate the right hand side of the screen the API function.
5. Click the "Test Request" button
6. Step 5 will open a dialog screen
7. Locate the "noOfTopBestStories" parameter in the "Query Parameter" section which should be below "Headers" section.
8. IMPORTANT => Click the Checkbox on the left hand-side of the "noOfTopBestStories" paramater else, Scalar does not pass the given value.
8. Type an integer value in the "Value" box and Click "Send" button at the top of the dialog screen.


# Structure of the Solution

The project or the Solution follows a Hexagonal Architecture or Project Structure

Following is the flow of call (even the references)

"CodingExercise.Santander.HackerNews.WebAPI"
				|
				|
				V
"Application/Services/CodingExercise.Santander.HackerNews.BusinessServices"
				|
				|
				V
"Adapters/CodingExercise.Santander.FirebaseIONewsServices"
