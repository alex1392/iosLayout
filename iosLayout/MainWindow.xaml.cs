using System;
using System.Windows;
using System.Windows.Input;
using CycWpfLibrary.NativeMethods;

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

    }

    Point DpiRatio;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      //Get DPI
      DpiRatio = this.GetDpiRatio();

    }

    private Point dragAnchor;
    private Point MousePosOnScreen() => PointToScreen(Mouse.GetPosition(this));
    private void backgroundImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
      //check double
      if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
      {
        Close();
        return;
      }

      dragAnchor = MousePosOnScreen();
      Mouse.Capture(backgroundImage);
    }
    private void backgroundImage_MouseMove(object sender, MouseEventArgs e)
    {
      if (Mouse.LeftButton == MouseButtonState.Pressed)
      {
        var mousePos = MousePosOnScreen();
        Left += (mousePos.X - dragAnchor.X) / DpiRatio.X;
        Top += (mousePos.Y - dragAnchor.Y) / DpiRatio.Y;
        dragAnchor = mousePos;
      }
    }
    private void backgroundImage_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Mouse.Capture(null);
    }
  }
}
