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