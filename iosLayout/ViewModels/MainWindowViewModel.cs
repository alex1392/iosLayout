using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CycWpfLibrary.NativeMethods;

namespace iosLayout
{
  public class MainWindowViewModel
  {
    public MainWindowViewModel()
    {
      InitializeMainButtonsPanel();
    }

    public CompositeCollection MainButtonsPanelItems { get; set; }
    private void InitializeMainButtonsPanel()
    {
      MainButtonsPanelItems = new CompositeCollection
      {
        new MainButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new MainButtonViewModel($"Assets/icon_safari.png".PackUri(), "Safari"),
        new MainButtonViewModel($"Assets/icon_mail.png".PackUri(), "Mail"),
        new MainButtonViewModel($"Assets/icon_music.png".PackUri(), "Music"),
        //new MainFolderViewModel("Folder", new ObservableCollection<ButtonViewModel>
        //{
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //  new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        //})
      };
    }
  }
}
