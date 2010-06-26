#include "AResponse.h"

AResponse::AResponse(MessageType::Type messageType):AMessage(messageType)
{
	
}

AResponse::~AResponse(void)
{
}

ResponseType::Type AResponse::ResponseType()
{
	return _responseType;
}

void AResponse::ResponseType( ResponseType::Type responseType )
{
	_responseType = responseType;
}
void AResponse::FromString( string data )
{
	throw NotImplementedException("","AResponse::FromString");
}

std::string AResponse::ToString()
{
	string response;
	try
	{
		// add response header
		switch (_messageType)
		{
		case MessageType::SetImage:
			response = CommunicationProtocol::Instance()->SetImageHeader();
			break;
		case MessageType::SetText :
			response = CommunicationProtocol::Instance()->SetTextHeader();
			break;
		case MessageType::Play :
			response = CommunicationProtocol::Instance()->PlayHeader();
			break;
		case MessageType::Stop :
			response = CommunicationProtocol::Instance()->StopHeader();
			break;
		case MessageType::Pause :
			response = CommunicationProtocol::Instance()->PauseHeader();
			break;
		case MessageType::Resume:
			response = CommunicationProtocol::Instance()->ResumeHeader();
			break;
		case MessageType::Seek :
			response = CommunicationProtocol::Instance()->SeekHeader();
			break;
		case MessageType::Volume :
			response = CommunicationProtocol::Instance()->VolumeHeader();
			break;
		case MessageType::Termination :
			response = CommunicationProtocol::Instance()->TerminationHeader();
			break;
		case MessageType::WindowLayout :
			response = CommunicationProtocol::Instance()->WindowLayoutHeader();
			break;
		case MessageType::VideoLayout :
			response = CommunicationProtocol::Instance()->VideoLayoutHeader();
			break;
		case MessageType::DisplayDevicesInfo:
			response = CommunicationProtocol::Instance()->DisplayDeviceHeader();
			break;
		case MessageType::SoundFx:
			response = CommunicationProtocol::Instance()->SoundFxHeader();
			break;
		case MessageType::Sound3d:
			response = CommunicationProtocol::Instance()->Sound3dHeader();
			break;
		case MessageType::MidiProperties:
			response = CommunicationProtocol::Instance()->MidiPropertiesHeader();
			break;
		case MessageType::MidiOutputPortInfo:
			response = CommunicationProtocol::Instance()->MidiOutputPortInfoHeader();
			break;
		case MessageType::SetMidiOutputPort:
			response = CommunicationProtocol::Instance()->SetMidiOutputPortHeader();
			break;
		case MessageType::SetDls:
			response = CommunicationProtocol::Instance()->SetDlsHeader();
			break;
		case MessageType::SetFrequency:
			response = CommunicationProtocol::Instance()->SetFrequencyHeader();
			break;
		case MessageType::SetRate:
			response = CommunicationProtocol::Instance()->SetRateHeader();
			break;
        case MessageType::SetPlayerType:
            response = CommunicationProtocol::Instance()->SetPlayerTypeHeader();
            break;
		default:
			throw CommunicationException("Unsupported response type","AResponse::ToString");		
			break;
		}

		// add response status
		switch (_responseType)
		{
		case ResponseType::Success:
			response += CommunicationProtocol::Instance()->ResponseSuccess();
			break;
		case ResponseType::Failure:
			response += CommunicationProtocol::Instance()->ResponseFailure();
			break;
		case ResponseType::BadResponse:
		default:
			response += CommunicationProtocol::Instance()->ResponseBad();
			break;
		}
	}
	catch (exception& e)
	{
		response = CommunicationProtocol::Instance()->ResponseBad();
	}
	
	return response;
}