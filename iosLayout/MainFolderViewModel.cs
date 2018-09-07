using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class MainFolderViewModel : FolderViewModel
  {
    public MainFolderViewModel() : base() { }
    public MainFolderViewModel(string label) : base(label) { }
    public MainFolderViewModel(string label, ObservableCollection<AppViewModel> children) : base(label, children) { }
  }
}
