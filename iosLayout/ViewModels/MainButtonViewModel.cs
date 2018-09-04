using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace iosLayout
{
  /// <summary>
  /// 主選單中的按鈕，繼承自<see cref="MainButtonViewModel"/>而沒有實作任何新的成員。
  /// 創建此類別主要是為了方便在<see cref="ResourceDictionary"/>中讓兩種按鈕具有不同的<see cref="Style"/>。
  /// </summary>
  public class MainButtonViewModel : ButtonViewModel
  {
    public MainButtonViewModel() : base() { } 
    public MainButtonViewModel(Uri image) : base(image) { }
    public MainButtonViewModel(Uri image, string label) : base(image, label) { }
  }
}
