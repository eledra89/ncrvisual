﻿using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NCRVisual.RelationDiagram
{
    public partial class EdgeControl : UserControl
    {
        public EntityControl StartingEntity { get; set; }
        public EntityControl EndEntity { get; set; }       

        public EdgeControl(EntityControl start, EntityControl end)
        {
            InitializeComponent();
            this.StartingEntity = start;
            this.EndEntity = end;
        }

        /// <summary>
        /// Draw Connection between 2 entity Control
        /// </summary>
        /// <param name="startingPoint">Source control</param>
        /// <param name="endPoint">End control</param>
        public void drawEdge()
        {
            Line connectionLine = new Line();
            connectionLine.X1 = Canvas.GetLeft(StartingEntity) + StartingEntity.Width / 2;
            connectionLine.Y1 = Canvas.GetTop(StartingEntity) + StartingEntity.Height / 2;
            connectionLine.X2 = Canvas.GetLeft(EndEntity) + EndEntity.Width / 2;
            connectionLine.Y2 = Canvas.GetTop(EndEntity) + EndEntity.Height / 2;
            connectionLine.StrokeThickness = 1;
            connectionLine.Stroke = new SolidColorBrush(Colors.Black);
            connectionLine.Opacity = .5;
            MainGrid.Children.Add(connectionLine);
        }
    }
}
