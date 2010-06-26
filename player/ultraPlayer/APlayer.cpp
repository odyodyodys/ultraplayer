#include "APlayer.h"

APlayer::APlayer(PlayerType::Type playerType, APlayerEnvironment* environment)
{
	_playerType = playerType;
	_environment = environment;
}

APlayer::~APlayer(void)
{
	if (_environment)
	{
		delete _environment;
	}
}

PlayerType::Type APlayer::PlayerType()
{
	return _playerType;
}