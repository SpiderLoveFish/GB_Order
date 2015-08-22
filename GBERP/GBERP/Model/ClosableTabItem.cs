Iusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GBERP.AF;

namespace GBERP.Model
{
    public class ClosableTabItem : TabItem
    {
        public ClosableTabItem()
        {
            var closableTabHeader = new CloseableTabHeader();
            this.Header = closableTabHeader;

            // Attach to the CloseableHeader events (Mouse Enter/Leave, Button Click, and Label resize)
            closableTabHeader.btnClose.MouseEnter += new MouseEventHandler(btnClose_MouseEnter);
            closableTabHeader.btnClose.MouseLeave += new MouseEventHandler(btnClose_MouseLeave);
            closableTabHeader.btnClose.Click += new RoutedEventHandler(btnClose_Click);
            closableTabHeader.lblTitle.SizeChanged += new SizeChangedEventHandler(lblTitle_SizeChanged);
        }

        /// <summary>
        /// Property - Set the Title of the Tab
        /// </summary>
        public string Title
        {
            set
            {
                ((CloseableTabHeader)this.Header).lblTitle.Content = value;
            }
        }

        // Override OnSelected - Show the Close Button
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((CloseableTabHeader)this.Header).btnClose.Visibility = Visibility.Visible;
        }

        // Override OnUnSelected - Hide the Close Button
        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((CloseableTabHeader)this.Header).btnClose.Visibility = Visibility.Hidden;
        }
        // Override OnMouseEnter - Show the Close Button
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((CloseableTabHeader)this.Header).btnClose.Visibility = Visibility.Visible;
        }

        // Override OnMouseLeave - Hide the Close Button (If it is NOT selected)
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((CloseableTabHeader)this.Header).btnClose.Visibility = Visibility.Hidden;
            }
        }

        // Button MouseEnter - When the mouse is over the button - change color to Red
        void btnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            ((CloseableTabHeader)this.Header).btnClose.Foreground = Brushes.Red;
        }

        // Button MouseLeave - When mouse is no longer over button - change color back to black
        void btnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            ((CloseableTabHeader)this.Header).btnClose.Foreground = Brushes.Black;
        }


        // Button Close Click - Remove the Tab - (or raise an event indicating a "CloseTab" event has occurred)
        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
     
        }


        // Label SizeChanged - When the Size of the Label changes (due to setting the Title) set position of button properly
        void lblTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((CloseableTabHeader)this.Header).btnClose.Margin = new Thickness(((CloseableTabHeader)this.Header).lblTitle.ActualWidth + 5, 3, 0, 0);
        }
    }
}
