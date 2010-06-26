#pragma once

#pragma region headers
#include "ApplicationHeaders.h"

#pragma endregion

class Rot
{
#pragma region Constructors/Destructors
private:
	Rot();
	virtual ~Rot();
#pragma endregion

#pragma region Methods
public:
	// Description: Adds a graph to the ROT
	static HRESULT Add(IUnknown *pUnkGraph, DWORD& rotId);

	// Description: Removes a graph from the rot
	static void Remove(DWORD rotId);
#pragma endregion

};