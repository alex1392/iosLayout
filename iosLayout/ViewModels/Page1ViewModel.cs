using System;
using System.Collections.Generic;
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
        new ButtonViewModel($"Assets/icon_phone.png".PackUri(),    "Phone"),
        new ButtonViewModel($"Assets/icon_safari.png".PackUri(),   "Safari"),
        new ButtonViewModel($"Assets/icon_mail.png".PackUri(),     "Mail"),
        new ButtonViewModel($"Assets/icon_music.png".PackUri(),    "Music"),
        new ButtonViewModel($"Assets/icon_message.png".PackUri(),  "Messages"),
        new ButtonViewModel($"Assets/icon_calendar.png".PackUri(), "Calendar"),
        new ButtonViewModel($"Assets/icon_photo.png".PackUri(),    "Photos"),
        new ButtonViewModel($"Assets/icon_camera.png".PackUri(),   "Camera"),
        new ButtonViewModel($"Assets/icon_weather.png".PackUri(),  "Weather"),
        new ButtonViewModel($"Assets/icon_map.png".PackUri(),      "Maps"),
        new ButtonViewModel($"Assets/icon_note.png".PackUri(),     "Notes"),
        new ButtonViewModel($"Assets/icon_appstore.png".PackUri(), "App Store"),
        new ButtonViewModel($"Assets/icon_health.png".PackUri(),   "Health"),
        new ButtonViewModel($"Assets/icon_settings.png".PackUri(), "Settings"),
        new ButtonViewModel($"Assets/icon_clock.png".PackUri(),    "Clock"),
      };
    }
  }
}
