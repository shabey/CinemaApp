# CinemaApp

The solution is divided into 3 projects

1. CinemaApp is .Net core console app responsible for taking in user selected option from the list of menu options provided and passing the selected option to the CinemaaAppBackendRepository which act as a controller and perform action based on the option selected after the operation is completed the result is retruned back to the console App which displays the result returned.

2. CinemaAppBackend is a .Net core class library project. It contains all the business logic for the cinmea app. The project comprises of parts like interfaces, repositories, services, validations, models, extensions and utility class. The project has one main backend interface ICinemaAppBackendRepository which act as a controller and is responbile for handling user action.Each user action is treated as its own use case and all the logic for handling that use case is written in that class. The CinemaAppBackendRepository calls the appropriate use case action based on the option selected.

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

Services:
CinemaHallValidationService : Contains different types of validations required by Cinema App to validate data.
ValidateCinemaHallDimensions: Validates if user has entered valid dimensions for cinema hall i.e “number of rows” and “number of seats per row”
ValidateCinemaHall: Validates if cinema hall object is not null and if “number of rows” and “number of seats per row” are not zero.
ValidateSeatReservation: Validates if the row number and seat number entered by user fir buying ticket is valid.

Models:
1. Cinema Hall: Has properties like “number of rows” and “number of seats per row” and initializes cinema seat collection based on this input.
2. Cinema Seat: Has properties like Seat number, ticket price based on seat number and booking status for the seat (Available/Reserved)
3. Cinema Hall Statistics: Calculates different statistics based on current situation of cinema hall. the following things are calculated for now
   3.1 Number of purchased tickets
   3.2 Percentage occupied
   3.3 Current income (sum of reserved tickets)
   3.4 Potential total income (sum of all available and reserved tickets)

3. CinemaAppBackendUnitTest is a .Net core NUnit test project responsible for testing functions and services provided by CinemaAppBackend

Tools and Technologies: .Net Core 3.0, C#, Serilog, Dependency injection, NUnit, Moq 

When the application starts up, the user should be able to choose which action to take. Only upon actively choosing to stop the app, should the application end the runtime.
