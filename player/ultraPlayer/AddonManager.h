#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AAddon.h"
#include "AExpandable.h"
#include "InvalidArgumentException.h"
#pragma endregion

using namespace std;

template <typename allowedAddonType>
class AddonManager
{
#pragma region Fields
private:
	list<AAddon*> _addons;
	list<AExpandable<allowedAddonType>*> _expandables;
#pragma endregion

#pragma region Constructors/Destructors
public:
	AddonManager();
	virtual ~AddonManager();
#pragma endregion

#pragma region Methods
public:
	// Description: Register an expandable (that can have attached addons)
	void RegisterExpandable(AExpandable<allowedAddonType>* expandable);

	// Description: Unregisters an expandable
	void UnregisterExpandable(AExpandable<allowedAddonType>* expandable);

	// Description: Regiters an addon. It will be attached to all expandabled registered (current and future)
	// If it is already registered, it get updated.
	void RegisterAddon(allowedAddonType* addon);

	// Description: Unregisters an addon from self and all expandables
	void UnregisterAddon(UINT addonId);
#pragma endregion

};

template <typename allowedAddonType>
AddonManager<allowedAddonType>::AddonManager()
{

}
template <typename allowedAddonType>
AddonManager<allowedAddonType>::~AddonManager()
{
	// remove addons from expandables
	for (list<AExpandable<allowedAddonType>*>::iterator expandIter = _expandables.begin(); expandIter != _expandables.end(); expandIter++)
	{
		for (list<AAddon*>::iterator addonIter = _addons.begin(); addonIter!= _addons.end(); addonIter++)
		{
			(*expandIter)->Detouch((allowedAddonType*)*addonIter);
		}
	}

	// release all expandables
	for (list<AExpandable<allowedAddonType>*>::iterator expandIter = _expandables.begin(); expandIter != _expandables.end(); expandIter++)
	{
		delete *expandIter;
	}

	// release all addons
	for (list<AAddon*>::iterator addonIter = _addons.begin(); addonIter!= _addons.end(); addonIter++)
	{
		delete *addonIter;
	}

}
template <typename allowedAddonType>
void AddonManager<allowedAddonType>::RegisterExpandable( AExpandable<allowedAddonType>* expandable )
{
	_expandables.push_back(expandable);

	// attach all addons to new expandable
	for(list<AAddon*>::iterator addonIter = _addons.begin(); addonIter != _addons.end(); addonIter++)
	{
		expandable->Attach((allowedAddonType*)* addonIter);
	}
}
template <typename allowedAddonType>
void AddonManager<allowedAddonType>::UnregisterExpandable( AExpandable<allowedAddonType>* expandable )
{
	//make sure it belongs to the list and can be unregistered
	bool validExpandable = false;
	for (list<AExpandable<allowedAddonType>*>::iterator expandIter = _expandables.begin(); expandIter != _expandables.end(); expandIter++)
	{
		if (*expandIter == expandable)
		{
			validExpandable = true;
			break;
		}
	}

	if (validExpandable)
	{
		// detouch all addons first
		for(list<AAddon*>::iterator addonIter = _addons.begin(); addonIter != _addons.end(); addonIter++)
		{
			expandable->Detouch((allowedAddonType*)* addonIter);
		}

		_expandables.remove(expandable);
	}

}
template <typename allowedAddonType>
void AddonManager<allowedAddonType>::RegisterAddon( allowedAddonType* addon )
{
	try
	{
		// cast it to verify that it is an addon based object
		AAddon* castedAddon = dynamic_cast<AAddon*>(addon);
		if (NULL == castedAddon)
		{
			throw InvalidArgumentException("addon type mismatch", "AddonManager<allowedAddonType>::RegisterAddon");
		}

		// search for addon with the same id
		bool isUpdate = false;
		AAddon* foundAddon = NULL;
		for (list<AAddon*>::iterator addonIter = _addons.begin(); addonIter!= _addons.end(); addonIter++)
		{
			if (castedAddon->Id() == (*addonIter)->Id() )
			{
				isUpdate = true;
				foundAddon = *addonIter;
				break;
			}
		}

		// insert or update
		if (isUpdate)
		{
			foundAddon->Update(addon);

			delete addon;
		}
		else
		{
			// add the new one to list
			_addons.push_back(addon);

			// attach it to all expandables
			for (list<AExpandable<allowedAddonType>*>::iterator expandIter = _expandables.begin(); expandIter != _expandables.end(); expandIter++)
			{
				(*expandIter)->Attach(addon);
			}
		}
	}
	catch (exception& e)
	{
		// TODO throw exception
	}

}
template <typename allowedAddonType>
void AddonManager<allowedAddonType>::UnregisterAddon( UINT addonId )
{
	try
	{
		AAddon* foundAddon = NULL;
		bool found = false;

		for(list<AAddon*>::iterator addonIter =_addons.begin(); addonIter != _addons.end(); addonIter++)
		{
			if ((*addonIter)->Id() == addonId)
			{
				foundAddon = *addonIter;
				found = true;
				break;
			}
		}

		if (found)
		{
			// remove it also from all expandables 
			for (list<AExpandable<allowedAddonType>*>::iterator expandIter = _expandables.begin(); expandIter != _expandables.end(); expandIter++)
			{
				(*expandIter)->Detouch((allowedAddonType*)foundAddon);
			}

			// remove it from the list
			_addons.remove(foundAddon);
			delete foundAddon;

		}
	}
	catch (exception& e)
	{

	}

}