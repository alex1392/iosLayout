using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class MainWindowViewModel
  {
    public MainWindowViewModel()
    {
      var imageList = new List<Uri>
      {
        new Uri($"pack://application:,,,/Assets/icon_phone.png"),
        new Uri($"pack://application:,,,/Assets/icon_safari.png"),
        new Uri($"pack://application:,,,/Assets/icon_mail.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
      };
      var labelList = new List<string>
      {
        "Phone",
        "Safari",
        "Mail",
        "Music",
      };

      for (int i = 0; i < imageList.Count; i++)
      {
        MainButtonsPanelItems.Add(new ButtonModel(imageList[i], labelList[i]));
      }
    }

    public List<ButtonModel> MainButtonsPanelItems { get; set; } = new List<ButtonModel>();
  }
}
