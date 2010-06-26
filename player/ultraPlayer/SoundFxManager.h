#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "SoundFxType.h"
#pragma endregion

class SoundFxManager
{
#pragma region Fields
private:
	LPDIRECTSOUNDFXCHORUS8      _chorus;
	LPDIRECTSOUNDFXCOMPRESSOR8  _compressor;
	LPDIRECTSOUNDFXDISTORTION8  _distortion;
	LPDIRECTSOUNDFXECHO8        _echo;
	LPDIRECTSOUNDFXFLANGER8     _flanger;
	LPDIRECTSOUNDFXGARGLE8      _gargle;
	LPDIRECTSOUNDFXPARAMEQ8     _paramEq;
	LPDIRECTSOUNDFXWAVESREVERB8 _reverb;

	DSFXChorus		_paramsChorus;
	DSFXCompressor	_paramsCompressor;
	DSFXDistortion	_paramsDistortion;
	DSFXEcho		_paramsEcho;
	DSFXFlanger		_paramsFlanger;
	DSFXGargle		_paramsGargle;
	DSFXParamEq		_paramsParamEq;
	DSFXWavesReverb	_paramsReverb;

	LPDIRECTSOUNDBUFFER8	_dsoundBuffer;

	DSEFFECTDESC	_effectDesc[SoundFxType::SoundFxCount];
	const GUID*		_refGuids[SoundFxType::SoundFxCount];
	LPVOID*			_rgPtrs[SoundFxType::SoundFxCount];
	BOOL			_rgLoaded[SoundFxType::SoundFxCount];
	DWORD			_numFX;
#pragma endregion

#pragma region Constructors/Destructor
public:
	SoundFxManager();
	~SoundFxManager();
#pragma endregion

#pragma region Methods
private:

	// Description: Enables an effect in a DirectSoundBuffer8,
	// and tries obtain reference to effect interface
	HRESULT EnableGenericFx( GUID sfxClass, REFGUID refInterface, LPVOID * object );

	// Description: Loads the default param value for each effect
	HRESULT LoadDefaultParamValues( );
public:
	// Description: Associates a DirectSoundBuffer with the manager, any effects
	// enabled in the old DirectSoundBuffer will be disabled,
	// and the effect objects released
	HRESULT Initialize ( LPDIRECTSOUNDBUFFER buffer, BOOL loadDefaultParamValues );

	// Description: Enables a sound effect for the sound buffer associated with this
	HRESULT SetFxEnable( DWORD soundFxType );

	// Description: Activate the effects enabled from EnableFX( )
	HRESULT ActivateFx( );

	// Description: Disables all effect in the DirectSoundBuffer,
	// and releases all effect object.
	HRESULT DisableAllFx( );

	// Description: Loads the default param value for each effect
	HRESULT LoadCurrentFxParameters( );
#pragma endregion

#pragma region Properties
public:
	DSFXChorus ParamsChorus();
	void ParamsChorus(DSFXChorus val);
	DSFXCompressor ParamsCompressor();
	void ParamsCompressor(DSFXCompressor val);
	DSFXDistortion ParamsDistortion();
	void ParamsDistortion(DSFXDistortion val);
	DSFXEcho ParamsEcho();
	void ParamsEcho(DSFXEcho val);
	DSFXFlanger ParamsFlanger();
	void ParamsFlanger(DSFXFlanger val);
	DSFXGargle ParamsGargle();
	void ParamsGargle(DSFXGargle val);
	DSFXParamEq ParamsParamEq();
	void ParamsParamEq(DSFXParamEq val);
	DSFXWavesReverb ParamsReverb();
	void ParamsReverb(DSFXWavesReverb val);
#pragma endregion

};