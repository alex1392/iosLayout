using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CycWpfLibrary.NativeMethods;

namespace iosLayout
{
  public class Page1ViewModel
  {
    public CompositeCollection MainButtonsPanelItems { get; set; }
    public Page1ViewModel()
    {
      MainButtonsPanelItems = new CompositeCollection
      {
        new AppViewModel($"Assets/icon_message.png".PackUri(),  "Messages"),
        new AppViewModel($"Assets/icon_calendar.png".PackUri(), "Calendar"),
        new AppViewModel($"Assets/icon_photo.png".PackUri(),    "Photos"),
        new AppViewModel($"Assets/icon_camera.png".PackUri(),   "Camera"),
        new AppViewModel($"Assets/icon_weather.png".PackUri(),  "Weather"),
        new AppViewModel($"Assets/icon_map.png".PackUri(),      "Maps"),
        new AppViewModel($"Assets/icon_note.png".PackUri(),     "Notes"),
        new AppViewModel($"Assets/icon_appstore.png".PackUri(), "App Store"),
        new AppViewModel($"Assets/icon_health.png".PackUri(),   "Health"),
        new AppViewModel($"Assets/icon_settings.png".PackUri(), "Settings"),
        new AppViewModel($"Assets/icon_clock.png".PackUri(),    "Clock"),
        
        new FolderViewModel("Folder", new ObservableCollection<AppViewModel>
        {
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        })
      };
    }
  }
}
