#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class FileUtils
{
#pragma region Fields
private:
	static FileUtils* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	FileUtils();
public:
	virtual ~FileUtils();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static FileUtils* Instance();

	// Description: Returns true if file exists
	bool FileExists(string filename);
#pragma endregion

};