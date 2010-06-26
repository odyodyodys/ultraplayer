#include "PlaybackResources.h"

PlaybackResources* PlaybackResources::_instance = NULL;

PlaybackResources::PlaybackResources(void)
{
	_dshowEventCode = WM_USER + 1;
	_displayChangedEventCode = WM_USER + 2;
	_maxVmr9Sources = 16;
	_allowLogoDrawingEventCode = WM_USER + 4;
	_suppressLogoDrawingEventCode = WM_USER + 5;
}

PlaybackResources::~PlaybackResources(void)
{
}

PlaybackResources* PlaybackResources::Instance()
{
	if (!_instance)
	{
		_instance = new PlaybackResources();
	}

	return _instance;

}

DWORD PlaybackResources::DshowEventCode()
{
	return _dshowEventCode;
}

UINT PlaybackResources::MaxVmr9Sources()
{
	return _maxVmr9Sources;
}

DWORD PlaybackResources::DisplayChangedEventCode()
{
	return _displayChangedEventCode;
}

DWORD PlaybackResources::SuppressLogoDrawingEventCode()
{
	return _suppressLogoDrawingEventCode;
}

DWORD PlaybackResources::AllowLogoDrawingEventCode()
{
	return _allowLogoDrawingEventCode;
}