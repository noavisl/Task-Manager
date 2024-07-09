
# Task Manager

Task Manager is a sophisticated application designed to optimize the workflow for developers. This project helps team leaders assign tasks efficiently and ensures that each task is matched with the most suitable developer based on their skills and availability.

## Features

- **Add Tasks**: Easily add new tasks with a title and description.
- **Edit Tasks**: Modify existing tasks.
- **Delete Tasks**: Remove tasks that are no longer needed.
- **Task Prioritization**: Set priority levels for tasks (Low, Medium, High).
- **Completion Status**: Mark tasks as complete or incomplete.
- **Search**: Quickly search for specific tasks.
- **Developer Matching**: Algorithmically assigns tasks to the most suitable developers.
- **Responsive Design**: Works on both desktop and mobile devices.

## Developer Matching Algorithm

The core feature of this Task Manager is its intelligent task assignment algorithm. Developed to streamline the workflow for programmers, the algorithm takes into account:

- **Programming Languages**: The languages each developer knows.
- **Proficiency Levels**: How proficient the developer is in each language.
- **Experience**: The developer's overall experience in relevant fields.
- **Availability**: The developer's schedule and vacation plans.

The algorithm is based on the **Hungarian Algorithm**, which is used to solve assignment problems in polynomial time. It ensures an optimal matching of tasks to developers, minimizing the overall cost and maximizing efficiency.

### Hungarian Algorithm

The Hungarian Algorithm, also known as the Kuhn-Munkres algorithm, is a combinatorial optimization algorithm that solves the assignment problem in polynomial time. It works by constructing a matrix where each cell represents the cost of assigning a particular developer to a task. The algorithm then finds the minimum cost perfect matching, ensuring that each task is assigned to the most suitable developer.

## Installation

To run this project locally, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/noavisl/Task-Manager.git
    ```

2. Navigate to the project directory:
    ```bash
    cd Task-Manager
    ```

3. Install the necessary dependencies:
    ```bash
    npm install
    ```

4. Start the application:
    ```bash
    ng serve
    ```

## Usage

Once the application is running, open your browser and go to `http://localhost:4200`. Team leaders can start adding tasks, and the system will automatically assign them to the best-suited developers.

## Project Components

This section provides detailed information about each component of the Task Manager project:

### Home Page
General homepage where users can sign up, log in, and find general information about the system.
![Home Page](Description%20pictures/HomePage.png)

### Sign In Page
Login page for accessing the Task Manager.
![Sign In Page](Description%20pictures/SignIn.png)

### Sign Up Page
Registration page for creating a new account.
![Sign Up Page](Description%20pictures/SignUp.png)

### About Us Page
Provides information about the project and the team behind it.
![About Us](Description%20pictures/AboutUs.png)

### Manager Home Page
Shows tasks assigned to managers and buttons to add new tasks and employees.
![Manager Home Page 1](Description%20pictures/HomePageManager1.png)

![Manager Home Page 2](Description%20pictures/HomePageManager2.png)

### Add Employee Page
Allows the team leader to add a new employee to the system.
![Add Employee](Description%20pictures/AddEmployee.png)

### Add Task Page
Interface for creating new tasks, specifying details like title, description, and priority.
![Add Task](Description%20pictures/AddTask.png)

### Employee Home Page
Displays tasks assigned to employees and options to add vacation days.
![Employee Home Page](Description%20pictures/HomePageEmployee.png)

### Add Vacation Page
Allows employees to add vacation dates, which the algorithm considers when assigning tasks.
![Add Vacation](Description%20pictures/AddVacation.png)






