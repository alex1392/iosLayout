using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iosLayout
{
  public class Page2ViewModel
  {
    public Page2ViewModel()
    {
      var imageList = new List<Uri>
      {
        new Uri($"pack://application:,,,/Assets/icon_angrybird.png"),
        new Uri($"pack://application:,,,/Assets/icon_calculator.png"),
        new Uri($"pack://application:,,,/Assets/icon_chrome.png"),
        new Uri($"pack://application:,,,/Assets/icon_contact.png"),
        new Uri($"pack://application:,,,/Assets/icon_DJ.png"),
        new Uri($"pack://application:,,,/Assets/icon_dropbox.png"),
        new Uri($"pack://application:,,,/Assets/icon_facebook.png"),
        new Uri($"pack://application:,,,/Assets/icon_facetime.png"),
        new Uri($"pack://application:,,,/Assets/icon_find.png"),
        new Uri($"pack://application:,,,/Assets/icon_firefox.png"),
        new Uri($"pack://application:,,,/Assets/icon_flappybird.png"),

      };

      var labelList = new List<string>
      {
        "Angry Bird",
        "Calculator",
        "Chrome",
        "Contact",
        "edjing Mix",
        "Dropbox",
        "Facebook",
        "FaceTime",
        "Find IPhone",
        "FireFox",
        "Flappy Bird",
      };

      for (int i = 0; i < imageList.Count; i++)
      {
        MainButtonsPanelItems.Add(new ButtonViewModel(imageList[i], labelList[i]));
      }
    }

    public List<ButtonViewModel> MainButtonsPanelItems { get; set; } = new List<ButtonViewModel>();
  }
}
