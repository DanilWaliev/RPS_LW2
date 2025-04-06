using namespace std;

#include "FileUtils.h"

// проверяет файл fileName на readonly
// true - файл является readonly
// false - файл не является readonly
bool IsReadOnly(string fileName)
{
    filesystem::file_status status = filesystem::status(fileName);

    if (filesystem::is_regular_file(status)) {
        return (status.permissions() & filesystem::perms::owner_write) != filesystem::perms::owner_write;
    }

    return false;
}

// проверяет является ли указанное имя файла зарезервированным
bool IsFileNameReserved(string filename)
{
    filesystem::path pathToCheck = filename;

    // зарезервированные имена файлов
    vector<string> reserved = { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4",
                                          "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2",
                                          "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

    // проверяем, содержится ли имя файла в списке зарезервированных имен
    for (const auto& reservedName : reserved)
    {
        if (pathToCheck.filename() == reservedName)
        {
            return true;
        }
    }

    return false;
}