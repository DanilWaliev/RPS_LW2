using LiteDB;
using System;
using System.Collections.Generic;

public class ArrayRepository : IDisposable
{
    private readonly LiteDatabase db;
    private bool disposed;

    public ArrayRepository(string databasePath)
    {
        db = new LiteDatabase(databasePath);
    }

    public void AddArray(ArrayData arrayData)
    {
        CheckDisposed();
        db.GetCollection<ArrayData>("arrays").Insert(arrayData);
    }

    public IEnumerable<ArrayData> GetAllArrays()
    {
        CheckDisposed();
        return db.GetCollection<ArrayData>("arrays").FindAll();
    }

    public ArrayData GetArrayByName(string name)
    {
        CheckDisposed();

        // Ищем массив
        var array = db.GetCollection<ArrayData>("arrays")
            .FindOne(arr => arr.Name == name);

        if (array == null)
        {
            throw new Exception($"Массив с именем '{name}' не найден");
        }

        return array;
    }

    public void DeleteArray(string name)
    {
        CheckDisposed();
        db.GetCollection<ArrayData>("arrays").DeleteMany(arr => arr.Name == name);
    }

    private void CheckDisposed()
    {
        if (disposed)
        {
            throw new ObjectDisposedException(nameof(ArrayRepository));
        }
    }

    public void Dispose()
    {
        if (!disposed)
        {
            db.Dispose();
            disposed = true;
        }
    }
}