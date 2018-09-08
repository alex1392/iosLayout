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
      Initialize();
    }

    public void Initialize()
    {
      InitializeMainButtonsPanel();
      InitializePage1Items();
      InitializePage2Items();
      InitializeFolder1Items();
    }

    UIElement _BlurContainer;
    public UIElement BlurContainer
    {
      get => _BlurContainer;
      set
      {
        _BlurContainer = value;
        Initialize(); //更新Folder需要引用的BlurContainer
      }
    }
    
    public CompositeCollection MainPanelItems { get; set; }
    private void InitializeMainButtonsPanel()
    {
      MainPanelItems = new CompositeCollection
      {
        new AppViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new AppViewModel($"Assets/icon_safari.png".PackUri(), "Safari"),
        new AppViewModel($"Assets/icon_mail.png".PackUri(), "Mail"),
        new AppViewModel($"Assets/icon_music.png".PackUri(), "Music"),

      };
    }

    public CompositeCollection Page1Items { get; set; }
    private void InitializePage1Items()
    {
      Page1Items = new CompositeCollection
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
        {
          BlurContainer = BlurContainer
        }

      };
    }

    public CompositeCollection Page2Items { get; set; }
    private void InitializePage2Items()
    {
      Page2Items = new CompositeCollection
      {
        new AppViewModel($"Assets/icon_angrybird.png".PackUri(),  "Angry Bird"  ),
        new AppViewModel($"Assets/icon_calculator.png".PackUri(), "Calculator"  ),
        new AppViewModel($"Assets/icon_chrome.png".PackUri(),     "Chrome"      ),
        new AppViewModel($"Assets/icon_contact.png".PackUri(),    "Contact"     ),
        new AppViewModel($"Assets/icon_DJ.png".PackUri(),         "edjing Mix"  ),
        new AppViewModel($"Assets/icon_dropbox.png".PackUri(),    "Dropbox"     ),
        new AppViewModel($"Assets/icon_facebook.png".PackUri(),   "Facebook"    ),
        new AppViewModel($"Assets/icon_facetime.png".PackUri(),   "FaceTime"    ),
        new AppViewModel($"Assets/icon_find.png".PackUri(),       "Find IPhone" ),
        new AppViewModel($"Assets/icon_firefox.png".PackUri(),    "FireFox"     ),
        new AppViewModel($"Assets/icon_flappybird.png".PackUri(), "Flappy Bird" ),

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
