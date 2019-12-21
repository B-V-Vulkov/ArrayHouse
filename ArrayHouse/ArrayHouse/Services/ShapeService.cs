namespace ArrayHouse.Services
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Media;

    using Services;
    using Commons;
    using Commons.Enumerations;
    using System.Collections.Generic;
    using ArrayHouse.Models;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public static class ShapeService
    {
        public static StackPanel Get()
        {
            StackPanel stackPanel = new StackPanel();
            return stackPanel;
        }
    }
}
