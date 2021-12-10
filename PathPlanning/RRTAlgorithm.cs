using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows;

namespace PathPlanning
{
    // Returns: A generic list of nodes which make up the roadmap
    class RRTree
    {
        List<Node> roadmap;
        public Node start;
        public Node goal;
        public float stepSize;
        public int treeSize;

        public RRTree(Point start_, Point goal_, float stepSize_, int treeSize_)
        {
            Node start = new Node(start_.X, start_.Y);
            start.cost = 0;
            Node goal = new Node(goal_.X, goal_.Y);

            float start_heuristic_cost = start.EuclideanDistance(goal);
            start.heuristic_cost = start_heuristic_cost;

            stepSize = stepSize_;
            treeSize = treeSize_;

            // Initialize RRT with start and end coordinates
            List<Node> roadmap = new List<Node>();
            roadmap.Add(start);
            //roadmap.AddLast(end);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static void CreateRRT(RRTree T, List<Rectangle> obstacleList_)
        {
            while (T.roadmap.Count < T.treeSize)
            {
                Node[] nodeList = GenerateNewSample(T);
                // The method above returns a list of 2 nodes which overwrites the initailized variable and is passed to the method below.

                if (CheckCollisionFree(nodeList, obstacleList_))
                {
                    // DrawEdge();
                    T.roadmap.Add(nodeList[1]);
                    
                }
            }

            // Call A* search here

        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static Node[] GenerateNewSample(RRTree T_)
        {
            // Create x and y coords for a new sample between 0 and 5 (the dimensions of the environment)
            // Sample a random coordinate (node) in the environment
            Random randomFloat = new Random();
            float xSample = (float)(randomFloat.NextDouble() * 5);    
            float ySample = (float)(randomFloat.NextDouble() * 5);
            Node sample = new Node(xSample, ySample);

            Node nearestNode = FindNearestNode(T_, sample);

            // Generate a new node that creates a vector from the nearest node to the random sample but is the length of stepSize.
            float xNew = nearestNode.X + (((xSample - nearestNode.X) * T_.stepSize) / nearestNode.cost);
            float yNew = nearestNode.Y + (((ySample - nearestNode.Y) * T_.stepSize) / nearestNode.cost);
            Node newNode = new Node(xNew, yNew);    

            // Store the new node and it's parent node in a list to be returned 
            Node[] nodeList = { nearestNode, newNode };

            return nodeList;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static bool CheckCollisionFree(Node[] nodeList_, List<Rectangle> obstacleList_)
        {
            // Generate parametric equations for the line which connects the new node and it's nearest neighbour node

            float dx1 = nodeList_[1].X - nodeList_[0].X; // change in x for the new and nearest nodes
            float dy1 = nodeList_[1].Y - nodeList_[0].Y; // change in y for the new and nearest nodes

            foreach (Rectangle obstacle in obstacleList_)
            {
                // Generate coordinates for each of the four lines which make up the rectangle: { xstart, ystart, xend, yend }

                int[] topLine = { obstacle.Left, obstacle.Top, obstacle.Right, obstacle.Top };
                int[] bottomLine = { obstacle.Left, obstacle.Bottom, obstacle.Right, obstacle.Bottom };
                int[] leftLine = { obstacle.Left, obstacle.Bottom, obstacle.Left, obstacle.Top };
                int[] rightline = { obstacle.Right, obstacle.Bottom, obstacle.Right, obstacle.Top };

                // Add lines to a generic list so we can iterate through each line
                List<int[]> rectangleLines = new List<int[]>();

                rectangleLines.Add(topLine); rectangleLines.Add(bottomLine);
                rectangleLines.Add(rightline); rectangleLines.Add(leftLine);

                // Initialize parametric variables t1 and t2
                float t1 = 0; float t2 = 0;
                
                foreach (int[] line in rectangleLines)
                {
                    float dx2 = line[2] - line[0];
                    float dy2 = line[3] - line[1];

                    float denominator = dy1 * dx2 - dx1 * dy2;
                    t1 = ((nodeList_[0].X - line[0]) * dy2 + (line[1] - nodeList_[0].Y) * dx2) / denominator;
                    t2 = ((line[0] - nodeList_[0].X) * dy1 + (nodeList_[0].Y - line[1]) * dx1)/ -denominator;

                }
                
                if ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1)) 
                {
                    // Set the nearest node as the new node's parent
                    nodeList_[1].parent = nodeList_[0];
                    return true; 
                }

            }

            return false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        // Find the nearest node in the roadmap of the tree T which is closest to the random sampled coordinate
        public static Node FindNearestNode(RRTree T_, Node sample_)
        {
            // Initialize a variable for the nearest node
            Node nearestNode = new Node(0, 0);

            // Initialize a variable for the distance between the sample node and its nearest neighbour node
            float minDistance = float.PositiveInfinity;

            foreach (Node node in T_.roadmap)
            {
                float distance = node.EuclideanDistance(sample_);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestNode = node;
                    nearestNode.cost = minDistance;
                }
            }

            return nearestNode;
        }

    }
}
