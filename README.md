# Plumsail

> [Go to installation instructions](#installation)

## A task for candidates for full-stack developer (C#, JavaScript)

### Prerequisites

It is okay if you didn’t work with Vue 2 or 3, if you know React or Angular you will learn it fast. We use both Vue 2 and 3 in our projects.

#### Part 1

You need to develop a tiny application for submitting web forms, storing submissions, listing and searching them.

1. Create an arbitrary form with CSS and Vue as a JavaScript framework. Say, a contact or order form with at least five fields of different types: text, drop-down, date, radio, checkbox.

2. Add validation for the form fields.

3. Implement a REST-service using C# and ASP.NET Core:

   a. The service should provide all necessary methods for your frontend.

   b. It should allow receiving and storing submissions without hard coded models. Imagine there is another frontend application with different form fields that uses the same backend. Backend should know nothing about the data structure

   c. For storing your data, use either In-Memory database or any other storage that won’t require us to set up database servers or register in any online services. It is easier for us to review your task this way.

4. Add UI for listing and searching the submitted objects from different forms on one page.

5. Pack all JS- and CSS-files of the project into a single file with the help of a build system of your choice (Vite or Webpack).

The test task is quite basic but consider it as a real-life application. Thus, try to create good architecture and level of abstraction. We will evaluate the quality of your code, your tool chain, usability of the UI and the architecture in general.

#### Part 2

Now, let's imagine the web forms support large attachments (~100MB). Describe in text how to handle storage and downloads from the submissions list, considering thousands of submissions with multiple attachments each. Include architecture, data structure, and REST API.

Results Send results to [recruitment@plumsail.com](mailto:recruitment@plumsail.com) with the link to your HH resume.

### Deadlines

There is no strict deadline. We understand that you may be working on another job. It would be great if you could complete it in a week.

---

## Authors

Contributors names and contact info

- Kim Fom - [kimfom01@gmail.com](mailto:kimfom01@gmail.com)

---

## Installation

### Requirements

- Ensure [.NET SDK/Runtime](https://dot.net) (version 9.0) is installed.

### Getting the Project

- Clone the repository: `git clone https://github.com/kimfom01/Plumsail.git`
- Alternatively, download and extract the project ZIP file.

### Running the Application

#### Backend

- From the root directory navigate to the `backend/Plumsail` directory

  ```bash
  cd backend/Plumsail
  ```

- Restore dependencies

  ```bash
  dotnet restore
  ```

- Execute the run command to start the backend server.

  ```bash
  dotnet run
  ```

- Open `http://localhost:5260/swagger` on the web browser to access the swagger documentation.

#### Frontend
