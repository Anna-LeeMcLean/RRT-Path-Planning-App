using System;
using System.Collections.Generic;
using System.Text;

namespace PathPlanning
{
    // Returns: A generic list of nodes which make up the roadmap
    class RRTree
    {
        public double[] start = new double[2]; 
        public double[] end = new double[2];
        public double stepSize;
        public int treeSize;

        RRTree(double[] start_, double[] end_, double stepSize_, int treeSize_)
        {
            start = start_;
            end = end_;
            stepSize = stepSize_;
            treeSize = treeSize_;
        }

        public void GenerateTreeNodes()
        {
            // Initialize RRT with start and end coordinates
            LinkedList<double[]> roadmap = new LinkedList<double[]>();
            roadmap.AddFirst(start);
            //roadmap.AddLast(end);

            while (roadmap.Count < treeSize) 
            {
                Random sample = new Random();
                double xSample = sample.NextDouble() * 5;    // Create x and y coords for a new sample between 0 and 5 (the dimensions of the environment)
                double ySample = sample.NextDouble() * 5;
                double minDistance = double.PositiveInfinity;
                double xNearest = 0;
                double yNearest = 0;

                foreach(double[] coordinate in roadmap)
                {
                    double distance = Math.Sqrt(Math.Pow((xSample - coordinate[1]),2) + Math.Pow((ySample - coordinate[2]), 2));
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        xNearest = coordinate[1];
                        yNearest = coordinate[2];
                    }
                }

                double xNew = xNearest + (((xSample - xNearest) * stepSize) / minDistance);
                double yNew = yNearest + (((ySample - yNearest) * stepSize) / minDistance);

            }
        }

        public static bool CheckCollisionFree()
        {

        }

    }
}
