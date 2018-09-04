using CycWpfLibrary.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class FolderViewModel : ViewModelBase
  {
    public FolderViewModel()
    {

    }
    public FolderViewModel(string label) : this()
    {
      Label = label;
    }
    public FolderViewModel(string label, ObservableCollection<ButtonViewModel> children) : this(label)
    {
      Children = children;
    }

    /// <summary>
    /// 按鈕之名稱
    /// </summary>
    public string Label { get; set; }
    /// <summary>
    /// 資料夾內之子項目。
    /// </summary>
    public ObservableCollection<ButtonViewModel> Children { get; set; }
  }
}
