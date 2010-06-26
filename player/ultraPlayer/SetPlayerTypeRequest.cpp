#include "SetPlayerTypeRequest.h"

SetPlayerTypeRequest::SetPlayerTypeRequest(void):ARequest(MessageType::SetPlayerType)
{
    // default to single video player
    _playerType = PlayerType::SingleVideo;
}

SetPlayerTypeRequest::~SetPlayerTypeRequest(void)
{
}

void SetPlayerTypeRequest::FromString( string data )
{
    PlayerTypeToStringConverter* converter = NULL;
    try
    {
        int index = CommunicationProtocol::Instance()->HeaderLength();

        PlayerTypeToStringConverter* converter = new PlayerTypeToStringConverter();
        _playerType = converter->Instance()->Convert(data.substr(index, data.length() - index));
        delete converter;
    }
    catch (exception& e)
    {
        // clean up
        if (converter)
        {
            delete converter;
        }

        throw CommunicationException(e.what(), "SetPlayerTypeRequest::FromString");
    }

}

PlayerType::Type SetPlayerTypeRequest::PlayerType()
{
    return _playerType;
}
