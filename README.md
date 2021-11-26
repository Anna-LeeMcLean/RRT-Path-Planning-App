# **Path Planning Algorithm**

## **Table of Contents**
* About the Project
* Description
    * Dependencies
    * Software Architecture
* Usage Instructions

---

## **About the Project**
### MECH 540A 101 2021W1 Emerging Topics in Mechatronics, Manufacturing, Controls, and Automation - SFTWR DSGN MECH FINAL PROJECT
**Authors:** Ajay Nalla and Anna-Lee McLean

**Purpose:** Path Planning application for a mobile robot in a 2D, obstacle-filled environment.

**Description:** This project implements a path planning application for a mobile robot. Given a start position and goal position within a set environment, the application creates a roadmap for the mobile robot considering all obstacles in the map and determines the shortest path to the goal position from the start position. The creation of the roadmap is based on the RRT algorithm and the searching of the created roadmap is governed by an A* search algorithm. A Graphical User Interface (GUI) has been created for the application which allows a user to insert obstacles into the environment, select start and goal positions and select options to govern how the path planning operation functions.