namespace VP.Dsa.Test.Linear.ClientFirstDesign;

using VP.DataStructures.Linear.DynamicArray;

public class Program
{
	public static void Main(String[] args)
	{
		//This piece of code shows how another developer will be using your data structure
		IMyList list = new MyList();
		var c = list.Count;
		list.Capacity = 1;
		list.Add(1);
		list.Clear();
		list.Contains(1);
		list.IndexOf(1);
		list.LastIndexOf(1);
		list.Remove(1);
		list.RemoveAt(0);
		list.Sort();
		list.TrimExcess();
	}
}