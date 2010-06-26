#include "MultiVideoPlayer.h"

MultiVideoPlayer::MultiVideoPlayer(Vmr9DshowPlayerEnvironment* environment):ADShowPlayer(PlayerType::MultiVideo, (DshowPlayerEnvironment*) environment)
{

	_graphManager = new MultiVideoGraphManager();

	// register to dshow event notifier so it can get notified on dshow events
	PlaybackEventNotifier::Instance()->RegisterHandler(_graphManager);
}

MultiVideoPlayer::~MultiVideoPlayer(void)
{
  
}

PlaybackResultType::Type MultiVideoPlayer::VideoLayout( int videoId, VisibleLayout* layout )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		// Set layout
		RECT videoLayout;
		videoLayout.left = layout->X();
		videoLayout.top = layout->Y();
		videoLayout.right = layout->X() + layout->Width();
		videoLayout.bottom = layout->Y() + layout->Height();
		((MultiVideoGraphManager*)_graphManager)->SetVideoLayout(videoId, videoLayout);

		// Set alpha
		((MultiVideoGraphManager*)_graphManager)->SetVideoAlpha(videoId, layout->Alpha());
	
		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;		
	}

	return result;
}

bool MultiVideoPlayer::Initialize()
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

bool MultiVideoPlayer::OnMonitorChanged(DisplayDevice* newDevice)
{
	// does not care
	return true;
}