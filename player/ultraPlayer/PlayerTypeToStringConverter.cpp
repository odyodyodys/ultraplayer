#include "PlayerTypeToStringConverter.h"

PlayerTypeToStringConverter* PlayerTypeToStringConverter::_instance = NULL;

PlayerTypeToStringConverter::PlayerTypeToStringConverter(void)
{
}

PlayerTypeToStringConverter::~PlayerTypeToStringConverter(void)
{
}

PlayerType::Type PlayerTypeToStringConverter::Convert( string data )
{
    PlayerType::Type result;

    if (data == "aud")
    {
        result = PlayerType::Audio;
    }
    else if (data == "mid")
    {
        result = PlayerType::Midi;
    }
    else if (data == "svi")
    {
        result = PlayerType::SingleVideo;
    }
    else if (data == "mvi")
    {
        result = PlayerType::MultiVideo;
    }
    else
    {
        throw ConverterException("data = " + data, "PlayerTypeToStringConverter::Convert");
    }

    return result;
}

std::string PlayerTypeToStringConverter::Convert( PlayerType::Type data )
{
    throw NotImplementedException("", "PlayerTypeToStringConverter::Convert");
}

PlayerTypeToStringConverter* PlayerTypeToStringConverter::Instance()
{
    if (!_instance)
    {
        _instance = new PlayerTypeToStringConverter();
    }
    return _instance;
}
