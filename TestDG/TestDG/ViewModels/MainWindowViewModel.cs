
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using TestDG.Models;

using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

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
        .ObserveOnDispatcher()
        .ObserveOn(RxApp.MainThreadScheduler)
        .Filter(x => x.Is == true)
        .Bind(out _list)
        .Subscribe(t => losdxx(t));

    ds.LsHumans.ForEach(x => DHumans.AddOrUpdate(x));

    //this.WhenAnyObservable(this.DHumans.KeyValues.GetEnumerator().Current.Value.Is, x=>x.Changed)
    //    DHumans.Items.WhenAnyValue(x => x.Select(z => z.Is)).WhenAnyValue(s => s).Subscribe(t => wwww(t));

    //    this.WhenAnyValue(x=>x.DHumans.Items. )
    //      .Subscribe(t => losdxx001(t));

    this.PropertyChanged += MainWindowViewModel_PropertyChanged;
    this.PropertyChanging += MainWindowViewModel_PropertyChanging;
  }

  private object qqq(IObservedChange<SourceCache<Human, int>, object> change)
  {
    return change;
  }

  private void losdxx001(IEnumerable<Human> t)
  {
    
  }

  private void losdxx(IChangeSet<Human, int> t)
  {
    
  }

  private void MainWindowViewModel_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
  {
    
  }


  private void MainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
  {
   
  }

}

