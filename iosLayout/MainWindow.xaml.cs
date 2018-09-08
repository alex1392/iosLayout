using CycWpfLibrary.NativeMethods;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace iosLayout
{
  /// <summary>
  /// MainWindow.xaml 的互動邏輯
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainWindowViewModel();
    }

    private Point DpiRatio;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      //Get DPI
      DpiRatio = this.GetDpiRatio();

    }

    private Point dragAnchor;
    private void backgroundImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
      //check double
      if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
      {
        Close();
        return;
      }

      dragAnchor = this.GetMousePosOnScreen();
      Mouse.Capture(backgroundImage);
    }
    private void backgroundImage_MouseMove(object sender, MouseEventArgs e)
    {
      if (Mouse.LeftButton == MouseButtonState.Pressed)
      {
        var mousePos = this.GetMousePosOnScreen();
        Left += (mousePos.X - dragAnchor.X) / DpiRatio.X;
        Top += (mousePos.Y - dragAnchor.Y) / DpiRatio.Y;
        dragAnchor = mousePos;
      }
    }
    private void backgroundImage_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Mouse.Capture(null);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var diff = viewBox.TranslatePoint(new Point(0, 0), this);
      var buttonCentre = new Point(viewBox.ActualWidth / 2, viewBox.ActualHeight / 2);
      var windowCentre = new Point(ActualWidth / 2, ActualHeight / 2);
      var shift = windowCentre.Minus(buttonCentre).Minus(diff);

      var animationX = new DoubleAnimation
      {
        From = 0,
        To = shift.X,
        Duration = new Duration(TimeSpan.FromMilliseconds(200)),
      };
      Storyboard.SetTarget(animationX, viewBox);
      Storyboard.SetTargetProperty(animationX, new PropertyPath("RenderTransform.(TranslateTransform.X)"));

      var animationY = new DoubleAnimation
      {
        From = 0,
        To = shift.Y,
        Duration = new Duration(TimeSpan.FromMilliseconds(200)),
      };
      Storyboard.SetTarget(animationY, viewBox);
      Storyboard.SetTargetProperty(animationY, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));

      var storyboard = new Storyboard();
      storyboard.Children.Add(animationX);
      storyboard.Children.Add(animationY);

      storyboard.Begin();
      
    }
  }
}
