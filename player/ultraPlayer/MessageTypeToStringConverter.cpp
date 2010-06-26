#include "MessageTypeToStringConverter.h"

MessageTypeToStringConverter::MessageTypeToStringConverter(void)
{
}

MessageTypeToStringConverter::~MessageTypeToStringConverter(void)
{
}

std::string MessageTypeToStringConverter::Convert( MessageType::Type data )
{
	throw NotImplementedException("Cannot convert from MessageType::Type to string", "MessageTypeToStringConverter::Convert");
}

MessageType::Type MessageTypeToStringConverter::Convert( string data )
{
	MessageType::Type messageType;

	try
	{
		// convert to request type
		if (data == CommunicationProtocol::Instance()->SetImageHeader())
		{
			messageType = MessageType::SetImage;
		}
		else if (data == CommunicationProtocol::Instance()->SetTextHeader())
		{
			messageType = MessageType::SetText;
		}
		else if (data == CommunicationProtocol::Instance()->RemoveAddonHeader())
		{
			messageType = MessageType::RemoveAddon;
		}
		else if (data == CommunicationProtocol::Instance()->PlayHeader())
		{
			messageType = MessageType::Play;
		}
		else if (data == CommunicationProtocol::Instance()->StopHeader())
		{
			messageType = MessageType::Stop;
		}
		else if (data == CommunicationProtocol::Instance()->PauseHeader())
		{
			messageType = MessageType::Pause;
		}
		else if (data == CommunicationProtocol::Instance()->ResumeHeader())
		{
			messageType = MessageType::Resume;
		}
		else if (data == CommunicationProtocol::Instance()->SeekHeader())
		{
			messageType = MessageType::Seek;
		}
		else if (data == CommunicationProtocol::Instance()->VolumeHeader())
		{
			messageType = MessageType::Volume;
		}
		else if (data == CommunicationProtocol::Instance()->TerminationHeader())
		{
			messageType = MessageType::Termination;
		}
		else if (data == CommunicationProtocol::Instance()->WindowLayoutHeader())
		{
			messageType = MessageType::WindowLayout;
		}
		else if (data == CommunicationProtocol::Instance()->VideoLayoutHeader())
		{
			messageType = MessageType::VideoLayout;
		}
		else if (data == CommunicationProtocol::Instance()->DisplayDeviceHeader())
		{
			messageType = MessageType::DisplayDevicesInfo;
		}
		else if (data == CommunicationProtocol::Instance()->SoundFxHeader())
		{
			messageType = MessageType::SoundFx;
		}
		else if (data == CommunicationProtocol::Instance()->Sound3dHeader())
		{
			messageType = MessageType::Sound3d;
		}
		else if (data == CommunicationProtocol::Instance()->MidiPropertiesHeader())
		{
			messageType = MessageType::MidiProperties;
		}
		else if (data == CommunicationProtocol::Instance()->MidiOutputPortInfoHeader())
		{
			messageType = MessageType::MidiOutputPortInfo;
		}
		else if (data == CommunicationProtocol::Instance()->SetMidiOutputPortHeader())
		{
			messageType = MessageType::SetMidiOutputPort;
		}
		else if (data == CommunicationProtocol::Instance()->SetDlsHeader())
		{
			messageType = MessageType::SetDls;
		}
		else if (data == CommunicationProtocol::Instance()->SetFrequencyHeader())
		{
			messageType = MessageType::SetFrequency;
		}
		else if (data == CommunicationProtocol::Instance()->SetRateHeader())
		{
			messageType = MessageType::SetRate;
		}
        else if (data == CommunicationProtocol::Instance()->SetPlayerTypeHeader())
        {
            messageType = MessageType::SetPlayerType;
        }
		else
		{
			throw ConverterException("else", "MessageTypeToStringConverter::Convert");
		}
	}
	catch (exception& e)
	{
		throw;
	}
	return messageType;
}