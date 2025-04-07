using LW3;
using System.Diagnostics;

namespace LW3_Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Add100Arrays()
        {
            // Arrange
            var dbPath = "test100load.db";
            using (var repo = new ArrayRepository(dbPath))
            {
                // Act
                for (int i = 0; i < 100; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }

                // Assert
                var allArrays = repo.GetAllArrays().ToList();
                Assert.AreEqual(100, allArrays.Count);
            }

            SafeDelete(dbPath);
        }

        [TestMethod]
        public void Add1000Arrays()
        {
            // Arrange
            var dbPath = "test1000load.db";
            using (var repo = new ArrayRepository(dbPath))
            {
                // Act
                for (int i = 0; i < 1000; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }

                // Assert
                var allArrays = repo.GetAllArrays().ToList();
                Assert.AreEqual(1000, allArrays.Count);
            }

            SafeDelete(dbPath);
        }

        [TestMethod]
        public void Add10000Arrays()
        {
            // Arrange
            var dbPath = "test10000load.db";
            
            using (var repo = new ArrayRepository(dbPath))
            {
                // Act
                for (int i = 0; i < 10000; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }

                // Assert
                var allArrays = repo.GetAllArrays().ToList();
                Assert.AreEqual(10000, allArrays.Count);
            }

            SafeDelete(dbPath);
        }

        [TestMethod]
        public void UnloadAndSort100Arrays()
        {
            // Arrange
            const int arrayCount = 100;
            var dbPath = "test100unload.db";
            long totalSortTime = 0;
            bool success = true;

            // 1. Подготовка тестовых данных
            using (var repo = new ArrayRepository(dbPath))
            {
                for (int i = 0; i < arrayCount; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }
            }

            // Act
            using (var repo = new ArrayRepository(dbPath))
            {
                Console.WriteLine("Выгрузка и сортировка 100 массивов");

                var stopwatch = Stopwatch.StartNew();

                // Выгрузка
                var allArrays = repo.GetAllArrays().ToList();
                foreach (var arrayData in allArrays)
                {
                    try
                    {
                        // Cортировка
                        LW3.TreeSort.Sort(arrayData.Array);
                    }
                    catch (Exception)
                    {
                        success = false;
                        break;
                    }
                }
                stopwatch.Stop();

                totalSortTime = stopwatch.ElapsedMilliseconds;
            }

            // Анализ результатов
            var averageTimePerArrayMs = (double)totalSortTime / arrayCount;

            Console.WriteLine($"Общее время сортировки: {totalSortTime} мс");
            Console.WriteLine($"Среднее время на массив: {averageTimePerArrayMs:F4} мс");

            // Assert
            Assert.IsTrue(success);

            SafeDelete(dbPath);
        }

        [TestMethod]
        public void UnloadAndSort1000Arrays()
        {
            // Arrange
            const int arrayCount = 1000;
            var dbPath = "test1000unload.db";
            long totalSortTime = 0;
            bool success = true;

            // 1. Подготовка тестовых данных
            using (var repo = new ArrayRepository(dbPath))
            {
                for (int i = 0; i < arrayCount; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }
            }

            // Act
            using (var repo = new ArrayRepository(dbPath))
            {
                Console.WriteLine("Выгрузка и сортировка 1000 массивов");

                var stopwatch = Stopwatch.StartNew();

                // Выгрузка
                var allArrays = repo.GetAllArrays().ToList();
                foreach (var arrayData in allArrays)
                {
                    try
                    {
                        // Cортировка
                        LW3.TreeSort.Sort(arrayData.Array);
                    }
                    catch (Exception)
                    {
                        success = false;
                        break;
                    }
                }
                stopwatch.Stop();

                totalSortTime = stopwatch.ElapsedMilliseconds;
            }

            // Анализ результатов
            var averageTimePerArrayMs = (double)totalSortTime / arrayCount;

            Console.WriteLine($"Общее время сортировки: {totalSortTime} мс");
            Console.WriteLine($"Среднее время на массив: {averageTimePerArrayMs:F4} мс");

            // Assert
            Assert.IsTrue(success);

            SafeDelete(dbPath);
        }

        [TestMethod]
        public void UnloadAndSort10000Arrays()
        {
            // Arrange
            const int arrayCount = 10000;
            var dbPath = "test10000unload.db";
            long totalSortTime = 0;
            bool success = true;

            // 1. Подготовка тестовых данных
            using (var repo = new ArrayRepository(dbPath))
            {
                for (int i = 0; i < arrayCount; i++)
                {
                    repo.AddArray(new ArrayData(
                        $"Array_{i}",
                        RandomUtils.GetRandomArray(50))
                    );
                }
            }

            // Act
            using (var repo = new ArrayRepository(dbPath))
            {
                Console.WriteLine("Выгрузка и сортировка 10000 массивов");

                var stopwatch = Stopwatch.StartNew();

                // Выгрузка
                var allArrays = repo.GetAllArrays().ToList();
                foreach (var arrayData in allArrays)
                {
                    try
                    {
                        // Cортировка
                        LW3.TreeSort.Sort(arrayData.Array);
                    }
                    catch (Exception)
                    {
                        success = false;
                        break;
                    }
                }
                stopwatch.Stop();

                totalSortTime = stopwatch.ElapsedMilliseconds;
            }

            // Анализ результатов
            var averageTimePerArrayMs = (double)totalSortTime / arrayCount;

            Console.WriteLine($"Общее время сортировки: {totalSortTime} мс");
            Console.WriteLine($"Среднее время на массив: {averageTimePerArrayMs:F4} мс");

            // Assert
            Assert.IsTrue(success);

            SafeDelete(dbPath);
        }



        public static void SafeDelete(string dbPath)
        {
            try
            {
                if (File.Exists(dbPath))
                    File.Delete(dbPath);
            }
            catch { }
        }
    }
}

