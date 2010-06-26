#include "SoundFxManager.h"

SoundFxManager::SoundFxManager( )
{
	_chorus = NULL;
	_compressor = NULL;
	_distortion = NULL;
	_echo = NULL;
	_flanger = NULL;
	_gargle = NULL;
	_paramEq = NULL;
	_reverb = NULL;

	ZeroMemory(&_paramsChorus,		sizeof( DSFXChorus ) );
	ZeroMemory(&_paramsCompressor,	sizeof( DSFXCompressor ) );
	ZeroMemory(&_paramsDistortion,	sizeof( DSFXDistortion ) );
	ZeroMemory(&_paramsFlanger,		sizeof( DSFXFlanger ) );
	ZeroMemory(&_paramsEcho,		sizeof( DSFXEcho ) );
	ZeroMemory(&_paramsGargle,		sizeof( DSFXGargle ) );
	ZeroMemory(&_paramsParamEq,		sizeof( DSFXParamEq ) );
	ZeroMemory(&_paramsReverb,		sizeof( DSFXWavesReverb ) );

	_numFX = 0;
	ZeroMemory(_effectDesc,	sizeof(DSEFFECTDESC) *SoundFxType::SoundFxCount );
	ZeroMemory(_refGuids,	sizeof(GUID*) *SoundFxType::SoundFxCount );
	ZeroMemory(_rgPtrs,		sizeof(LPVOID*) *SoundFxType::SoundFxCount );
	ZeroMemory(_rgLoaded,	sizeof(BOOL) *SoundFxType::SoundFxCount );

	_dsoundBuffer = NULL;
}

SoundFxManager::~SoundFxManager( )
{
	// free any effects
	DisableAllFx( );

	// release the DirectSoundBuffer
	SAFE_RELEASE( _dsoundBuffer );
}

HRESULT SoundFxManager::Initialize( LPDIRECTSOUNDBUFFER buffer, BOOL loadDefaultParamValues )
{
	HRESULT hr = E_FAIL;

	if( _dsoundBuffer )
	{
		// release the effect for the previously associated sound buffers
		DisableAllFx( );
		SAFE_RELEASE( _dsoundBuffer );
	}

	if( NULL == buffer )
	{
		return S_OK;
	}

	// get the interface
	if( FAILED( hr = buffer->QueryInterface( IID_IDirectSoundBuffer8, (LPVOID*) &_dsoundBuffer ) ) )
	{
		return hr;
	}

	if( loadDefaultParamValues )
	{
		LoadDefaultParamValues( );
	}

	return S_OK;
}

HRESULT SoundFxManager::LoadDefaultParamValues( )
{
	if( NULL == _dsoundBuffer )
	{
		return E_FAIL;
	}

	for(DWORD i = SoundFxType::Chorus; i < SoundFxType::SoundFxCount; i++ )
	{
		SetFxEnable(i);
	}

	ActivateFx();

	if( _chorus )
	{
		_chorus->GetAllParameters( &_paramsChorus );
	}

	if( _compressor )
	{
		_compressor->GetAllParameters( &_paramsCompressor );
	}

	if( _distortion )
	{
		_distortion->GetAllParameters( &_paramsDistortion );
	}

	if( _echo )
	{
		_echo->GetAllParameters( &_paramsEcho );
	}

	if( _flanger )
	{
		_flanger->GetAllParameters( &_paramsFlanger );
	}

	if( _gargle )
	{
		_gargle->GetAllParameters( &_paramsGargle );
	}

	if( _paramEq )
	{
		_paramEq->GetAllParameters( &_paramsParamEq );
	}

	if( _reverb )
	{
		_reverb->GetAllParameters( &_paramsReverb );
	}

	DisableAllFx( );

	return S_OK;
}

HRESULT SoundFxManager::LoadCurrentFxParameters( )
{
	if( _chorus )
	{
		_chorus->SetAllParameters( &_paramsChorus );
	}

	if( _compressor )
	{
		_compressor->SetAllParameters( &_paramsCompressor );
	}

	if( _distortion )
	{
		_distortion->SetAllParameters( &_paramsDistortion );
	}

	if( _echo )
	{
		_echo->SetAllParameters( &_paramsEcho );
	}

	if( _flanger )
	{
		_flanger->SetAllParameters( &_paramsFlanger );
	}

	if( _gargle )
	{
		_gargle->SetAllParameters( &_paramsGargle );
	}

	if( _paramEq )
	{
		_paramEq->SetAllParameters( &_paramsParamEq );
	}

	if( _reverb )
	{
		_reverb->SetAllParameters( &_paramsReverb );
	}

	return S_OK;
}

HRESULT SoundFxManager::SetFxEnable( DWORD soundFxType )
{
	HRESULT hr = E_FAIL;

	if( soundFxType >= SoundFxType::SoundFxCount )
	{
		return E_FAIL;
	}

	if( _rgLoaded[soundFxType] )
	{
		return S_FALSE;
	}
	else
	{
		_rgLoaded[soundFxType] = TRUE;
	}

	switch ( soundFxType )
	{
	case SoundFxType::Chorus:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_CHORUS,     IID_IDirectSoundFXChorus8, (LPVOID*) &_chorus );
		break;
	case SoundFxType::Compressor:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_COMPRESSOR, IID_IDirectSoundFXCompressor8, (LPVOID*) &_compressor );
		break;
	case SoundFxType::Distortion:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_DISTORTION, IID_IDirectSoundFXDistortion8, (LPVOID*) &_distortion );
		break;
	case SoundFxType::Echo:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_ECHO,       IID_IDirectSoundFXEcho8, (LPVOID*) &_echo );
		break;
	case SoundFxType::Flanger:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_FLANGER,    IID_IDirectSoundFXFlanger8, (LPVOID*) &_flanger );
		break;
	case SoundFxType::Gargle:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_GARGLE,     IID_IDirectSoundFXGargle8, (LPVOID*) &_gargle );
		break;
	case SoundFxType::ParamEq:
		hr = EnableGenericFx( GUID_DSFX_STANDARD_PARAMEQ,    IID_IDirectSoundFXParamEq8, (LPVOID*) &_paramEq );
		break;
	case SoundFxType::Reverb:
		hr = EnableGenericFx( GUID_DSFX_WAVES_REVERB,        IID_IDirectSoundFXWavesReverb8, (LPVOID*) &_reverb );
		break;
	default:
		hr = E_FAIL;
		break;
	}

	return hr;
}

HRESULT SoundFxManager::DisableAllFx( )
{
	// release all effect interfaces created with this manager so far
	SAFE_RELEASE( _chorus );
	SAFE_RELEASE( _compressor );
	SAFE_RELEASE( _distortion );
	SAFE_RELEASE( _echo );
	SAFE_RELEASE( _flanger );
	SAFE_RELEASE( _gargle );
	SAFE_RELEASE( _paramEq );
	SAFE_RELEASE( _reverb );

	_numFX = 0;
	ZeroMemory( _effectDesc, sizeof( DSEFFECTDESC ) * SoundFxType::SoundFxCount );
	ZeroMemory( _refGuids, sizeof( GUID * ) * SoundFxType::SoundFxCount );
	ZeroMemory( _rgPtrs, sizeof(LPVOID*) * SoundFxType::SoundFxCount );
	ZeroMemory( _rgLoaded, sizeof( BOOL ) * SoundFxType::SoundFxCount );

	if( NULL == _dsoundBuffer )
	{
		return E_FAIL;
	}

	// Buffer must be stopped before calling SetFx
	if( _dsoundBuffer )
	{
		_dsoundBuffer->Stop();
	}

	// this removes all fx from the buffer
	_dsoundBuffer->SetFX( 0, NULL, NULL );

	return S_OK;
}

HRESULT SoundFxManager::ActivateFx( )
{
	DWORD dwResults[SoundFxType::SoundFxCount];
	HRESULT hr = E_FAIL;
	DWORD i;

	if( NULL == _dsoundBuffer )
	{
		return E_FAIL;
	}

	if( _numFX == 0 )
	{
		return S_FALSE;
	}

	if( FAILED( hr = _dsoundBuffer->SetFX( _numFX, _effectDesc, dwResults ) ) )
	{
		return hr;
	}

	// get reference to the effect object
	for( i = 0; i < _numFX; i++ )
	{
		if( FAILED( hr = _dsoundBuffer->GetObjectInPath( _effectDesc[i].guidDSFXClass, 0, *_refGuids[i], _rgPtrs[i] ) ) )
		{
			return DXTRACE_ERR_MSGBOX( TEXT("GetObjectInPath"), hr );
		}
	}

	return S_OK;
}

HRESULT SoundFxManager::EnableGenericFx( GUID sfxClass, REFGUID refInterface, LPVOID * object )
{
	// if an effect already allocated
	if( *object )
	{
		return S_FALSE;
	}

	if( _numFX >= SoundFxType::SoundFxCount )
	{
		return E_FAIL;
	}

	// set the effect to be enabled
	ZeroMemory( &_effectDesc[_numFX], sizeof(DSEFFECTDESC) );
	_effectDesc[_numFX].dwSize         = sizeof(DSEFFECTDESC);
	_effectDesc[_numFX].dwFlags        = 0;
	CopyMemory( &_effectDesc[_numFX].guidDSFXClass, &sfxClass, sizeof(GUID) );

	_refGuids[_numFX] = &refInterface;
	_rgPtrs[_numFX] = object;

	_numFX++;

	return S_OK;
}

DSFXChorus SoundFxManager::ParamsChorus()
{
	return _paramsChorus;
}

void SoundFxManager::ParamsChorus( DSFXChorus val )
{
	_paramsChorus = val;
	LoadCurrentFxParameters();
}

DSFXCompressor SoundFxManager::ParamsCompressor()
{
	return _paramsCompressor;
}

void SoundFxManager::ParamsCompressor( DSFXCompressor val )
{
	_paramsCompressor = val;
	LoadCurrentFxParameters();

}

DSFXDistortion SoundFxManager::ParamsDistortion()
{
	return _paramsDistortion;
}

void SoundFxManager::ParamsDistortion( DSFXDistortion val )
{
	_paramsDistortion = val;
	LoadCurrentFxParameters();

}

DSFXEcho SoundFxManager::ParamsEcho()
{
	return _paramsEcho;
}

void SoundFxManager::ParamsEcho( DSFXEcho val )
{
	_paramsEcho = val;
	LoadCurrentFxParameters();

}

DSFXFlanger SoundFxManager::ParamsFlanger()
{
	return _paramsFlanger;
}

void SoundFxManager::ParamsFlanger( DSFXFlanger val )
{
	_paramsFlanger = val;
	LoadCurrentFxParameters();

}

DSFXGargle SoundFxManager::ParamsGargle()
{
	return _paramsGargle;
}

void SoundFxManager::ParamsGargle( DSFXGargle val )
{
	_paramsGargle = val;
	LoadCurrentFxParameters();

}

DSFXParamEq SoundFxManager::ParamsParamEq()
{
	return _paramsParamEq;
}

void SoundFxManager::ParamsParamEq( DSFXParamEq val )
{
	_paramsParamEq = val;
	LoadCurrentFxParameters();

}

DSFXWavesReverb SoundFxManager::ParamsReverb()
{
	return _paramsReverb;
}

void SoundFxManager::ParamsReverb( DSFXWavesReverb val )
{
	_paramsReverb = val;
	LoadCurrentFxParameters();

}