using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DemoBehavior
{
    class ClassBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GotFocus += this.OnTextBoxGotFocus;
        }

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Background = Brushes.Black;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.GotFocus -= this.OnTextBoxGotFocus;
            base.OnDetaching();
        }
    }
}
