#include "UltraPlayer.h"

UltraPlayer* UltraPlayer::_instance = 0;

UltraPlayer::UltraPlayer()
{
    _player = NULL;
    _server = NULL;
    _windowManager = NULL;
    _playerInstructor = NULL;

}
UltraPlayer::~UltraPlayer(void)
{
	if (_player)
	{
		delete _player;
	}

	if (_windowManager)
	{
		delete _windowManager;
	}

	if (_server)
	{
		delete _server;
	}

	if (_playerInstructor)
	{
		delete _playerInstructor;
	}

}
UltraPlayer* UltraPlayer::Instance()
{
	if (_instance == NULL)
	{
		_instance = new UltraPlayer();
		if (_instance == NULL)
		{
			// error
		}
	}
	return _instance;
}

void UltraPlayer::Initialize( )
{
	try
	{
		_windowManager = new WindowManager(_hinstance);

		// create window
		// Note. Even if no window is needed for video frames, it is needed to catch direct show events
		_windowManager->CreateVideoWindow();

        _playerInstructor = new PlayerInstructor();

        // no default player
        //SetUpPlayer();
	}
	catch (exception& e)
	{
		throw InitializationFailedException(e.what(), "UltraPlayer::CreatePlayer");
	}
}

void UltraPlayer::Start( USHORT port )
{
	try
	{

		// configure and start the server
		_server = new TCPServer(port);

		// Configure RequestHandlerSelector
		RequestHandlerSelector* selector = RequestHandlerSelector::Instance();
		selector->RegisterListener(MessageType::SetImage, _playerInstructor);
		selector->RegisterListener(MessageType::SetText, _playerInstructor);
		selector->RegisterListener(MessageType::RemoveAddon, _playerInstructor);
		selector->RegisterListener(MessageType::Play, _playerInstructor);
		selector->RegisterListener(MessageType::Pause, _playerInstructor);
		selector->RegisterListener(MessageType::Resume, _playerInstructor);
		selector->RegisterListener(MessageType::Stop, _playerInstructor);
		selector->RegisterListener(MessageType::Seek, _playerInstructor);
		selector->RegisterListener(MessageType::Volume, _playerInstructor);
		selector->RegisterListener(MessageType::VideoLayout, _playerInstructor);
		selector->RegisterListener(MessageType::Termination, this );
		selector->RegisterListener(MessageType::WindowLayout, this);
		selector->RegisterListener(MessageType::DisplayDevicesInfo, this);
		selector->RegisterListener(MessageType::SoundFx, _playerInstructor);
		selector->RegisterListener(MessageType::Sound3d, _playerInstructor);
		selector->RegisterListener(MessageType::MidiProperties, _playerInstructor);
		selector->RegisterListener(MessageType::MidiOutputPortInfo, _playerInstructor);
		selector->RegisterListener(MessageType::SetMidiOutputPort, _playerInstructor);
		selector->RegisterListener(MessageType::SetDls, _playerInstructor);
		selector->RegisterListener(MessageType::SetFrequency, _playerInstructor);
		selector->RegisterListener(MessageType::SetRate, _playerInstructor);
        selector->RegisterListener(MessageType::SetPlayerType, this);

		// configure PlaybackEventNotifier
		PlaybackEventNotifier* notifier = PlaybackEventNotifier::Instance();
		notifier->RegisterEvent(PlaybackResources::Instance()->DshowEventCode());
		notifier->RegisterEvent(WM_SIZE);
		notifier->RegisterEvent(PlaybackResources::Instance()->DisplayChangedEventCode());

		// set window to message pipe
		MessagePipe::Instance()->SetWindow(_windowManager->WindowHandle());

		// set the listener and start the server
		_server->Start();
	}
	catch (exception& e)
	{
		throw InitializationFailedException(e.what(), "UltraPlayer::Start");
	}

}

void UltraPlayer::Stop()
{
	// This might take some time because server tries to kill its listener thread
	_player->Stop();

	_server->Stop();	
}

AResponse* UltraPlayer::HandleRequest( ARequest* request )
{
	AResponse* response = NULL;

	try
	{
		switch (request->MessageType())
		{
		case MessageType::WindowLayout:
			response = HandleWindowLayoutRequest((WindowLayoutRequest*)request);
			break;
		case MessageType::Termination:
			response = HandleTerminationRequest((TerminationRequest*)request);
			break;
		case MessageType::DisplayDevicesInfo:
			response = HandleDisplayDeviceInfoRequest((DisplayDevicesInfoRequest*)request);
			break;
        case MessageType::SetPlayerType:
            response = HandleSetPlayerTypeRequest((SetPlayerTypeRequest*)request);
            break;
		default:
			// TODO throw handler exception. This handler cannot handle this type of request.
			break;
		}
	}
	catch (exception& e)
	{
		if (response)
		{
			delete response;
		}
		response = (AResponse*)(new GeneralFailureResponse());
	}

	return response;
}

void UltraPlayer::HInstance( HINSTANCE hinstance )
{
	_hinstance = hinstance;
}

AResponse* UltraPlayer::HandleWindowLayoutRequest( WindowLayoutRequest* request )
{
	AResponse* response = new WindowLayoutResponse();
	bool success = true;
	try
	{
		bool switchedMonitor = request->MonitorNumber() != _windowManager->CurrentDevice()->MonitorNumber();

		success &= _windowManager->SetWindowLayout(request->MonitorNumber(), request->GetLayout());
		
		if (switchedMonitor)
		{
			success &= _player->OnMonitorChanged(_windowManager->CurrentDevice());
		}


		if (success)
		{
			response->ResponseType(ResponseType::Success);
		}
		else
		{
			response->ResponseType(ResponseType::Failure);
		}
	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}

	return response;
}

AResponse* UltraPlayer::HandleDisplayDeviceInfoRequest( DisplayDevicesInfoRequest* request )
{
	DisplayDevicesInfoResponse* response = new DisplayDevicesInfoResponse();
	try
	{
		
		list<DisplayDevice*> devices = _windowManager->GetDisplayDevices();

		if (!devices.empty())
		{
			response->Devices(devices);
			response->ResponseType(ResponseType::Success);
		}
		else
		{
			response->ResponseType(ResponseType::Failure);
		}
	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}

	return response;
}

AResponse* UltraPlayer::HandleTerminationRequest( TerminationRequest* request )
{
	TerminationResponse* response = new TerminationResponse();
	try
	{
		_server->NotifyStop();

		PostQuitMessage(0);
		
		response->ResponseType(ResponseType::Success);
	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}

	return response;
}

AResponse* UltraPlayer::HandleSetPlayerTypeRequest( SetPlayerTypeRequest* request )
{
    SetPlayerTypeResponse* response = new SetPlayerTypeResponse();
    try
    {
        SetUpPlayer(request->PlayerType());
        response->ResponseType(ResponseType::Success);
    }
    catch (exception& e)
    {
        response->ResponseType(ResponseType::BadResponse);
    }

    return response;
}

void UltraPlayer::SetUpPlayer( PlayerType::Type playerType )
{
    try
    {
	    // clean up previous player, if any
	    if (_player)
	    {
	        _player->Stop();
	        delete _player;
	    }
	
	    // show window if needed
	    if (playerType == PlayerType::MultiVideo || playerType == PlayerType::SingleVideo)
	    {
	        _windowManager->SetWindowVisibility(true);
	    }
	    else
	    {
	        _windowManager->SetWindowVisibility(false);
	    }
	
	    // create player
	    _player = PlayerFactory::CreatePlayer(playerType, _windowManager->WindowHandle(), _windowManager->CurrentDevice());
	    if (!_player)
	    {
	        throw InitializationFailedException("No Player created", "UltraPlayer::SetUpPlayer");
	    }
	
	    // Initialize playerInstructor
	    _playerInstructor->SetPlayer(_player);
    }
    catch (exception& e)
    {
        throw InitializationFailedException(e.what(), "UltraPlayer::SetUpPlayer");
    }
}
