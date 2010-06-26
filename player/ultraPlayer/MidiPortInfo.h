#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class MidiPortInfo
{
#pragma region Fields
private:
	string _portDescription;
	DWORD _flags;
	DWORD _class;
	DWORD _type;
	DWORD _maxAudioChannels;
	DWORD _maxVoices;
	DWORD _maxChannelGroups ;
	DWORD _effectFlags;
	GUID _synthGuid;
#pragma endregion

#pragma region Constructors/Destructors
public:
	MidiPortInfo();
	virtual ~MidiPortInfo();
#pragma endregion

#pragma region Properties
public:
	string PortDescription();
	void PortDescription(string val);
	DWORD Flags();
	void Flags(DWORD val);
	DWORD Class();
	void Class(DWORD val);
	DWORD Type();
	void Type(DWORD val);
	DWORD MaxAudioChannels();
	void MaxAudioChannels(DWORD val);
	DWORD MaxVoices();
	void MaxVoices(DWORD val);
	DWORD MaxChannelGroups();
	void MaxChannelGroups(DWORD val);
	DWORD EffectFlags();
	void EffectFlags(DWORD val);
	GUID SynthGuid();
	void SynthGuid(GUID val);
#pragma endregion

};