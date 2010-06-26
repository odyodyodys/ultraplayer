#include "PlayerInstructor.h"

PlayerInstructor::PlayerInstructor()
{
	_player = NULL;
}

PlayerInstructor::~PlayerInstructor(void)
{
}

AResponse* PlayerInstructor::HandleRequest( ARequest* request )
{
	AResponse* response = NULL;

	try
	{
        if (!_player)
        {
            throw PlaybackException("_player = null", "PlayerInstructor::HandleRequest");
        }

		switch (request->MessageType())
		{
		case MessageType::Play :
			response = HandlePlayRequest((PlayRequest*)request);
			break;
		case MessageType::Pause :
			response = HandlePauseRequest((PauseRequest*)request);
			break;
		case MessageType::Resume:
			response = HandleResumeRequest((ResumeRequest*)request);
			break;
		case MessageType::Seek :
			response = HandleSeekRequest((SeekRequest*)request);
			break;
		case MessageType::Stop :
			response = HandleStopRequest((StopRequest*)request);
			break;
		case MessageType::Volume :
			response = HandleVolumeRequest((VolumeRequest*)request);
			break;
		case MessageType::SetImage :
			response = HandleSetImageRequest((SetImageRequest*)request);
			break;
		case MessageType::SetText :
			response = HandleSetTextRequest((SetTextRequest*)request);
			break;
		case MessageType::RemoveAddon:
			response = HandleRemoveAddonRequest((RemoveAddonRequest*)request);
			break;
		case MessageType::VideoLayout :
			response = HandleVideoLayoutRequest((VideoLayoutRequest*)request);
			break;
		case MessageType::SoundFx:
			response = HandleSoundFxRequest((SoundFxRequest*)request);
			break;
		case MessageType::Sound3d:
			response = HandleSound3dRequest((Sound3dRequest*)request);
			break;
		case MessageType::MidiProperties:
			response = HandleMidiPropertiesRequest((MidiPropertiesRequest*)request);
			break;
		case MessageType::MidiOutputPortInfo:
			response = HandleMidiOutputPortInfoRequest((MidiOutputPortInfoRequest*)request);
			break;
		case MessageType::SetMidiOutputPort:
			response = HandleSetMidiOutputPortRequest((SetMidiOutputPortRequest*)request);
			break;
		case MessageType::SetDls:
			response = HandleSetDlsRequest((SetDlsRequest*)request);
			break;
		case MessageType::SetFrequency:
			response = HandleSetFrequencyRequest((SetFrequencyRequest*)request);
			break;
		case MessageType::SetRate:
			response = HandleSetRateRequest((SetRateRequest*)request);
			break;
		default:
			// TODO throw handler exception, cannot handle this type of message
			break;
		}
	}
	catch (exception& e)
	{
		// TODO log error

		if (response != NULL)
		{
			delete response;
		}

		response = new GeneralFailureResponse();
	}

	return response;
}

AResponse* PlayerInstructor::HandlePlayRequest( PlayRequest* request )
{
	PlayResponse* response = NULL;

	try
	{
		response = new PlayResponse();

		
		if (_player->Play(request->Files()) == PlaybackResultType::Success)
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

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandlePauseRequest( PauseRequest* request )
{
	PauseResponse* response = new PauseResponse();

	try
	{
		if(_player->Pause() == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleResumeRequest( ResumeRequest* request )
{
	ResumeResponse* response = new ResumeResponse();

	try
	{
		if(_player->Resume() == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleStopRequest( StopRequest* request )
{
	StopResponse* response = new StopResponse();

	try
	{
		if(_player->Stop() == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSeekRequest( SeekRequest* request )
{
	SeekResponse* response = new SeekResponse();

	try
	{
		if(_player->Seek(request->Milliseconds()) == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetImageRequest( SetImageRequest* request )
{
	// Note: Only called by SingleVideoPlayer. Is casted to this type for that reason

	SetImageResponse* response = new SetImageResponse();

	try
	{
		// check player type
		if (_player->PlayerType() != PlayerType::SingleVideo)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSetImageRequest");
		}

		UINT addonId = request->ObjectProperties()->Id();
		VisibleLayout* layout = request->ObjectProperties()->Layout();
		string filename = request->Filename();
		
		if(((SingleVideoPlayer*)_player)->SetImage(addonId, layout, filename ) == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetTextRequest( SetTextRequest* request )
{
	// Note: Only called by SingleVideoPlayer. Is casted to this type for that reason

	SetTextResponse* response = new SetTextResponse();

	try
	{
		if (_player->PlayerType() != PlayerType::SingleVideo)
		{
			throw PlaybackException("Player cannot handle this message type","PlayerInstructor::HandleSetTextRequest");
		}

		UINT addonId = request->ObjectProperties()->Id();
		VisibleLayout* layout = request->ObjectProperties()->Layout();
		string text = request->Text();
		if(((SingleVideoPlayer*)_player)->SetText(addonId, layout, text) == PlaybackResultType::Success)
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
		// TODO log error

		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleVideoLayoutRequest( VideoLayoutRequest* request )
{
	// Note: This is only called when the player is multiVideoPlayer
	// Calls to player should be casted to MultiVideoPlayer
	
	VideoLayoutResponse* response = new VideoLayoutResponse();

	try
	{
		if (_player->PlayerType() != PlayerType::MultiVideo)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleVideoLayoutRequest");
		}

		list<VisibleLayout*> layouts = request->Layouts();

		if (layouts.size() == 0)
		{
			// TODO throw HandlerException
		}

		list<VisibleLayout*>::iterator iterator;
		int index = 0;

		for (iterator = layouts.begin(); iterator != layouts.end(); iterator++)
		{
			if(((MultiVideoPlayer*)_player)->VideoLayout(index++, *iterator) == PlaybackResultType::Success)
			{
				response->ResponseType(ResponseType::Success);
			}
			else
			{
				response->ResponseType(ResponseType::Failure);
				break;
			}

		}
	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;

}

AResponse* PlayerInstructor::HandleVolumeRequest( VolumeRequest* request )
{
	VolumeResponse* response = new VolumeResponse();

	try
	{
		if (_player->SetVolume(request->Volume()) == PlaybackResultType::Success)
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

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleRemoveAddonRequest( RemoveAddonRequest* request )
{
	RemoveAddonResponse* response = new RemoveAddonResponse();

	try
	{
		if (_player->PlayerType() != PlayerType::SingleVideo)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleRemoveAddonRequest");
		}

		if (((SingleVideoPlayer*)_player)->RemoveAddon(request->AddonId()) == PlaybackResultType::Success)
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

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSoundFxRequest( SoundFxRequest* request )
{
	SoundFxResponse* response = new SoundFxResponse();

	try
	{
		if (_player->PlayerType() != PlayerType::Audio)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSoundFxRequest");
		}

		bool errorOccured = false;
		list<ASoundFx*> effects = request->SoundFxs();
		for (list<ASoundFx*>::iterator it = effects.begin(); it != effects.end(); it++)
		{
			if (((AudioPlayer*)_player)->SetEffect(*it) != PlaybackResultType::Success)
			{
				errorOccured = true;
				break;
			}
		}

		if (!errorOccured)
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

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSound3dRequest( Sound3dRequest* request )
{
	Sound3dResponse* response = new Sound3dResponse();

	try
	{
		if (_player->PlayerType() != PlayerType::Audio && _player->PlayerType() != PlayerType::Midi)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSound3dRequest");
		}

		if (_player->PlayerType() == PlayerType::Audio )
		{
			if (((AudioPlayer*)_player)->Set3d(request->DoplerFactor(), request->RolloffFactor(), request->MinDistance(), request->MaxDistance(), request->SourceX(), request->SourceY(), request->SourceZ()) == PlaybackResultType::Success)
			{
				response->ResponseType(ResponseType::Success);
			}
			else
			{
				response->ResponseType(ResponseType::Failure);
			}
		}
		else if (_player->PlayerType() == PlayerType::Midi)
		{
			if (((MidiPlayer*)_player)->Set3dPosition(request->SourceX(), request->SourceY(), request->SourceZ()) == PlaybackResultType::Success)
			{
				response->ResponseType(ResponseType::Success);
			}
			else
			{
				response->ResponseType(ResponseType::Failure);
			}
		}


	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}

	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleMidiPropertiesRequest( MidiPropertiesRequest* request )
{
	SetMidiOutputPortResponse* response = new SetMidiOutputPortResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::Midi)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleMidiPropertiesRequest");
		}

		if (((MidiPlayer*)_player)->SetMidiProperties(request->EnableReverb(), request->EnableChorus(), request->Tempo()) == PlaybackResultType::Success)
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
	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleMidiOutputPortInfoRequest( MidiOutputPortInfoRequest* request )
{
	MidiOutputPortInfoResponse* response = new MidiOutputPortInfoResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::Midi)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleMidiOutputPortInfoRequest");
		}

		response->MidiOutputPorts(((MidiPlayer*)_player)->GetMidiOutputPortList());
		
		// can never be failure.. Even if it fails to populate midiOuputPorts, it will be a success with an empty list
		response->ResponseType(ResponseType::Success);

	}
	catch (exception& e)
	{
		response->ResponseType(ResponseType::BadResponse);
	}
	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetMidiOutputPortRequest( SetMidiOutputPortRequest* request )
{
	SetMidiOutputPortResponse* response = new SetMidiOutputPortResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::Midi)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSetMidiOutputPortRequest");
		}

		if (((MidiPlayer*)_player)->SetMidiOutputPort(request->PortName()) == PlaybackResultType::Success)
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
	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetDlsRequest( SetDlsRequest* request )
{
	SetDlsResponse* response = new SetDlsResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::Midi)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSetDlsRequest");
		}

		if (((MidiPlayer*)_player)->SetDlsFile(request->DlsFile()) == PlaybackResultType::Success)
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
	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetFrequencyRequest( SetFrequencyRequest* request )
{
	SetDlsResponse* response = new SetDlsResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::Audio)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSetFrequencyRequest");
		}

		if (((AudioPlayer*)_player)->SetFrequency(request->Frequency()) == PlaybackResultType::Success)
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
	return (AResponse*)response;
}

AResponse* PlayerInstructor::HandleSetRateRequest( SetRateRequest* request )
{
	SetRateResponse* response = new SetRateResponse();
	try
	{
		if (_player->PlayerType() != PlayerType::SingleVideo && _player->PlayerType() != PlayerType::MultiVideo)
		{
			throw PlaybackException("Player does not support this message type","PlayerInstructor::HandleSetRateRequest");
		}

		if (((ADShowPlayer*)_player)->SetRate(request->Rate()) == PlaybackResultType::Success)
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
	return (AResponse*)response;
}

void PlayerInstructor::SetPlayer( APlayer* player )
{
    try
    {
    	if (player)
    	{
            _player = player;
    	}
    }
    catch (exception& e)
    {
    }
}
