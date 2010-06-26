#include "PlayRequest.h"

PlayRequest::PlayRequest(void):ARequest(MessageType::Play)
{
}

PlayRequest::~PlayRequest(void)
{
}

void PlayRequest::FromString( string data )
{
	try
	{
		string::size_type index = CommunicationProtocol::Instance()->HeaderLength();

		for (UINT i = 0; i < data.length() ; i++)
		{
			// add delimiter
			index += CommunicationProtocol::Instance()->DelimiterLength();

			// the file id is two digit long
			int id = NumericToStringConverter::Convert<int>(data.substr(index, 2));

			// add id length
			index += 2;

			// find next delimiter
			string::size_type delimiterPos = data.find(CommunicationProtocol::Instance()->Delimiter().c_str(), index);

			// get part and break if no more parts
			if (delimiterPos >= data.length())
			{
				// get until end, no more parts

				// get filename. from index until the next delimiter
				string::size_type fileLength = data.length() - index;
				string file = data.substr(index, fileLength);
				
				// add new set to list
				_files.push_back(pair<int, string>(id, file));
				break;
			}
			else
			{
				//get until delimiter, more parts to go

				// get filename. from index until the next delimiter
				string::size_type fileLength = delimiterPos - index;
				string file = data.substr(index, fileLength);
				
				// add new set to list
				_files.push_back(pair<int, string>(id, file));

				index += fileLength;
			}
		}
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "PlayRequest::FromString");
	}
}

list<pair<int,string>> PlayRequest::Files()
{
	return _files;
}