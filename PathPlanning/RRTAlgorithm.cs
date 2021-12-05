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
        List<PointF> roadmap;
        public PointF start = new PointF(); 
        public PointF end = new PointF();
        public float stepSize;
        public int treeSize;

        public RRTree(PointF start_, PointF end_, float stepSize_, int treeSize_)
        {
            start = start_;
            end = end_;
            stepSize = stepSize_;
            treeSize = treeSize_;

            // Initialize RRT with start and end coordinates
            List<PointF> roadmap = new List<PointF>();
            roadmap.Add(start);
            //roadmap.AddLast(end);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static void CreateRRT(RRTree T)
        {
            while (T.roadmap.Count < T.treeSize)
            {
                // Initializing a new sample vector for the GenerateNewSample() method
                float[] newSampleVector = new float[4];
                List<Rectangle> obstacleList = new List<Rectangle>();

                
                GenerateNewSample(T);
                // The method above returns float[] newSampleVector which overwrites the initailized variable and is passed to the method below.
                if (CheckCollisionFree(newSampleVector, obstacleList))
                {
                    // DrawEdge();
                    PointF newNode = new PointF(newSampleVector[3], newSampleVector[4]);
                    T.roadmap.Add(newNode);
                    
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static float[] GenerateNewSample(RRTree T_)
        {
            // Create x and y coords for a new sample between 0 and 5 (the dimensions of the environment)
            // Sample a random coordinate (node) in the environment
            Random randomFloat = new Random();
            float xSample = (float)(randomFloat.NextDouble() * 5);    
            float ySample = (float)(randomFloat.NextDouble() * 5);
            PointF sample = new PointF(xSample, ySample);
            float minDistance = float.PositiveInfinity;
            // Find the nearest node in the roadmap of the tree T which is closest to the random sampled coordinate
            float xNearest = 0;
            float yNearest = 0;

            foreach(PointF node in T_.roadmap)
            {
                float distance = (float)Math.Sqrt(Math.Pow(sample.X - node.X, 2) + Math.Pow(sample.Y - node.Y, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    xNearest = node.X;
                    yNearest = node.Y;
                }
            }

            // Generate a new node that creates a vector from the nearest node to the random sample but is the length of stepSize.
            float xNew = xNearest + (((xSample - xNearest) * T_.stepSize) / minDistance);
            float yNew = yNearest + (((ySample - yNearest) * T_.stepSize) / minDistance);

            float[] newSampleVector = { xNearest, yNearest, xNew, yNew };

            return newSampleVector;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------
        public static bool CheckCollisionFree(float[] newSampleVector_, List<Rectangle> obstacleList_)
        {
            // Generate parametric equations for the line which connects the nearest node and new node

            float dx1 = newSampleVector_[2] - newSampleVector_[0]; // change in x for the sample vector
            float dy1 = newSampleVector_[3] - newSampleVector_[1]; // change in y for the sample vector

            foreach (Rectangle obstacle in obstacleList_)
            {
                // Generate coordinates for each line: { xstart, ystart, xend, yend }

                int[] topLine = { obstacle.Left, obstacle.Top, obstacle.Right, obstacle.Top };
                int[] bottomLine = { obstacle.Left, obstacle.Bottom, obstacle.Right, obstacle.Bottom };
                int[] leftLine = { obstacle.Left, obstacle.Bottom, obstacle.Left, obstacle.Top };
                int[] rightline = { obstacle.Right, obstacle.Bottom, obstacle.Right, obstacle.Top };

                // Add lines to a generic list
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
                    t1 = ((newSampleVector_[0] - line[0]) * dy2 + (line[1] - newSampleVector_[1]) * dx2) / denominator;
                    t2 = ((line[0] - newSampleVector_[0]) * dy1 + (newSampleVector_[1] - line[1]) * dx1)/ -denominator;

                }
                
                if ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1)) { return true; }

            }

            return false;
        }

    }
}
