///  Mech 540-A  :  Team-2 Project; Path finding using A* Algorithm
///
///  Name        :  Anna-Lee McLean
///  Student ID  :  81058794
///  Source file :  Node.cs
///  Purpose     :  Contains the Node class within the PathPlanning namespace. Allows a node within an RRT roadmap to be created 
///                 with (x,y) coordinates, it's parent node in the roadmap, and cost-to-goal parameters which will be used in the
///                 A* Search method.
///  Description :  Contains the EuclideanDistance() Method which calculates the straight-line distance between two nodes.
///                 X and Y coordinates for the node must be declared when the class is instantiated.
///                


/// ****************************** USINGS ******************************
using System;

namespace PathPlanning
{
    /// ***************************** CLASSES *****************************
    /// Class       : Node
    /// Description : Represents a node in the RRT roadmap which has an x and y coordinate, 
    ///               a parent node, a past cost, a heurustic cost and an estimated cost.
    /// Methods     : 1. EuclideanDistance()
    
    class Node 
    {
        // ATTRIBUTES
        public int X;
        public int Y;
        
        // CONSTRUCTOR
        public Node(int X_, int Y_)
        {
            X = X_;
            Y = Y_;
            cost = float.PositiveInfinity;
        }

        // GETTERS AND SETTERS

        // Gets and Sets the node to which the instantiated node is connected to in the roadmap
        public Node parent { get; set; }
        // Gets and Sets the straight-line distance between the node and its parent
        public float cost { get; set; }
        // Gets and Sets the straight-line distance between the node and the goal node for the roadmap
        public float heuristic_cost { get; set; }  
        // Gets and Sets the estimated cost of travelling to the node 
        public float estimated_cost
        {
            get { return estimated_cost; }
            set
            {
                estimated_cost = cost + heuristic_cost;
            }
        }

        /// ***************************** METHODS *****************************
        /// Method    : EuclideanDistance()
        /// Arguments : 1 (Node)
        /// Returns   : The resulting straight-line distance (float)
        
        public float EuclideanDistance(Node node2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(X - node2.X, 2) + Math.Pow(Y - node2.Y, 2));
            return distance;
        }

        public bool Equals(Node node2)
        {
            if ((X == node2.X) && (Y == node2.Y))
            {
                return true;
            }
            return false;
        }
    }
}
