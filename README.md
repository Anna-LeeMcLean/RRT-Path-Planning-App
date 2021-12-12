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

**Purpose:** RRT Path Planning application for a mobile robot in a 2D, obstacle-filled environment.

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
To run the program, the .NET Framework is required. Extract the executable from the app.zip folder to run the application. The necessary runtime files (.dll, .runtimeconfig etc.) are also included in the app.zip folder.

The application has been configured to accept start point coordinates, end point coordinates and rectangular obstacles within the GUI window. The step size for the tree is 0.1 and the window size is set to (800, 450) in size.
