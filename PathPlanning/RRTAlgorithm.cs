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
        LinkedList<double[]> roadmap;
        public double[] start = new double[2]; 
        public double[] end = new double[2];
        public double stepSize;
        public int treeSize;

        public RRTree(double[] start_, double[] end_, double stepSize_, int treeSize_)
        {
            start = start_;
            end = end_;
            stepSize = stepSize_;
            treeSize = treeSize_;

            // Initialize RRT with start and end coordinates
            LinkedList<double[]> roadmap = new LinkedList<double[]>();
            roadmap.AddFirst(start);
            //roadmap.AddLast(end);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static void CreateRRT(RRTree T)
        {
            while (T.roadmap.Count < T.treeSize)
            {
                // Initializing a new sample vector for the GenerateNewSample() method
                double[] newSampleVector = new double[4];
                List<Rectangle> obstacleList = new List<Rectangle>();

                
                GenerateNewSample(T);
                // The method above returns double[] newSampleVector which overwrites the initailized variable and is passed to the method below.
                CheckCollisionFree(newSampleVector, obstacleList);
            }
        }
        // I want to pass Point objects instead of double[] so badly.
        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static double[] GenerateNewSample(RRTree T_)
        {
            // Create x and y coords for a new sample between 0 and 5 (the dimensions of the environment)
            // Sample a random coordinate (node) in the environment
            Random sample = new Random();
            double xSample = sample.NextDouble() * 5;    
            double ySample = sample.NextDouble() * 5;
            double minDistance = double.PositiveInfinity;
            // Find the nearest node in the roadmap of the tree T which is closest to the random sampled coordinate
            double xNearest = 0;
            double yNearest = 0;

            foreach(double[] node in T_.roadmap)
            {
                double distance = Math.Sqrt(Math.Pow((xSample - node[1]),2) + Math.Pow((ySample - node[2]), 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    xNearest = node[1];
                    yNearest = node[2];
                }
            }

            // Generate a new node that creates a vector from the nearest node to the random sample but is the length of stepSize.
            double xNew = xNearest + (((xSample - xNearest) * T_.stepSize) / minDistance);
            double yNew = yNearest + (((ySample - yNearest) * T_.stepSize) / minDistance);

            double[] newSampleVector = { xNearest, yNearest, xNew, yNew };

            return newSampleVector;
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static bool CheckCollisionFree(double[] newSampleVector_, List<Rectangle> obstacleList_)
        {
            // Generate an equation for the line which connects the nearest node and new node

            foreach (Rectangle obstacle in obstacleList_)
            {

            }
        }

    }
}
