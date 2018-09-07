using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iosLayout
{
  public static class Constants
  {
    public static double ButtonWidth = 45;
    

    public static double ButtonMargin = ButtonWidth / 5;
    public static double ButtonCornerRadius = ButtonWidth / 4;
    public static double ButtonLabelMargin = ButtonWidth / 15;

    public static double FolderButtonWidth = ButtonWidth / 4;
    public static double FolderButtonCornerRadius = FolderButtonWidth / 4;
    public static double FolderButtonMargin = FolderButtonWidth / 8;
    public static double FolderContentWidth = FolderButtonWidth * 3 + FolderButtonMargin * 4;


  }
}
