#include "SingleVideoPlayer.h"

SingleVideoPlayer::SingleVideoPlayer(Direct3dVmr9DshowPlayerEnvironment* environment):ADShowPlayer(PlayerType::SingleVideo, (DshowPlayerEnvironment*) environment)
{
	_graphManager = new SingleVideoGraphManager();

	// register to dshow event notifier so it can get notified on dshow events
	PlaybackEventNotifier::Instance()->RegisterHandler(_graphManager);
}

SingleVideoPlayer::~SingleVideoPlayer(void)
{
}

PlaybackResultType::Type SingleVideoPlayer::SetImage(UINT addonId, VisibleLayout* layout, string filename)
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	
	try
	{
		if (((SingleVideoGraphManager*)_graphManager)->SetImage(addonId, layout, filename, (Direct3dVmr9DshowPlayerEnvironment*)_environment));
		{
			result = PlaybackResultType::Success;
		}
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type SingleVideoPlayer::SetText(UINT addonId, VisibleLayout* layout, string text)
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (((SingleVideoGraphManager*)_graphManager)->SetText(addonId, layout, text, (Direct3dVmr9DshowPlayerEnvironment*)_environment));
		{
			result = PlaybackResultType::Success;
		}
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

bool SingleVideoPlayer::Initialize()
{
	bool success = true;

	try
	{
		success &= _environment->Initialize();
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

PlaybackResultType::Type SingleVideoPlayer::RemoveAddon( UINT addonId )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (((SingleVideoGraphManager*)_graphManager)->RemoveAddon(addonId));
		{
			result = PlaybackResultType::Success;
		}
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

bool SingleVideoPlayer::OnMonitorChanged(DisplayDevice* newDevice)
{
	bool success = false;

	try
	{
		success &= ((Direct3dVmr9DshowPlayerEnvironment*)_environment)->SwitchToDevice(newDevice);
		HRESULT hr = ((SingleVideoGraphManager*)_graphManager)->OnDeviceChanged((Direct3dVmr9DshowPlayerEnvironment*)_environment);
		if (FAILED(hr))
		{
			success = false;
		}
		else
		{
			success &= true;
		}
		
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}