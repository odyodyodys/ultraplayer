#include "ComEnabledPlayerEnvironment.h"

ComEnabledPlayerEnvironment::ComEnabledPlayerEnvironment(HWND window):APlayerEnvironment(window)
{
}

ComEnabledPlayerEnvironment::~ComEnabledPlayerEnvironment(void)
{
}

bool ComEnabledPlayerEnvironment::Initialize()
{
	HRESULT hr = E_FAIL;
	bool success = false;
	try
	{
		hr = CoInitializeEx(NULL, COINIT_MULTITHREADED);

		success = true;

	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

bool ComEnabledPlayerEnvironment::Reset()
{
	return false;
}