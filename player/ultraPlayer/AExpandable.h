#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

template <typename addonBaseType>
class AExpandable abstract
{
#pragma region Fields
private:
	CCritSec _objectLock;
	CCritSec _usingListLock;
	list<addonBaseType*> _addons;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	AExpandable();
public:
	virtual ~AExpandable();
#pragma endregion

#pragma region Methods
public:
	// Description: Attaches an addon to the expandable
	// method is considered thread safe
	bool Attach(addonBaseType* addon);

	// Description: Detouches (removes) an addon from self
	// method is considered thread safe
	bool Detouch(addonBaseType* addon);
#pragma endregion

#pragma region Properties
protected:
	// Description: Locks addons, for the current thread, in order to use them
	list<addonBaseType*> StartUsingAddons();

	// Description: Unlocks addons. Other threads can access addons list
	void StopUsingAddons();
#pragma endregion

};

template <typename addonBaseType>
AExpandable<addonBaseType>::AExpandable()
{

}
template <typename addonBaseType>
AExpandable<addonBaseType>::~AExpandable()
{
	// not responsible for deleting
}

template <typename addonBaseType>
bool AExpandable<addonBaseType>::Attach( addonBaseType* addon )
{
	bool success = false;

	try
	{
		CAutoLock lock(&_objectLock);
		CAutoLock LockList(&_usingListLock);
		_addons.push_back(addon);
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

template <typename addonBaseType>
bool AExpandable<addonBaseType>::Detouch( addonBaseType* addon )
{
	bool success = false;

	try
	{
		CAutoLock lock(&_objectLock);
		CAutoLock LockList(&_usingListLock);
		_addons.remove(addon);
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

template <typename addonBaseType>
list<addonBaseType*> AExpandable<addonBaseType>::StartUsingAddons()
{
	// caller shout NOT manipulate list, just to access objects

	CAutoLock lock(&_objectLock);

	_usingListLock.Lock();

	return _addons;
}

template <typename addonBaseType>
void AExpandable<addonBaseType>::StopUsingAddons()
{
	CAutoLock lock(&_objectLock);

	_usingListLock.Unlock();
}