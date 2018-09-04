using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using static CycWpfLibrary.Math;

namespace iosLayout
{
  public class SwipeableFrame : Canvas
  {
    public SwipeableFrame()
    {
      Visibility = Visibility.Hidden;
      Background = new SolidColorBrush(Colors.Transparent);

      // Invoke after all chilren are loaded
      Dispatcher.InvokeAsync(new Action(() => InitializeSwipeContainer()), DispatcherPriority.Loaded);
    }
    int ChildrenCount;
    private TranslateTransform childrenTransform(int index) => Children[index].RenderTransform as TranslateTransform;
    private void InitializeSwipeContainer()
    {
      ChildrenCount = Children.Count;
      for (int i = 0; i < ChildrenCount; i++)
      {
        //將原本重疊的children移動到畫面之外
        Children[i].RenderTransform = new TranslateTransform { X = ActualWidth * i };

        //初始化動畫
        var animation = new DoubleAnimation
        {
          Duration = new Duration(TimeSpan.FromMilliseconds(200)),
        };
        Storyboard.SetTarget(animation, Children[i]);
        Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
        SwipeStoryboard.Children.Add(animation);
      }

      Visibility = Visibility.Visible;
    }

    double deltaXMax;
    double deltaXMin;
    int _CurrentIndex = 0;
    int CurrentIndex
    {
      get => _CurrentIndex;
      set
      {
        _CurrentIndex = Clamp(value, 0, ChildrenCount - 1);
      }
    }
    Point MouseAnchor;
    List<double> ChildrenAnchor = new List<double>();
    Storyboard SwipeStoryboard = new Storyboard();
    List<double> MouseXTrack = new List<double>();
    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
      base.OnMouseDown(e);
      CaptureMouse(); //避免滑鼠離開視窗而捕捉不到MouseUp
      SwipeStoryboard.Stop(); //中斷動畫 ,,,,, bug??
      ChildrenAnchor.Clear();

      //紀錄錨點
      MouseAnchor = Mouse.GetPosition(this);
      MouseXTrack.Add(MouseAnchor.X);
      for (int i = 0; i < ChildrenCount; i++)
      {
        ChildrenAnchor.Add(childrenTransform(i).X);
      }
      //紀錄deltaX最大最小值
      deltaXMax = CurrentIndex * ActualWidth;
      deltaXMin = (CurrentIndex - (ChildrenCount - 1)) * ActualWidth;

      //更新畫面
      OnMouseMove(e);
    }

    private double OutCubicEase(double x)
    {
      return 3 * x - 3 * Math.Pow(x, 2) + Math.Pow(x, 3);
    }
    private double EasingOverflow(double overflow)
    {
      var MaxSwipeRange = 5 * ActualWidth;
      var EasingXStretch = 10 * ActualWidth;
      var EasingYStretch = 0.9 * ActualWidth;
      overflow = Clamp(overflow, MaxSwipeRange, 0);
      return EasingYStretch * OutCubicEase(overflow / EasingXStretch);
    }
    private double EasingDeltaX(double deltaX)
    {
      if (deltaX > deltaXMax)
      {
        var overflow = deltaX - deltaXMax;
        overflow = EasingOverflow(overflow);
        deltaX = deltaXMax + overflow;
      }
      else if (deltaX < deltaXMin)
      {
        var overflow = deltaXMin - deltaX; //overflow恆正
        overflow = EasingOverflow(overflow);
        deltaX = deltaXMin - overflow;
      }
      return deltaX;
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (e.LeftButton != MouseButtonState.Pressed)
      {
        return;
      }

      var pos = Mouse.GetPosition(this);
      var deltaX = pos.X - MouseAnchor.X;
      deltaX = EasingDeltaX(deltaX);
      MouseXTrack.Add(pos.X);

      //移動
      for (int i = 0; i < ChildrenCount; i++)
      {
        childrenTransform(i).X = ChildrenAnchor[i] + deltaX;
      }
    }

    private double VelocityThreshold = 10;
    private double AveMouseXTrack(int N)
    {
      // N = last N elements to average
      N = Clamp(N, MouseXTrack.Count, 0);
      return MouseXTrack.GetRange(MouseXTrack.Count - N, N).Average();
    }
    private void SwipeStoryboard_Completed(object sender, EventArgs e)
    {
      SwipeStoryboard.Stop();
      for (int i = 0; i < ChildrenCount; i++)
      {
        childrenTransform(i).X = GetSettledChild(i);
      }
    }
    private double GetSettledChild(int pageIndex) => (pageIndex - CurrentIndex) * ActualWidth;
    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
      base.OnMouseUp(e);
      var pos = Mouse.GetPosition(this);
      var deltaX = pos.X - MouseAnchor.X;
      var velocity = pos.X - AveMouseXTrack(10);

      //判斷換頁
      if (deltaX > 0 && Math.Abs(velocity) > VelocityThreshold ||
        deltaX > ActualWidth / 2)
      {
        CurrentIndex--;
      }
      else if (deltaX < 0 && Math.Abs(velocity) > VelocityThreshold ||
        deltaX < -ActualWidth / 2)
      {
        CurrentIndex++;
      }
      //啟動動畫
      for (int i = 0; i < ChildrenCount; i++)
      {
        (SwipeStoryboard.Children[i] as DoubleAnimation).From = childrenTransform(i).X;
        (SwipeStoryboard.Children[i] as DoubleAnimation).To = GetSettledChild(i);
      }
      SwipeStoryboard.Completed += SwipeStoryboard_Completed;
      SwipeStoryboard.Begin();

      ReleaseMouseCapture();
      MouseXTrack.Clear();
    }
  }
}
