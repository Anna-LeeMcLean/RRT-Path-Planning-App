# **Path Planning Algorithm**

## **Table of Contents**
* About the Project
* Description
    * Dependencies
    * Usage Instructions


---

## **About the Project**
### MECH 540A 101 2021W1 Emerging Topics in Mechatronics, Manufacturing, Controls, and Automation - SFTWR DSGN MECH FINAL PROJECT
**Authors:** Ajay Nalla and Anna-Lee McLean

**Purpose:** RRT Autonomous Path Planning application for a mobile robot in a 2D, obstacle-filled environment.

---

## **Description:** 
This project implements a path planning application for a mobile robot. Given a start position and goal position within a set environment, the application creates a roadmap for the mobile robot considering all obstacles in the map and returns the path to the goal position from the start position. The creation of the roadmap and it's start to goal path is based on the [RRT algorithm](https://en.wikipedia.org/wiki/Rapidly-exploring_random_tree). A Graphical User Interface (GUI) has been created for the application which allows a user to insert obstacles into the environment, select start and goal positions and select options to govern how the path planning operation functions.

### **A. Dependencies**
* Platform: Any CPU
* Dependencies: Microsoft .NET Framework
* Configuration: Release
* Target Framework: netcoreapp3.1
* Deployment Mode: Self-contained
* Target Runtime: win-x64

### **B. Usage Instructions**
To run the program, the .NET Framework is required. Extract the executable and setup from the Autonomous_Robot_Path_Finding_Application.zip folder to run the application. The necessary runtime files (.dll, .runtimeconfig etc.) are also included in the folder.

The application has been configured to accept start point, end point and rectangular obstacles within the GUI window. User can remove or move the obstacles, start point and end point within the blue window. To create a start point, click on the start button and then click anywhere in the blue window. For the end point it is similar to the above step. To create a obstacle click on the rectangle button and then click and drag in the window to create the obstacle. To move the points or the obstacles just click on them and move them around with mouse. To remove the elements from the window click on the remove button and then choose the element to be removed with mouse click. To reset the app click on reset button. To run the path generation, click on generate button. After creating the path in the window a pop-up will appear showing the distance travelled. Once you click ok on that the window will be reset and you can start over again.

The step size for the tree is 0.1 and the window size is set to (650, 300) in size.
