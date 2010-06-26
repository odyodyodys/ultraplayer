#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "AGraphManager.h"
	#include "PlaybackResources.h"
	#include "PlaybackEventNotifier.h"
	#include "DshowPlayerEnvironment.h"
	#include "Direct3dVmr9DshowPlayerEnvironment.h"
	#include "AllocatorPresenter.h"
	#include "AddonManager.h"
	#include "ImageD3dVisibleAddon.h"
	#include "TextD3dVisibleAddon.h"
	#include "VisibleLayout.h"

	#include "PlaybackException.h"
	#include "NotImplementedException.h"
#pragma endregion

class SingleVideoGraphManager: public AGraphManager
{
#pragma region Fields
	DWORD _numberOfStreams;

	// VMR9 interfaces
	CComPtr<IVMRFilterConfig9>	_vmrFilterConfig;
	CComPtr<AllocatorPresenter>	_allocator;

	AddonManager<AD3dVisibleAddon>* _addonManager;
#pragma endregion

#pragma region Constructors/Destructors
public:
	SingleVideoGraphManager();
	virtual ~SingleVideoGraphManager();
#pragma endregion

#pragma region AGraphManager members
protected:
	virtual HRESULT CreateInstances();
	virtual HRESULT AddFiltersToGraph(list<pair<int, string>> files);
	virtual HRESULT ConfigureFilters(DshowPlayerEnvironment* const environment);
	virtual void CleanUp();
public:
	virtual void HandleEvent(DWORD eventCode, HWND window);
#pragma endregion

#pragma region Methods
private:
	// Description: Attaches allocator presenter to graph
	HRESULT SetAllocatorPresenter(Direct3dVmr9DshowPlayerEnvironment* environment);

	// Description: Builds the vmr9, sets the allocator presenter
	// sets properties and registers AP
	HRESULT BuildVmr(Direct3dVmr9DshowPlayerEnvironment* environment);
public:
	// Description: Sets an image to be displayed on top of video. An addon is created
	bool SetImage(UINT addonId, VisibleLayout* layout, string filename, Direct3dVmr9DshowPlayerEnvironment* environment);

	// Description: Sets text to be displayed on top of video. An addon is created
	bool SetText(UINT addonId, VisibleLayout* layout, string text, Direct3dVmr9DshowPlayerEnvironment* environment);

	// Description: Removes an addon
	bool RemoveAddon(UINT addonId);

	// Description: Is called when 3d device changes
	HRESULT OnDeviceChanged(Direct3dVmr9DshowPlayerEnvironment* environment);
#pragma endregion
};