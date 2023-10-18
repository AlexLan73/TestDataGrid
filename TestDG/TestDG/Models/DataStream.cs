using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TestDG.Models;

public interface IDataContext
{
  DataStream DS { get; set; }
}
public class DataContext : IDataContext
{
  public DataStream DS { get; set; } = new ();
}

public class Human :  ReactiveObject  //, INotifyPropertyChanged
{
  public Action<object> CallBackAction { get; set; }

  public Human(Action<object> callback)
  {
    CallBackAction = callback;

    this.WhenPropertyChanged(x => x.Is, notifyOnInitialValue: false)
      .Subscribe(t => CallBackAction00(this));

    var obser = this.WhenAnyValue(x => x.Is)
      .Subscribe(t => CallBackAction(this));

    this.PropertyChanged += Human_PropertyChanged;
  }

  private void Human_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    
  }

  private void CallBackAction00(Human human)
  {
    
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public int Arg { get; set; }
  public float Value { get; set; }
  [Reactive]
  public bool Is { get; set; }
//  public object PoleXX { get; private set; }
  //  private string name;
  //  private bool _is;


  //  [Reactive]
  /*  
    public bool Is
    {
      get =>_is;
      set
      {
        _is=value;
        name = "is";
        OnPropertyChanged();
      } 

    }
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  */


}

public class DataStream
{
  public List<Human> LsHumans { get; set; }= new List<Human> ();
  public SourceList<Human> Humans { get; set; } = new SourceList<Human>();
  public SourceCache<Human, int> DHumans { get; set; } = new SourceCache<Human, int>(t => t.Id);
  public DataStream()
  {
    Inicial();
//    var x = LsHumans.ElementAt(1);
//    x.Is=true;
  }

  public void ControlAction(object t)
  {
    var x = (Human)t;
    if (x.Name != null)
    {

    }
  }
  public void Inicial()
  {
    LsHumans.Clear();
    DHumans.Clear();
    Humans.Clear();
    Human _human00 = new Human(ControlAction) { Id = 0, Name = "Name0", Arg = 10, Value = 1f, Is = true };
    LsHumans.Add(_human00);

    Human _human01 = new Human(ControlAction) { Id = 1, Name = "Name1", Arg = 20, Value = 2f, Is = false };
    LsHumans.Add(_human01);

    Human _human02 = new Human(ControlAction) { Id = 2, Name = "Name2", Arg = 30, Value = 3f, Is = true };
    LsHumans.Add(_human02);

    Human _human03 = new Human(ControlAction) { Id = 3, Name = "Name3", Arg = 40, Value = 4f, Is = false };
    LsHumans.Add(_human03);

    Human _human04 = new Human(ControlAction) { Id = 4, Name = "Name4", Arg = 50, Value = 5f, Is = true };
    LsHumans.Add(_human04);

    Human _human05 = new Human(ControlAction) { Id = 4, Name = "Name4", Arg = 50, Value = 5f, Is = true };
    LsHumans.Add(_human05);

    Human _human06 = new Human(ControlAction) { Id = 5, Name = "Name5", Arg = 60, Value = 6f, Is = false };
    LsHumans.Add(_human06);


  }


}

