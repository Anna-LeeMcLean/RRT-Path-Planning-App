using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PathPlanning
{
    // Represents a node in the RRT roadmap which has an x and y coordinate, a parent node, a past cost, an optimistic cost and an estimated cost
    class Node 
    {
        public float X;
        public float Y;
        
        // CONSTRUCTOR
        public Node(float X_, float Y_)
        {
            X = X_;
            Y = Y_;
            cost = float.PositiveInfinity;
        }

        // GETTERS AND SETTERS
        public Node parent { get; set; }
        public float cost { get; set; }
        public float heuristic_cost { get; set; }

        public float estimated_cost
        {
            get { return estimated_cost; }
            set
            {
                estimated_cost = cost + heuristic_cost;
            }
        }

        // METHODS


        public float EuclideanDistance(Node node2)
        {
            float distance = (float)Math.Sqrt(Math.Pow(this.X - node2.X, 2) + Math.Pow(this.Y - node2.Y, 2));
            return distance;
        }
    }
}
