#include "ADShowPlayer.h"

ADShowPlayer::ADShowPlayer(PlayerType::Type playerType, DshowPlayerEnvironment* environment):APlayer(playerType, environment)
{
	_graphManager = NULL;
}

ADShowPlayer::~ADShowPlayer(void)
{
	if (_graphManager)
	{
		delete _graphManager;
	}
}

PlaybackResultType::Type ADShowPlayer::Play( list<pair<int, string>> files )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (!_graphManager)
		{
			throw PlaybackException("_graphManager not initialized", "ADShowPlayer::Play");
		}

		// do not allow logo drawing on window
		SendNotifyMessage(_environment->Window(), PlaybackResources::Instance()->SuppressLogoDrawingEventCode(), NULL, NULL);

		// stop any media file currently playing
		_graphManager->Stop();

		// build new graph
		_graphManager->Initialize(files, (DshowPlayerEnvironment*)_environment );
		_graphManager->Render();
		_graphManager->Run();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type ADShowPlayer::Pause()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (!_graphManager)
		{
			throw PlaybackException("_graphManager not initialized", "ADShowPlayer::Pause");
		}

		_graphManager->Pause();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type ADShowPlayer::Resume()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (!_graphManager)
		{
			throw PlaybackException("_graphManager not initialized", "ADShowPlayer::Resume");
		}

		// continue the graph
		_graphManager->Run();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type ADShowPlayer::Stop()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (!_graphManager)
		{
			throw PlaybackException("_graphManager not initialized", "ADShowPlayer::Stop");
		}

		// continue the graph
		_graphManager->Stop();

		// allow logo drawing on window
		SendNotifyMessage(_environment->Window(), PlaybackResources::Instance()->AllowLogoDrawingEventCode(), NULL, NULL);

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type ADShowPlayer::SetVolume( UINT volume )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		_graphManager->SetVolume(volume);

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type ADShowPlayer::Seek( UINT milliseconds )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (_graphManager->SeekTo(milliseconds))
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

PlaybackResultType::Type ADShowPlayer::SetRate( float rate )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		HRESULT hr = _graphManager->SetRate(rate);
		if (SUCCEEDED(hr))
		{
			result = PlaybackResultType::Success;
		}	
		else
		{
			result = PlaybackResultType::Failure;
		}
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;		
	}
	return result;
}
