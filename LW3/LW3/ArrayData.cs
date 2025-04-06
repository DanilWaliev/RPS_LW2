public class ArrayData
{
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; }
    public int[] Array { get; set; }

    public ArrayData()
    {
        Array = new int[Size]; // Теперь Size доступен
    }

    public ArrayData(string name, int[] array)
    {
        Name = name;
        Size = array.Length; 
        Array = array; 
    }
}