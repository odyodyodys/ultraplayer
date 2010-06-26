#include "MidiPortInfo.h"

MidiPortInfo::MidiPortInfo(void)
{
	_portDescription = "";
	_flags = 0x0;
	_class = 0x0;
	_type = 0x0;
	_maxAudioChannels = 0x0;
	_maxVoices = 0x0;
	_maxChannelGroups  = 0x0;
	_effectFlags = 0x0;
}

MidiPortInfo::~MidiPortInfo(void)
{
}

string MidiPortInfo::PortDescription()
{
	return _portDescription;	
}

void MidiPortInfo::PortDescription( string val )
{
	_portDescription = val;
}

DWORD MidiPortInfo::Flags()
{
	return _flags;
}

void MidiPortInfo::Flags( DWORD val )
{
	_flags = val;
}

DWORD MidiPortInfo::Class()
{
	return _class;
}

void MidiPortInfo::Class( DWORD val )
{
	_class = val;
}

DWORD MidiPortInfo::Type()
{
	return _type;
}

void MidiPortInfo::Type( DWORD val )
{
	_type = val;
}

DWORD MidiPortInfo::MaxAudioChannels()
{
	return _maxAudioChannels;
}

void MidiPortInfo::MaxAudioChannels( DWORD val )
{
	_maxAudioChannels = val;
}

DWORD MidiPortInfo::MaxVoices()
{
	return _maxVoices;
}

void MidiPortInfo::MaxVoices( DWORD val )
{
	_maxVoices = val;
}

DWORD MidiPortInfo::MaxChannelGroups()
{
	return _maxChannelGroups;
}

void MidiPortInfo::MaxChannelGroups( DWORD val )
{
	_maxChannelGroups = val;
}

DWORD MidiPortInfo::EffectFlags()
{
	return _effectFlags;
}

void MidiPortInfo::EffectFlags( DWORD val )
{
	_effectFlags = val;
}

GUID MidiPortInfo::SynthGuid()
{
	return _synthGuid;
}

void MidiPortInfo::SynthGuid( GUID val )
{
	_synthGuid = val;
}