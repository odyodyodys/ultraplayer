#pragma once

class MessageType
{
public:
	enum Type
	{
		GeneralFailure,
		SetImage,
		SetText,
		RemoveAddon,
		Play,
		Stop,
		Pause,
		Resume,
		Seek,
		Volume,
		Termination,
		WindowLayout,
		VideoLayout,
		DisplayDevicesInfo,
		SoundFx,
		Sound3d,
		MidiProperties,
		MidiOutputPortInfo,
		SetMidiOutputPort,
		SetDls,
		SetFrequency,
		SetRate,
        SetPlayerType
	};

};