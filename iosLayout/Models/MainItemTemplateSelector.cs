using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace iosLayout
{
  public class MainItemTemplateSelector : DataTemplateSelector
  {
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
      FrameworkElement element = container as FrameworkElement;

      var button = item as ButtonViewModel;
      switch (button.Type)
      {
        case ButtonType.Application:
          return element.FindResource("MainAppTemplate") as DataTemplate;
        case ButtonType.Folder:
          return element.FindResource("MainFolderTemplate") as DataTemplate;
        default:
          return null;
      }
    }
  }
}
