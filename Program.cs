using System;
using System.Linq;
using System.Collections.Generic;

namespace IEnumerator561;
class Program
{
    static void Main(string[] args)
    {
        var sports = new ManualSportSequence();
        foreach (var sport in sports) Console.WriteLine(sport);
    }
}
class ManualSportSequence : IEnumerable<Sport>
{
    public IEnumerator<Sport> GetEnumerator()
    {
        return new ManualSportEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing }

class ManualSportEnumerator : IEnumerator<Sport>
{
    int current = -1;
    public Sport Current { get { return (Sport)current; } }
    public void Dispose() { return; }
    object System.Collections.IEnumerator.Current { get {  return Current; } }
    public bool MoveNext()
    {
        var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        if ((int)current >= maxEnumValue - 1) return false;
        current++;
        return true;
    }
    public void Reset() { current = 0; }
}

