using LiteDB;

public class ArrayRepository
{
    private readonly string _databasePath;

    public ArrayRepository(string databasePath)
    {
        _databasePath = databasePath;
    }

    // Добавление нового массива
    public void AddArray(ArrayData arrayData)
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            collection.Insert(arrayData);
        }
    }

    // Получение всех массивов
    public IEnumerable<ArrayData> GetAllArrays()
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            return collection.FindAll().ToList();
        }
    }

    // Получение массива по ID
    public ArrayData GetArrayById(int id)
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            return collection.FindById(id);
        }
    }

    // Обновление массива
    public void UpdateArray(ArrayData arrayData)
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            collection.Update(arrayData);
        }
    }

    // Удаление массива
    public void DeleteArray(int id)
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            collection.Delete(id);
        }
    }
}