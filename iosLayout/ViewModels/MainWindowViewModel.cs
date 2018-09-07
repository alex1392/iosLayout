using CycWpfLibrary.NativeMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace iosLayout
{
  public class MainWindowViewModel
  {
    public MainWindowViewModel()
    {
      InitializeMainButtonsPanel();
      InitializeFolder1Items();
    }

    public CompositeCollection MainButtonsPanelItems { get; set; }
    private void InitializeMainButtonsPanel()
    {
      MainButtonsPanelItems = new CompositeCollection
      {
        new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new AppViewModel($"Assets/icon_safari.png".PackUri(), "Safari"),
        new AppViewModel($"Assets/icon_mail.png".PackUri(), "Mail"),
        new AppViewModel($"Assets/icon_music.png".PackUri(), "Music"),

      };
    }

    public ObservableCollection<AppViewModel> Folder1Items { get; set; }
    private void InitializeFolder1Items()
    {
      Folder1Items = new ObservableCollection<AppViewModel>
      {
        new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new AppViewModel($"Assets/icon_safari.png".PackUri(), "Safari"),
        new AppViewModel($"Assets/icon_mail.png".PackUri(), "Mail"),
        new AppViewModel($"Assets/icon_music.png".PackUri(), "Music"),
        new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new AppViewModel($"Assets/icon_safari.png".PackUri(), "Safari"),
        new AppViewModel($"Assets/icon_mail.png".PackUri(), "Mail"),
        new AppViewModel($"Assets/icon_music.png".PackUri(), "Music"),

      };
    }
  }
}
