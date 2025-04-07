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
            var dbPath = "test100";
            try
            {
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
            }
            finally
            {
                SafeDelete(dbPath);
            }
        }

        [TestMethod]
        public void Add1000Arrays()
        {
            // Arrange
            var dbPath = "test1000";
            try
            {
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
            }
            finally
            {
                SafeDelete(dbPath);
            }
        }

        [TestMethod]
        public void Add10000Arrays()
        {
            // Arrange
            var dbPath = "test10000";
            try
            {
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
            }
            finally
            {
                SafeDelete(dbPath);
            }
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

