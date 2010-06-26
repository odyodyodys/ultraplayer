#include "DshowFilterUtils.h"

DshowFilterUtils::DshowFilterUtils(void)
{
}

DshowFilterUtils::~DshowFilterUtils(void)
{
}

bool DshowFilterUtils::RemoveFilterChain(IFilterGraph* graph, IBaseFilter* filter, IBaseFilter* stopFilter )
{
	HRESULT hr = E_FAIL;

	IBaseFilter* filterFound = NULL;

	hr = GetNextFilter(filter, PINDIR_OUTPUT, &filterFound);
	if (SUCCEEDED(hr) && filterFound != stopFilter) 
	{
		RemoveFilterChain(graph, filterFound, stopFilter);
		filterFound->Release();
	}

	graph->RemoveFilter(filter);

	return TRUE;
}

HRESULT DshowFilterUtils::GetNextFilter( IBaseFilter *filter, PIN_DIRECTION direction, IBaseFilter **next )
{
	if (!filter || !next)
	{
		return E_POINTER;
	}

	IEnumPins *pinEnumerator = 0;
	IPin *pin = 0;
	
	HRESULT hr = filter->EnumPins(&pinEnumerator);
	if (FAILED(hr))
	{
		return hr;
	}

	while (S_OK == pinEnumerator->Next(1, &pin, 0)) 
	{
		// See if this pin matches the specified direction.
		PIN_DIRECTION thisPinDirection;
		hr = pin->QueryDirection(&thisPinDirection);
		if (FAILED(hr)) 
		{
			// Something strange happened.
			hr = E_UNEXPECTED;
			pin->Release();
			break;
		}
		if (thisPinDirection == direction)
		{
			// Check if the pin is connected to another pin.
			IPin *nextPin = 0;
			hr = pin->ConnectedTo(&nextPin);
			if (SUCCEEDED(hr))
			{
				// Get the filter that owns that pin.
				PIN_INFO pinInfo;
				hr = nextPin->QueryPinInfo(&pinInfo);
				nextPin->Release();
				pin->Release();
				pinEnumerator->Release();
				if (FAILED(hr) || (pinInfo.pFilter == NULL))
				{
					// Something strange happened.
					return E_UNEXPECTED;
				}
				// This is the filter we're looking for.
				*next = pinInfo.pFilter; // Client must release.
				return S_OK;
			}
		}
		pin->Release();
	}
	pinEnumerator->Release();
	// Did not find a matching filter.
	return E_FAIL;
}