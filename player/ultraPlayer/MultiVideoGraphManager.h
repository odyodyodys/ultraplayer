#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "AGraphManager.h"
	#include "PlaybackResources.h"
	#include "DshowFilterUtils.h"
	#include "PlaybackEventNotifier.h"
	#include "IPlaybackEventHandler.h"
	#include "DshowPlayerEnvironment.h"

	#include "NotImplementedException.h"
#pragma endregion

class MultiVideoGraphManager : public AGraphManager
{
#pragma region Fields
private:
	DWORD _numberOfStreams;

	// VMR9 interfaces
	CComPtr<IVMRFilterConfig9>		_vmrFilterConfig;
	CComPtr<IVMRMixerControl9>		_vmrMixerControl;
	CComPtr<IVMRMonitorConfig9>		_vmrMonitorConfig;
	CComPtr<IVMRWindowlessControl9> _vmrWindowlessControl;
#pragma endregion

#pragma region Constructors/Destructor
public:
    MultiVideoGraphManager(void);
    ~MultiVideoGraphManager(void);
#pragma endregion

#pragma region AGraphManager members
protected:
	virtual HRESULT CreateInstances();
	virtual HRESULT AddFiltersToGraph(list<pair<int, string>> files);
	virtual HRESULT ConfigureFilters(DshowPlayerEnvironment* environment);

	virtual void CleanUp();
public:
	virtual void HandleEvent(DWORD eventCode, HWND window);
#pragma endregion

#pragma region Methods
private:
	// Description: Builds the vmr9 renderer
	// Steps:
	// 1. Create vmr9
	// 2. add it to graph
	// 3. set properties
	HRESULT BuildVmr(HWND window);

	// Description: Stretches vmr9 to window
	HRESULT StretchVmrToVideoWindow(HWND window);

	// Description: Returns true if layer is valid
	bool IsLayerValid(int layerIndex);

	// Description: Creates a normalized vmr9 rect to fit composition window
	VMR9NormalizedRect NormalizeRect(LPRECT layoutRect);

	// Description: Gets the rect of the biggest video playing
	bool GetVideoRect(LPRECT rect);
public:
	// Description: Sets a layout for a video. Percentage values
	HRESULT SetVideoLayout(int index, RECT layout);

	// Description: Sets alpha channel for video base on its index
	HRESULT SetVideoAlpha(int index, int alpha);
#pragma endregion
};
