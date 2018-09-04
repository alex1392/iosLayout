using CycWpfLibrary.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iosLayout
{
  /// <summary>
  /// IOS系統之按鈕類別。
  /// </summary>
  public class ButtonViewModel : ViewModelBase
  {
    public ButtonViewModel()
    {

    }
    public ButtonViewModel(Uri image) : this()
    {
      Image = image;
    }
    public ButtonViewModel(Uri image, string label) : this(image)
    {
      Label = label;
    }


    /// <summary>
    /// 按鈕之名稱
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// 應用程式icon之URI。
    /// 若按鈕種類為<see cref="ButtonType.Folder"/>，則此屬性應為null。
    /// </summary>
    public Uri Image { get; set; }
  }
}
