using namespace std;

#include "FileUtils.h"

// ��������� ���� fileName �� readonly
// true - ���� �������� readonly
// false - ���� �� �������� readonly
bool IsReadOnly(string fileName)
{
    filesystem::file_status status = filesystem::status(fileName);

    if (filesystem::is_regular_file(status)) {
        return (status.permissions() & filesystem::perms::owner_write) != filesystem::perms::owner_write;
    }

    return false;
}

// ��������� �������� �� ��������� ��� ����� �����������������
bool IsFileNameReserved(string filename)
{
    filesystem::path pathToCheck = filename;

    // ����������������� ����� ������
    vector<string> reserved = { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4",
                                          "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2",
                                          "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };

    // ���������, ���������� �� ��� ����� � ������ ����������������� ����
    for (const auto& reservedName : reserved)
    {
        if (pathToCheck.filename() == reservedName)
        {
            return true;
        }
    }

    return false;
}