///  Mech 540-A  :  Team-2 Project; Path finding using A* Algorithm
///
///  Name        :  Ajay Nalla
///  Student ID  :  49640014
///  Source file :  MainWindow.xaml.cs
///  Purpose     :  To create a GUI that can take user inputs for Start, End, Obstacles and show the generated path. 
///                 Contains UI-Layout namespace.
///  Description :  Contains classes 
///                 1)MainWindow: Inherits from the Window class, Which is a form. Contains methods to activate button
///                   click, mouse click, mouse move, mouse down and mouse up for various buttons and draw area.
///

/// ************************* USINGS *************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// ************************* CLASSES *************************
    /// Class       : MainWindow
    /// Description : Inherits from Window class,Contains methods to activate button
    ///               click, mouse click, mouse move, mouse down and mouse up for 
    ///               various buttons and draw area.
    public partial class MainWindow : Window
    {
        private UIElement _currentItem = null;
        private Point anchorPoint;

        private bool _isDrawingStart = false;
        private bool _isDrawingEnd = false;
        private bool _isRemoving = false;

        public Point? StartPoint = null;
        public Point? EndPoint = null;

        /// ************************* METHOD *************************
        /// Method    : MainWindow
        /// Arguments : None
        /// Returns   : Nothing
        /// This method contains the form initializer, the program starts as soon as the window is open.
        public MainWindow()
        {
            InitializeComponent();
            //CompositionTarget.Rendering += OnRendering;
        }

        /* private void OnRendering(object sender, EventArgs e)
         {

         }*/

        /// ************************* METHOD *************************
        /// Method    : CancelDrawing()
        /// Arguments : None
        /// Returns   : Nothing
        /// This method sets the Drawing elemets to false, used for calling in subsequent methods.
        private void CancelDrawing()
        {
            _isDrawingStart = false;
            _isDrawingEnd = false;

        }
        /// ************************* METHOD *************************
        /// Method    : StartButton_Click
        /// Arguments : object sender, RoutedEventArgs e
        /// Returns   : Nothing
        /// This method is a start button click event, when the start button 
        /// is clicked the start point drawing is enabled.
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            CancelDrawing();
            _isDrawingStart = true;
        }
        /// ************************* METHOD *************************
        /// Method    : EndButton_Click
        /// Arguments : object sender, RoutedEventArgs e
        /// Returns   : Nothing
        /// This method is a end button click event, when the end button is 
        /// clicked the end point drawing is enabled.
        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            CancelDrawing();
            _isDrawingEnd = true;
        }
        /// ************************* METHOD *************************
        /// Method    : DrawArea_OnPreviewMouseLeftButtonDown
        /// Arguments : object sender, MouseButtonEventArgs e
        /// Returns   : Nothing
        /// This method is for mouse leftbutton down with in the draw area 
        /// window, when mouse is clicked in the draw area, start point and end point
        /// are generated as Green and Red rectangles.
        private void DrawArea_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Code for creating start point and representing it as a green rectangle.
            if (_isDrawingStart && StartPoint == null)
            {
                _currentItem = new Rectangle()
                {
                    Width = 10,
                    Height = 10,
                    Fill = new SolidColorBrush(Colors.Green),
                    Tag = "Start"
                };

                Canvas.SetLeft(_currentItem, e.GetPosition(DrawArea).X);
                Canvas.SetTop(_currentItem, e.GetPosition(DrawArea).Y);

                StartPoint = new Point(e.GetPosition(DrawArea).X, e.GetPosition(DrawArea).Y);

                DrawArea.Children.Add(_currentItem);
                CancelDrawing();
            }
            //Code for creating end point and representing it as a red rectangle.
            if (_isDrawingEnd && EndPoint == null)
            {
                _currentItem = new Rectangle()
                {
                    Width = 10,
                    Height = 10,
                    Fill = new SolidColorBrush(Colors.Red),
                    Tag = "End"
                };


                Canvas.SetLeft(_currentItem, e.GetPosition(DrawArea).X);
                Canvas.SetTop(_currentItem, e.GetPosition(DrawArea).Y);

                EndPoint = new Point(e.GetPosition(DrawArea).X, e.GetPosition(DrawArea).Y);

                DrawArea.Children.Add(_currentItem);
                CancelDrawing();
            }

            //Panel.SetZIndex(_currentItem, -10);

            //If the draw area has any element in it, this code allows user to move those elements
            //aorund as he wants. He can move start point, end point and obstacles in the draw area.
            if (_currentItem != null) 
            {
                _currentItem.PreviewMouseMove += (s, args) =>
                {
                    if (e.LeftButton == MouseButtonState.Pressed && _currentItem != null)
                    {
                        _currentItem = (UIElement)s;
                        DragDrop.DoDragDrop(_currentItem, _currentItem, DragDropEffects.Move);
                    }
                };

                _currentItem.PreviewMouseLeftButtonDown += (o, args) =>
                {  //Code for removing elements from the draw area.
                    if (_isRemoving)
                    {
                        _isRemoving = false;
                        DrawArea.Children.Remove((UIElement)o);
                    }
                };
            }
            
        }
        /// ************************* METHOD *************************
        /// Method    : DrawArea_OnPreviewMouseLeftButtonUp
        /// Arguments : object sender, MouseButtonEventArgs e
        /// Returns   : Nothing
        /// This method is for mouse leftbutton up with in the draw area 
        /// window, when mouseclick is released this event captures it.
        private void DrawArea_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawArea.ReleaseMouseCapture();
        }
        /// ************************* METHOD *************************
        /// Method    : ResetButton_Click
        /// Arguments : object sender, RoutedEventArgs e
        /// Returns   : Nothing
        /// This method is a Resetbutton click event, when the reset button is clicked, 
        /// all the elements in the draw area are removed and all values are set to sull.
        /// Cleaning/resetting the entire draw area.
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _currentItem = null;
            CancelDrawing();
            StartPoint = null;
            EndPoint = null;
            DrawArea.Children.Clear();
        }
        /// ************************* METHOD *************************
        /// Method    : RemoveButton_Click
        /// Arguments : object sender, RoutedEventArgs e
        /// Returns   : Nothing
        /// This method is a Remove button click event, when the remove element button is clicked, 
        /// the selected element with mouse click will be removed from the draw area.
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _isRemoving = true;
        }
        /// ************************* METHOD *************************
        /// Method    : GeneratePathButton_Click
        /// Arguments : object sender, RoutedEventArgs e
        /// Returns   : Nothing
        /// This method is generate button click event, when this is clicked
        /// the start point and point co-ordinates for now are sent to console winodw. 
        /// Here the next code for collecting rectangle object co-ordinates also will be
        /// coming, the A* algorith can be called/interacted within this button to take 
        /// co-ordinates of start, end and obstacle data ==> do the path generation ==>
        /// and send the co-ordinates of path points that the GUI can use to draw the line path.
       
        private void GeneratePathButton_Click(object sender, RoutedEventArgs e)
        {
            //condition to verify if the start and end elements are not null
            if (StartPoint == null && EndPoint == null)
            {
                return;
            }

            Console.WriteLine(StartPoint);

            Console.WriteLine(EndPoint);

           // put your A* here
        }
    }
}
