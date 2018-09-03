using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class Page1ViewModel
  {
    public Page1ViewModel()
    {
      var imageList = new List<Uri>
      {
        new Uri($"pack://application:,,,/Assets/icon_message.png"),
        new Uri($"pack://application:,,,/Assets/icon_calendar.png"),
        new Uri($"pack://application:,,,/Assets/icon_photo.png"),
        new Uri($"pack://application:,,,/Assets/icon_camera.png"),
        new Uri($"pack://application:,,,/Assets/icon_weather.png"),
        new Uri($"pack://application:,,,/Assets/icon_map.png"),
        new Uri($"pack://application:,,,/Assets/icon_note.png"),
        new Uri($"pack://application:,,,/Assets/icon_appstore.png"),
        new Uri($"pack://application:,,,/Assets/icon_health.png"),
        new Uri($"pack://application:,,,/Assets/icon_settings.png"),
        new Uri($"pack://application:,,,/Assets/icon_clock.png"),
      };

      var labelList = new List<string>
      {
        "Messages",
        "Calendar",
        "Photos",
        "Camera",
        "Weather",
        "Maps",
        "Notes",
        "App Store",
        "Health",
        "Settings",
        "Clock",
      };

      for (int i = 0; i < imageList.Count; i++)
      {
        MainButtonsPanelItems.Add(new ButtonViewModel(imageList[i], labelList[i]));
      }
    }

    public List<ButtonViewModel> MainButtonsPanelItems { get; set; } = new List<ButtonViewModel>();
  }
}
