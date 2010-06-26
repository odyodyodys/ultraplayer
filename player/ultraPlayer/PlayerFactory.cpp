#include "PlayerFactory.h"

PlayerFactory::PlayerFactory(void)
{
}

PlayerFactory::~PlayerFactory(void)
{
}

APlayer* PlayerFactory::CreatePlayer( PlayerType::Type playerType, HWND windowHandle, DisplayDevice* const displayDevice )
{
	APlayer* player = NULL;

	try
	{
		// choose type for the new instance
		switch (playerType)
		{
		case PlayerType::MultiVideo:
			player = new MultiVideoPlayer(new Vmr9DshowPlayerEnvironment(windowHandle, displayDevice));
			break;
		case PlayerType::SingleVideo:
			player = new SingleVideoPlayer(new Direct3dVmr9DshowPlayerEnvironment(windowHandle, displayDevice));
			break;
		case PlayerType::Audio:
			player = new AudioPlayer(new ComEnabledPlayerEnvironment(windowHandle));
			break;
		case PlayerType::Midi:
			player = new MidiPlayer(new ComEnabledPlayerEnvironment(windowHandle));
			break;
		default:
			// error
			throw InitializationFailedException("Unsupported player type", "PlayerFactory::SetPlayerType");
			break;
		}

		// initialize player
		player->Initialize();
	}
	catch (exception* e)
	{
		// clean up
		if (player)
		{
			delete player;
		}

		// TODO create a new exception to minimum the thrown exceptions from this method
		throw;
	}

	return player;
}