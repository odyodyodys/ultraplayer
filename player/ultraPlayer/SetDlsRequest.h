#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "CommunicationProtocol.h"
#pragma endregion

class SetDlsRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	string _dlsFile;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetDlsRequest();
public:
	virtual ~SetDlsRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	std::string DlsFile();
#pragma endregion
};