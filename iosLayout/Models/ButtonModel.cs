using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class ButtonModel
  {
    public ButtonModel()
    {

    }

    public ButtonModel(Uri image, string label) : this()
    {
      Image = image;
      Label = label;
    }

    /// <summary>
    /// 按鈕圖像之URI
    /// </summary>
    public Uri Image { get; set; }

    /// <summary>
    /// 按鈕之名稱
    /// </summary>
    public string Label { get; set; }
  }
}
