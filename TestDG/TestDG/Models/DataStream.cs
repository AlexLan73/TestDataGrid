using System.Collections.Generic;
using DynamicData;

namespace TestDG.Models;

public interface IDataContext
{
  DataStream DS { get; set; }
}
public class DataContext : IDataContext
{
  public DataStream DS { get; set; } = new ();
}

public class Human
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Arg { get; set; }
  public float Value { get; set; }
  public bool Is { get; set; }
}

public class DataStream
{
  public List<Human> LsHumans { get; set; }= new List<Human> ();
  public SourceList<Human> Humans { get; set; } = new SourceList<Human>();
  public SourceCache<Human, int> DHumans { get; set; } = new SourceCache<Human, int>(t => t.Id);
  public DataStream()
  {
    Inicial();
  }

  public void Inicial()
  {
    LsHumans.Clear();
    DHumans.Clear();
    Humans.Clear();
    LsHumans.Add(new Human() { Id = 0, Name = "Name0", Arg = 10, Value = 1f, Is = true });
    LsHumans.Add(new Human() { Id = 1, Name = "Name1", Arg = 20, Value = 2f, Is = false });
    LsHumans.Add(new Human() { Id = 2, Name = "Name2", Arg = 30, Value = 3f, Is = true });
    LsHumans.Add(new Human() { Id = 3, Name = "Name3", Arg = 40, Value = 4f, Is = false });
    LsHumans.Add(new Human() { Id = 4, Name = "Name4", Arg = 50, Value = 5f, Is = true });
    LsHumans.Add(new Human() { Id = 5, Name = "Name5", Arg = 60, Value = 6f, Is = false });

  }
}

