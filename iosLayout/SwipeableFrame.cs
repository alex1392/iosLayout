using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using static MyLibrary.Methods.Math;

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

    private void InitializeSwipeContainer()
    {
      for (int i = 0; i < Children.Count; i++)
      {
        //將原本重疊的children移動到畫面之外
        Children[i].RenderTransform = new TranslateTransform { X = ActualWidth * i };

        //初始化動畫
        var animation = new DoubleAnimation
        {
          Duration = new Duration(TimeSpan.FromMilliseconds(300)),
        };
        Storyboard.SetTarget(animation, Children[i]);
        Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
        SwipeStoryboard.Children.Add(animation);
      }
      SwipeStoryboard.Begin();

      Visibility = Visibility.Visible;
    }
    
    Point MouseAnchor;
    List<double> ChildrenAnchor = new List<double>();
    Storyboard SwipeStoryboard = new Storyboard();
    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
      base.OnMouseDown(e);
      CaptureMouse(); //避免滑鼠離開視窗而捕捉不到MouseUp
      SwipeStoryboard.Stop(); //中斷動畫
      ChildrenAnchor.Clear();

      //紀錄錨點
      MouseAnchor = Mouse.GetPosition(this);
      for (int i = 0; i < Children.Count; i++)
      {
        ChildrenAnchor.Add(childrenTransform(i).X);
      }
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
      for (int i = 0; i < Children.Count; i++)
      {
        childrenTransform(i).X = ChildrenAnchor[i] + deltaX;
      }
    }

    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
      base.OnMouseUp(e);
      var pos = Mouse.GetPosition(this);
      var deltaX = pos.X - MouseAnchor.X;
      if (deltaX > ActualWidth / 2)
      {
        CurrentIndex--;
      }
      else if (deltaX < -ActualWidth / 2)
      {
        CurrentIndex++;
      }

      for (int i = 0; i < Children.Count; i++)
      {
        (SwipeStoryboard.Children[i] as DoubleAnimation).From = childrenTransform(i).X;
        (SwipeStoryboard.Children[i] as DoubleAnimation).To = GetSettledChild(i);
      }
      SwipeStoryboard.Completed += SwipeStoryboard_Completed;
      SwipeStoryboard.Begin();

      ReleaseMouseCapture(); 
    }

    private void SwipeStoryboard_Completed(object sender, EventArgs e)
    {
      SwipeStoryboard.Stop();
      for (int i = 0; i < Children.Count; i++)
      {
        childrenTransform(i).X = GetSettledChild(i);
      }
    }

    private TranslateTransform childrenTransform(int index) => Children[index].RenderTransform as TranslateTransform;
    int CurrentIndex = 0;
    private double GetSettledChild(int pageIndex)
    {
      return (pageIndex - CurrentIndex) * ActualWidth;
    }
  }
}
