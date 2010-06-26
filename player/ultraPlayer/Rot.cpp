#include "Rot.h"

Rot::Rot(void)
{
}

Rot::~Rot(void)
{
}

HRESULT Rot::Add( IUnknown *graph, DWORD& rotId)
{
	if (graph == NULL)
	{
		return E_INVALIDARG;
	}

	IMoniker * moniker;
	IRunningObjectTable *rot;
	if (FAILED(GetRunningObjectTable(0, &rot))) 
	{
		return E_FAIL;
	}
	WCHAR name[256];
	wsprintfW(name, L"FilterGraph %08x pid %08x", (DWORD_PTR)graph, GetCurrentProcessId());
	HRESULT hr = CreateItemMoniker(L"!", name, &moniker);
	if (SUCCEEDED(hr)) 
	{
		hr = rot->Register(0, graph, moniker, &rotId);
		moniker->Release();
	}
	rot->Release();

	return hr;
}

void Rot::Remove( DWORD rotId )
{
	if (rotId) 
	{
		IRunningObjectTable *rot;
		if (SUCCEEDED(GetRunningObjectTable(0, &rot)))
		{
			rot->Revoke(rotId);
			rot->Release();
		}
	}
}