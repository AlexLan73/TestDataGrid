
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using TestDG.Models;

using System;

namespace TestDG.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
  #region ----  Title  ----
  private string _title = "---!!!---   Test ---";
  public string Title
  {
    get => _title;
    set => this.RaiseAndSetIfChanged(ref _title, value);
  }
  #endregion

  private ObservableCollection<Human> _obHuman = new();
  public ObservableCollection<Human> ObHuman
  {
    get => _obHuman;
    set => this.RaiseAndSetIfChanged(ref _obHuman, value);
  }

  private SourceCache<Human, int> _dHumans = new(t => t.Id);
  public SourceCache<Human, int> DHumans
  {
    get => _dHumans;
    set => this.RaiseAndSetIfChanged(ref _dHumans, value);
  }


  private readonly ReadOnlyObservableCollection<Human> _list;
  public ReadOnlyObservableCollection<Human> TxList => _list;

  [Obsolete]
  public MainWindowViewModel()
  {
    var ds = new DataStream();
    ObHuman = new ObservableCollection<Human>(ds.LsHumans.ToArray());
    DHumans = new SourceCache<Human, int>(t => t.Id);

    _ = DHumans.Connect()
        .Filter(x=>x.Is==true)
        .ObserveOnDispatcher()
        .ObserveOn(RxApp.MainThreadScheduler)
        .Bind(out _list)
        .Subscribe();

    ds.LsHumans.ForEach(x => DHumans.AddOrUpdate(x));


  }

}

