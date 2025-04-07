using LiteDB;
using System.Collections.Generic;
using System.Linq;

public class ArrayRepository
{
    // Путь до БД
    private readonly string databasePath;

    public ArrayRepository(string databasePath)
    {
        this.databasePath = databasePath;
    }

    // Добавляет массив в БД
    public void AddArray(ArrayData arrayData)
    {
        using (var db = new LiteDatabase(databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            collection.Insert(arrayData);
        }
    }

    // Возаращает все массивы из БД
    public IEnumerable<ArrayData> GetAllArrays()
    {
        using (var db = new LiteDatabase(databasePath))
        {
            return db.GetCollection<ArrayData>("arrays").FindAll().ToList();
        }
    }

    // Удаление по имени
    public void DeleteArray(string arrayName)
    {
        using (var db = new LiteDatabase(databasePath))
        {
            var collection = db.GetCollection<ArrayData>("arrays");
            collection.DeleteMany(x => x.Name == arrayName);
        }
    }
}