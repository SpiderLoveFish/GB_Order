using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

/*
 * zhg
 * 异步提示
 */
namespace GBERP.ViewModel
{
   public class TipsMessagePopup
     {
         public static void SimpleShow(UIElement parent, string message)
       {
           parent.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
           {
               Popup popup = new Popup();
               popup.StaysOpen = true;
               popup.PlacementTarget = parent;
               popup.Placement = PlacementMode.Center;

               Border aroundBorder = new Border();
               aroundBorder.BorderThickness = new Thickness(2);
               aroundBorder.BorderBrush = Brushes.SteelBlue;

               StackPanel aroundStackPanel = new StackPanel();
               aroundStackPanel.MinWidth = 120;
               aroundStackPanel.MinHeight = 120;
               aroundStackPanel.MaxWidth = 480;
               aroundStackPanel.Background = Brushes.White;
               aroundStackPanel.Orientation = Orientation.Vertical;
               aroundStackPanel.FlowDirection = FlowDirection.LeftToRight;

               DockPanel headDockPanel = new DockPanel();
               headDockPanel.VerticalAlignment = VerticalAlignment.Top;
               headDockPanel.Background = Brushes.SteelBlue;

               TextBlock headTextBlock = new TextBlock();
               headTextBlock.Margin = new Thickness(10, 0, 0, 0);
               headTextBlock.Text = "提示";
               headTextBlock.Height = 26;
               headTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
               headTextBlock.VerticalAlignment = VerticalAlignment.Center;
               headTextBlock.FontSize = 16;
               headTextBlock.Focusable = false;
               headTextBlock.IsHitTestVisible = false;
               headTextBlock.Background = Brushes.SteelBlue;
               headTextBlock.Foreground = Brushes.White;

               TextBlock messageTextBlock = new TextBlock();
               messageTextBlock.Text = message;
               messageTextBlock.Margin = new Thickness(20, 20, 20, 10);
               messageTextBlock.MinHeight = 28;
               messageTextBlock.VerticalAlignment = VerticalAlignment.Top;
               messageTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
               messageTextBlock.TextWrapping = TextWrapping.Wrap;

               Button okButton = new Button();
               okButton.Content = "OK";
               okButton.Margin = new Thickness(0, 0, 20, 10);
               okButton.Padding = new Thickness(25, 3, 25, 3);
               okButton.HorizontalAlignment = HorizontalAlignment.Right;
               okButton.Click += delegate
               {
                   popup.IsOpen = false;
                   parent.IsEnabled = true;
               };

               headDockPanel.Children.Add(headTextBlock);
               aroundStackPanel.Children.Add(headDockPanel);
               aroundStackPanel.Children.Add(messageTextBlock);
               aroundStackPanel.Children.Add(okButton);
               aroundBorder.Child = aroundStackPanel;
               popup.Child = aroundBorder;

               parent.IsEnabled = false;
               popup.IsOpen = true;
           }));
       }

         public static void Show(UIElement parent, string message,double width)
        {
            parent.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
                {
                    Popup popup = new Popup();
                    popup.StaysOpen = true;
                    popup.PlacementTarget = parent; 
                    popup.Placement = PlacementMode.Center;

                    Border aroundBorder = new Border();
                    aroundBorder.BorderThickness = new Thickness(2);
                    aroundBorder.BorderBrush = Brushes.SteelBlue;

                    StackPanel aroundStackPanel = new StackPanel();
                    aroundStackPanel.MinWidth = width;
                    aroundStackPanel.MinHeight = 120;
                    aroundStackPanel.MaxWidth = 480;
                    aroundStackPanel.Background = Brushes.White;
                    aroundStackPanel.Orientation = Orientation.Vertical;
                    aroundStackPanel.FlowDirection = FlowDirection.LeftToRight;

                    DockPanel FootPanel = new DockPanel();
                    FootPanel.VerticalAlignment = VerticalAlignment.Bottom;
                    FootPanel.Background = Brushes.SteelBlue;

                    DockPanel headDockPanel = new DockPanel();
                    headDockPanel.VerticalAlignment = VerticalAlignment.Top;
                    headDockPanel.Background = Brushes.SteelBlue;

                    TextBlock headTextBlock = new TextBlock();
                    headTextBlock.Margin = new Thickness(10, 0, 0, 0);
                    headTextBlock.Text = "提示";
                    headTextBlock.Height = 26;
                    headTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                    headTextBlock.VerticalAlignment = VerticalAlignment.Center;
                    headTextBlock.FontSize = 16;
                    headTextBlock.Focusable = false;
                    headTextBlock.IsHitTestVisible = false;
                    headTextBlock.Background = Brushes.SteelBlue;
                    headTextBlock.Foreground = Brushes.White;

                    TextBlock messageTextBlock = new TextBlock();
                    messageTextBlock.Text = message;
                    messageTextBlock.Margin = new Thickness(20, 20, 20, 10);
                    messageTextBlock.MinHeight = 28;
                    messageTextBlock.VerticalAlignment = VerticalAlignment.Top;
                    messageTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                    messageTextBlock.TextWrapping = TextWrapping.Wrap;

                    //Button okButton = new Button();
                    //okButton.Content = "确定";
                    //okButton.Margin = new Thickness(10, 10, 20, 10);
                    //okButton.Padding = new Thickness(25, 3, 25, 3);
                    //okButton.HorizontalAlignment = HorizontalAlignment.Right;
                    //okButton.Click += delegate
                    //{
                    //    popup.IsOpen = false;
                    //    parent.IsEnabled = true;
                       
                    //};
                    Button CancelButton = new Button();
                    CancelButton.Content = "取消";
                    CancelButton.Margin = new Thickness(10, 10, 20, 10);
                    CancelButton.Padding = new Thickness(25, 3, 25, 3);
                    CancelButton.HorizontalAlignment = HorizontalAlignment.Right;
                    CancelButton.Click += delegate
                    {
                        popup.IsOpen = false;
                        parent.IsEnabled = true;
                    };
                    headDockPanel.Children.Add(headTextBlock);
                    aroundStackPanel.Children.Add(headDockPanel);                   
                    aroundStackPanel.Children.Add(messageTextBlock);
                    aroundStackPanel.Children.Add(FootPanel);
                    //FootPanel.Children.Add(okButton);
                    FootPanel.Children.Add(CancelButton);
                    aroundBorder.Child = aroundStackPanel;
                    popup.Child = aroundBorder;

                    parent.IsEnabled = false;
                    popup.IsOpen = true;
                }));
        }
    }
}
