using System;
using System.Windows;
using System.Windows.Input;

namespace iosLayout
{
  /// <summary>
  /// MainWindow.xaml 的互動邏輯
  /// </summary>
  public partial class MainWindow : Window
  {
    double dpiXRatio = 1;
    double dpiYRatio = 1;
    public MainWindow()
    {
      InitializeComponent();

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      //Get DPI
      PresentationSource source = PresentationSource.FromVisual(this);
      double dpiX, dpiY;
      if (source != null)
      {
        dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
        dpiY = 96.0 * source.CompositionTarget.TransformToDevice.M22;
        dpiXRatio = dpiX / 96;
        dpiYRatio = dpiY / 96;
      }

    }

    Point dragAnchor;
    Point MousePosToScreen()
    {
      return PointToScreen(Mouse.GetPosition(this));
    }
    private void backgroundImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
      //check double
      if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
      {
        Close();
        return;
      }

      dragAnchor = MousePosToScreen();
      Mouse.Capture(backgroundImage);
    }

    private void backgroundImage_MouseMove(object sender, MouseEventArgs e)
    {
      if (Mouse.LeftButton == MouseButtonState.Pressed)
      {
        var mousePos = MousePosToScreen();
        Left += (mousePos.X - dragAnchor.X) / dpiXRatio;
        Top += (mousePos.Y - dragAnchor.Y) / dpiYRatio;
        dragAnchor = mousePos;
      }
    }

    private void backgroundImage_MouseUp(object sender, MouseButtonEventArgs e)
    {
      Mouse.Capture(null);
    }
  }
}
