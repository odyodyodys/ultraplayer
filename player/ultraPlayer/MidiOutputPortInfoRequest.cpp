#include "MidiOutputPortInfoRequest.h"

MidiOutputPortInfoRequest::MidiOutputPortInfoRequest(void):ARequest(MessageType::MidiOutputPortInfo)
{
}

MidiOutputPortInfoRequest::~MidiOutputPortInfoRequest(void)
{
}

void MidiOutputPortInfoRequest::FromString( string data )
{
	// nothing to parse from
}