///  Mech 540-A  :  Team-2 Project; Path finding using A* Algorithm
///
///  Name        :  Anna-Lee McLean
///  Student ID  :  81058794
///  Source file :  RRTAlgortihm.cs
///  Purpose     :  Contains the RRTree class within the PathPlanning namespace. 
///  Description :  Allows a (Rapidly Exploring Random Tree) RRT roadmap to be created as a list of Node objects including a start and goal node. 
///                 Contains the public CreateRRT() method which is the main function for the class called when the user clicks the 'Generate button'.
///                 Also contains the private GenerateNewSample(), CheckCollsionFree() and FindNearestNode() methods which are called by the CreateRRT() method.
///                             


/// ****************************** USINGS ******************************
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI_Layout;

namespace PathPlanning
{
    /// ***************************** CLASSES *****************************
    /// Class       : RRTree
    /// Description : Creates a roadmap of Node objects which is searched by an A* Search algorithm 
    ///               to find the shortest path in the roadmap to the goal node.
    /// Methods     : 1. CreateRRT()
    ///               2. GenerateNewSample()
    ///               3. CheckCollsionFree()
    ///               4. FindNearestNode()
    
    class RRTree
    {
        // ATTRIBUTES

        public List<Node> roadmap;
        public Node start;
        public Node goal;
        public float stepSize = 25f;
        public bool goalAddedToRoadmap = false;

        // CONSTRUCTOR

        public RRTree(Point start_, Point goal_)
        {
            start = new Node(start_.X, start_.Y);
            goal = new Node(goal_.X, goal_.Y);
            start.cost = 0;

            // Initialize RRT with start Node
            roadmap = new List<Node>();
            roadmap.Add(start);
        }

        /// ******************************** METHOD ********************************
        /// Method    : CreateAndSearchRRT()
        /// Arguments : 2 (RRTree, List<Rectangle>)
        /// Returns   : None
        /// This is the main method for the RRTree class which calls all other methods in the order required to create and search the roadmap
        public List<Node> CreateAndSearchRRT(List<RectangleData> obstacleList_)
        {
            while (!goalAddedToRoadmap)
            {
                Node[] nodeList = GenerateNewSample();

                if (CheckCollisionFree(nodeList, obstacleList_))
                {
                    //mainWindow.CreateCircle(nodeList[0]);
                    //mainWindow.CreateCircle(nodeList[1]);
                    //mainWindow.CreateAPolyline(nodeList);
                    
                    roadmap.Add(nodeList[1]);

                    // If the new node is within range of the goal node, complete the roadmap
                    float distanceFromGoal = nodeList[1].EuclideanDistance(goal);
                    if (distanceFromGoal < stepSize)
                    {
                        goal.parent = nodeList[1];
                        roadmap.Add(goal);
                        goalAddedToRoadmap = true;
                        //DrawEgde (between newNode (nodeList[1]) and goal)
                        break;
                    }
                    
                }
            }

            List<Node> path = ReturnPath();
            return path;
        }

        /// ******************************** METHOD ********************************
        /// Method    : GenerateNewSample()
        /// Arguments : 1 (RRTree)
        /// Returns   : A list containing the new generated node and it's nearest neighbour node already in the roadmap (Node[])
        /// This method calls the FindNearestNode() method to find the nearest neighbour node to the new generated sample
        private Node[] GenerateNewSample()
        {
            // Create x and y coords for a new sample between 0 and 5 (the dimensions of the environment)
            // Sample a random coordinate (node) in the environment
            Random randomDouble = new Random();
            //double xSample = randomDouble.NextDouble() * MainWindow.window_height;
            //double ySample = randomDouble.NextDouble() * MainWindow.window_width;
            double xSample = randomDouble.NextDouble() * 800;
            double ySample = randomDouble.NextDouble() * 350;
            Node sample = new Node(xSample, ySample);

            Node nearestNode = FindNearestNode(sample);

            // Generate a new node that creates a vector from the nearest node to the random sample but is the length of stepSize.
            int xNew = (int)(nearestNode.X + ((xSample - nearestNode.X) * stepSize) / (sample.EuclideanDistance(nearestNode)));
            int yNew = (int)(nearestNode.Y + ((ySample - nearestNode.Y) * stepSize) / (sample.EuclideanDistance(nearestNode)));
            Node newNode = new Node(xNew, yNew);    

            // Store the new node and it's parent node in a list to be returned 
            Node[] nodeList = { nearestNode, newNode };

            return nodeList;
        }

        /// ******************************** METHOD ********************************
        /// Method    : CheckCollisionFree()
        /// Arguments : 2 (Node[], List<Rectangle>)
        /// Returns   : bool
        /// This method checks to see if the edge created between the new generated node and it's nearest node collides with any obstacles
        private static bool CheckCollisionFree(Node[] nodeList_, List<RectangleData> obstacleList_)
        {
            // Generate parametric equations for the line which connects the new node and it's nearest neighbour node

            double dx1 = nodeList_[1].X - nodeList_[0].X; // change in x for the new and nearest nodes
            double dy1 = nodeList_[1].Y - nodeList_[0].Y; // change in y for the new and nearest nodes

            // Initialize parametric variables t1 and t2
            double t1 = 0; double t2 = 0;

            if (obstacleList_.Count != 0)
            {
                foreach (RectangleData obstacle in obstacleList_)
                {
                    // Generate coordinates for each of the four lines which make up the rectangle: { xstart, ystart, xend, yend }

                    double[] topLine = { obstacle.X1, obstacle.Y1, obstacle.X2, obstacle.Y2 };
                    double[] bottomLine = { obstacle.X3, obstacle.Y3, obstacle.X4, obstacle.Y4 };
                    double[] leftLine = { obstacle.X3, obstacle.Y3, obstacle.X1, obstacle.Y1 };
                    double[] rightline = { obstacle.X4, obstacle.Y4, obstacle.X2, obstacle.Y2 };

                    // Add lines to a generic list so we can iterate through each line
                    List<double[]> rectangleLines = new List<double[]>();

                    rectangleLines.Add(topLine); 
                    rectangleLines.Add(bottomLine);
                    rectangleLines.Add(rightline); 
                    rectangleLines.Add(leftLine);

                    foreach (double[] line in rectangleLines)
                    {
                        double dx2 = line[2] - line[0];
                        double dy2 = line[3] - line[1];

                        double denominator = dy1 * dx2 - dx1 * dy2;
                        t1 = ((nodeList_[0].X - line[0]) * dy2 + (line[1] - nodeList_[0].Y) * dx2) / denominator;
                        t2 = ((line[0] - nodeList_[0].X) * dy1 + (nodeList_[0].Y - line[1]) * dx1) / -denominator;

                        if ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1))
                        {
                            // If this condition is met, the new line vector intersects with one of the lines of one of the rectangles.
                            return false;
                        }
                    }
                }

                // This part of the method can only be accessed once the new vector does not intersect with any of the lines of any of the obstacles.

                // Set the nearest node as the new node's parent.
                // Reminder: nodeList_[0] --> nearest node; nodeList_[1] --> new node
                nodeList_[1].parent = nodeList_[0];
                // Set the new node's cost as the cost of the parent node + cost between new node and nearest node
                // Maybe this might just be the cost between the new node and nearest node. Gonna see after A* Search is implemented.
                nodeList_[1].cost = nodeList_[0].cost + nodeList_[1].EuclideanDistance(nodeList_[0]);

                return true;

            }
            else
            {
                // If there are no obstacles, return true.
                return true;
            }
        }

        /// ******************************** METHOD ********************************
        /// Method    : FindNearestNode()
        /// Arguments : 2 (RRTree, Node)
        /// Returns   : The nearest node to the sampled node (Node)
        /// This method finds the nearest node in the roadmap of the tree T which is closest to the random sampled node
        private Node FindNearestNode(Node sample_)
        {
            // Initialize a variable for the nearest node
            Node nearestNode = new Node(0, 0);

            // Initialize a variable for the distance between the sample node and its nearest neighbour node
            float minDistance = float.PositiveInfinity;

            foreach (Node node in roadmap)
            {
                float distance = node.EuclideanDistance(sample_);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestNode = node;
                }
            }

            return nearestNode;
        }

        /// ******************************** METHOD ********************************
        /// Method    : ReturnPath()
        /// Arguments : None
        /// Returns   : The path in the roadmap from the start to the goal node (List<Node>)
        /// 
        private List<Node> ReturnPath()
        {
            List<Node> finalPath = new List<Node>();
            Node currentNode = goal;

            while (!currentNode.Equals(start))
            {
                finalPath.Add(currentNode);
                currentNode = currentNode.parent;
            }

            return finalPath;
        }
    }
}
