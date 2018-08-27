using System;
using System.Windows;
using System.Windows.Controls;

namespace iosLayout
{
  /// <summary>
  /// btnApp.xaml 的互動邏輯
  /// </summary>
  public partial class btnApp : UserControl
  {
    public btnApp()
    {
      InitializeComponent();
      gridMain.DataContext = this;
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(btnApp), new PropertyMetadata(""));
    public String Text
    {
      get { return (String)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof(Image), typeof(Uri), typeof(btnApp), new PropertyMetadata());
    public Uri Image
    {
      get { return (Uri)GetValue(ImageProperty); }
      set { SetValue(ImageProperty, value); }
    }
  }
}
