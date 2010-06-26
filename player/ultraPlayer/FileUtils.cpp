#include "FileUtils.h"

FileUtils* FileUtils::_instance = NULL;

FileUtils::FileUtils(void)
{
}

FileUtils::~FileUtils(void)
{
}

FileUtils* FileUtils::Instance()
{
	if (!_instance)
	{
		_instance = new FileUtils();
	}
	return _instance;
}

bool FileUtils::FileExists( string filename )
{
	wchar_t file[MAX_PATH];
	wsprintf(file, L"%s", filename.c_str());
	return (INVALID_FILE_ATTRIBUTES == GetFileAttributes(file));
}