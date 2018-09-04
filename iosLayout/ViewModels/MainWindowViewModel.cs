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
  public class MainWindowViewModel
  {
    public MainWindowViewModel()
    {
      InitializeMainButtonsPanel();
      InitializeFolder1();
    }


    public List<ButtonViewModel> Folder1Items { get; set; } = new List<ButtonViewModel>();
    private void InitializeFolder1()
    {
      var imageList = new List<Uri>
      {
        new Uri($"pack://application:,,,/Assets/icon_phone.png"),
        new Uri($"pack://application:,,,/Assets/icon_safari.png"),
        new Uri($"pack://application:,,,/Assets/icon_mail.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
        new Uri($"pack://application:,,,/Assets/icon_music.png"),
      };

      for (int i = 0; i < imageList.Count; i++)
      {
        Folder1Items.Add(new ButtonViewModel(imageList[i]));
      }
    }

    //public List<ButtonViewModel> MainButtonsPanelItems { get; set; } = new List<ButtonViewModel>();
    public CompositeCollection MainButtonsPanelItems { get; set; }
    private void InitializeMainButtonsPanel()
    {
      MainButtonsPanelItems = new CompositeCollection
      {
        new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        new FolderViewModel("Folder", new ObservableCollection<ButtonViewModel>
        {
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
          new ButtonViewModel($"Assets/icon_phone.png".PackUri(), "Phone"),
        })
      };

      //var imageList = new List<Uri>
      //{
      //  new Uri($"pack://application:,,,/Assets/icon_phone.png"),
      //  new Uri($"pack://application:,,,/Assets/icon_safari.png"),
      //  new Uri($"pack://application:,,,/Assets/icon_mail.png"),
      //  new Uri($"pack://application:,,,/Assets/icon_music.png"),
      //};
      //var labelList = new List<string>
      //{
      //  "Phone",
      //  "Safari",
      //  "Mail",
      //  "Music",
      //};

      //for (int i = 0; i < imageList.Count; i++)
      //{
      //  MainButtonsPanelItems.Add(new ButtonViewModel(imageList[i], labelList[i]));
      //}
    }

  }
}
