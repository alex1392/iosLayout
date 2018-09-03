using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class ButtonViewModel
  {
    public ButtonViewModel()
    {

    }
    public ButtonViewModel(Uri image) : this()
    {
      Image = image;
    }
    public ButtonViewModel(Uri image, string label) : this()
    {
      Image = image;
      Label = label;
    }

    /// <summary>
    /// 按鈕之名稱
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// 按鈕之種類
    /// </summary>
    public ButtonType Type { get; set; }
    /// <summary>
    /// 應用程式icon之URI。
    /// 若按鈕種類為<see cref="ButtonType.Folder"/>，則此屬性應為null。
    /// </summary>
    public Uri Image { get; set; }
    /// <summary>
    /// 資料夾內之子項目。
    /// 若按鈕種類為<see cref="ButtonType.Application"/>，則此屬性為null。
    /// </summary>
    public ObservableCollection<ButtonViewModel> Children { get; set; }
  }
}
