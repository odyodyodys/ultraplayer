#pragma once

#pragma region headers
#include "ApplicationHeaders.h"

#include "PlaybackException.h"
#pragma endregion

class DshowFilterUtils
{
#pragma region Constructors/Destructors
private:
	DshowFilterUtils();
	virtual ~DshowFilterUtils();
#pragma endregion

#pragma region Methods
private:
	// Description: Gets the filter connected to another one. Note: caller must release next
	static HRESULT GetNextFilter( IBaseFilter *filter, PIN_DIRECTION direction, IBaseFilter **next );
public:
	// Description: Removes a chan of filters from a graph.
	static bool RemoveFilterChain(IFilterGraph* graph, IBaseFilter* filter, IBaseFilter* stopFilter);
#pragma endregion

};