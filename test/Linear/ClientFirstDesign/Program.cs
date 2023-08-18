namespace VP.Dsa.Test.Linear.ClientFirstDesign;

public class Program
{
	public static void Main(String[] args)
	{
		//var sourceArray = new Int32[] { 1, 2, 3, 4, 5 };
		//var destinationArray = new Int32[8];
		//Array.Copy(sourceArray, destinationArray, 0);
		//Console.WriteLine("Nothing");

		IList<Int32> ints = new List<Int32>();
		var cc = ints.Count;

		var list = new List<Int32>();
		var c = list.Count;
		list.Capacity = 1;
		list.Add(1);
		list.AddRange(new[] { 1, 2, 3 });
		list.Clear();
		list.Contains(1);
		list.EnsureCapacity(1);
		list.IndexOf(1);
		list.LastIndexOf(1);
		list.Remove(1);
		list.RemoveAt(0);
		list.Sort();
		list.TrimExcess();
	}
}