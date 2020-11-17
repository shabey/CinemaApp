# Background
The owners of a Cinema theater have contracted you to develop the backend of a new app, targeted both customers and internal staff. The app should include several features for a given cinema room.

When developing the application, the clients is especially interested in ensuring the following:

The application is expected to be developed further over time. Make sure this can be done without introducing new errors to the existing features.
Not all users are expected to be IT experts. Therefore, make sure that invalid inputs are handled properly and users are guided well.
Not all seats are equal! If the capacity is over 50 people, the front half rows cost $12, the back half cost $10. If capacity 50 or below, all cost $10

# Features
Build a console application in Java or C#, that implements the following features:

Receive inputs for “number of rows” and “number of seats per row” for the given cinema room.
Show an output of the seats and their status (“A” for available, “R” for reserved)
Buy a ticket for a specific seat. The user should be able to choose which seat, however only available ones.
Output metrics for the cinema room, including:
Number of purchased tickets
Percentage occupied
Current income (sum of reserved tickets)
Potential total income (sum of all available and reserved tickets)

When the application starts up, the user should be able to choose which action to take. Only upon actively choosing to stop the app, should the application end the runtime.

# Solution design 
The solution is divided into 3 projects

# 1. CinemaApp 
Cinema app is .Net core console project. It is responsible for displaying available options for cinema hall and taking in option selected by user and passing the selected option to appropriate controller. Each menu option has an associated controller which is responsible for performing action based on the option selected. After completion the result is retruned back and displayed by console app.

# 2. CinemaAppBackend 
Cinema app backend is a .Net core class library project. It contains all the business logic for the cinmea app. The project comprises of componenents like 
interfaces,repositories,services,validation handling,models,extensions and utility class. 
The project exposes one main backend interface ICinemaAppBackendRepository which is used by other projects.The backend repository contains a set of interfaces which are considered as use cases. The interface is responsible for calling appropriate use case. Each user action is associated with its own use case and all the logic for handling that use case is written in that class. The CinemaAppBackendRepository calls the appropriate use case action based on the option selected.

For the purpose of this exercise the following options are provided and are handled as seperate use cases.

Option A. Receive inputs for “number of rows” and “number of seats per row” for the given cinema room. 
All the logic for handling initializing cinema hall is provided by interface IInitializeCinemaHall. The class is responsible for initializing cinema hall object based on inout “number of rows” and “number of seats per row” . Cinema hall seats are initialized in terms of row and seats in each row.

Option B: Show an output of the seats and their status (“A” for available, “R” for reserved)
This is considered as a case for displaying current booking status for the cinema hall. The logic is contained in ShowCinemaHallCurrentStatus use case and IShowCinemaHallCurrentStatus exposes the function for printing the cinema hall seat reservaton status.

Option C: Buy a ticket for a specific seat. The user should be able to choose which seat, however only available ones.
This is considered as a case for buying cinema ticket. The user entered his desired seat number by entering row no and the seat in that row he wanted. the "BuyCinemaTicket" class has two function one for checking if the desired seat is availble for reservation or not and then the other function is actually buying ticket. When the user buys the ticket the price is calculated and booking status is set to reserved.

Option D: This is considered as the use case for getting statsitics based on current situation for cinema hall. The logic is contained inside GenerateCinemaHallStatistics use case and it uses an object of type CinemaHallStatistics which has following properties.
Output metrics for the cinema room, including:
1. Number of purchased tickets
2. Percentage occupied
3. Current income (sum of reserved tickets)
4. Potential total income (sum of all available and reserved tickets)
After calculation the object is returned to display the statistics.

Option E: Exist from cinema hall console App.

# CinemaHallValidationService: Contains different types of validations required by Cinema App to validate data
1. ValidateCinemaHallDimensions: Validates if user has entered valid dimensions for cinema hall i.e “number of rows” and “number of seats per row”</li>
2. ValidateCinemaHall: Validates if cinema hall object is not null and if “number of rows” and “number of seats per row” are not zero.</li>
3. ValidateSeatReservation: Validates if the row number and seat number entered by user fir buying ticket is valid.

# Models:
1. Cinema Hall: Has properties like “number of rows” and “number of seats per row” and initializes cinema seat collection based on this input.</li>
2. Cinema Seat: Has properties like Seat number, ticket price based on seat number and booking status for the seat (Available/Reserved)</li>
3. Cinema Hall Statistics: Calculates different statistics based on current situation of cinema hall. the following things are calculated for now 
<ul>
   <li>Number of purchased tickets</li>
   <li>Percentage occupied</li>
   <li>Current income (sum of reserved tickets)</li>
   <li>Potential total income (sum of all available and reserved tickets)</li>
</ul>

# 3. CinemaAppBackendUnitTest 
The project is a .Net core NUnit test project responsible for testing functions and services provided by CinemaAppBackend.

# Tools and Technologies: 
.Net Core 3.0, C#, Serilog, Dependency injection, NUnit, Moq 
