
# Poll Simulator

An ASP.NET App that simulates election for SBG(Student Body Governance) at the institute.

# Functional Requirements

- Any student can nominate themselves.
- Same student cannot nominate themselves twice.
- While voting, the students needs to provide their Student ID.
- Each student ID can be used to cast only one vote.
- Admin can Generate the Result of the Election.
- Admin can generate the report of the candidates which displays the number of votes earned by each candidate.

  
# Folder Structure

The folders are created based on MVC Architecture.

![Folders](https://user-images.githubusercontent.com/58660122/129340432-4f55e881-6ba9-470a-92f9-01e179c1a80a.jpg)


### Views
This is the presentation layer which contains all the views.
- Candidates contains the form to create the Candidate. 
- Home folder contains the view of the Cast your Vote page.
- Result folder contains the view which generates the result and report

### Models

- Candidate.cs contains the model for the Candidate.
- CandidatesForElection.cs contains the model for storing the vote cast by Student
- ElectionResults.cs is the model used for generating the voting report and result.

### Repository
CandidatesRepository.cs is used as a local database to store the Candidates Informations List and the Voters list.


### Controllers

Controllers contain the business logic which interacts with the presentation layer and the Data Access Layer.

- HomeController.cs handles the requests from the Home View and handles them accordingly.
- CandidatesController.cs is used to handle the data from the Candidates View.
- ResultController.cs contains the logic to generate the Report as well as Election Results.


# Pages

### Cast Your Vote / Home View
This page displays the list of candidates who are running for the elections

![Home Page](https://user-images.githubusercontent.com/58660122/129338564-950cd4f4-674d-44ff-b764-ea944934ae79.jpg)


### Become a Candidate / Candidates View
Form to become a candidate

![Cast Vote](https://user-images.githubusercontent.com/58660122/129338798-a4a8c7d1-3617-4ba8-aa05-4a9856ae82b4.jpg)


### Validation

![CastVote](https://user-images.githubusercontent.com/58660122/129339067-317680ca-3faf-4c64-8616-5de02bea925b.jpg)

Upon voting with the same Student ID, an error message is displayed.

![AlreadyVoted](https://user-images.githubusercontent.com/58660122/129339531-32f51f29-2f6a-4eaa-a27a-59f4a4e5a26b.jpg)


### Election Result / Result View

#### Generate Report
On pressing Generate Report, the voting report is generated
![Report](https://user-images.githubusercontent.com/58660122/129339698-da15d497-7f6f-4aaf-97fd-f0bb6ec3beea.jpg)


#### Generate Result
On pressing Generate Result button, the winner and the loser are shown.
![Result](https://user-images.githubusercontent.com/58660122/129339917-b9cbe5cc-b6eb-477a-8740-069f145ff1c1.jpg)
