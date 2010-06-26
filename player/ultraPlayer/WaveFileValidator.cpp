#include "WaveFileValidator.h"

WaveFileValidator* WaveFileValidator::_instance = NULL;

WaveFileValidator::WaveFileValidator(void)
{
}

WaveFileValidator::~WaveFileValidator(void)
{
}

bool WaveFileValidator::IsValid( string data )
{
	bool success = false;
	HRESULT hr = E_FAIL;
	try
	{
		FileUtils::Instance()->FileExists(data);

		CWaveFile wavefile;
		USES_CONVERSION;
		hr = wavefile.Open(A2W(data.c_str()), NULL, WAVEFILE_READ);
		if (FAILED(hr))
		{
			throw ValidationFailedException("wavefile.Open","WaveFileValidator::IsValid");
		}

		// get wave format
		WAVEFORMATEX* pwfx = wavefile.GetFormat();
		if (pwfx->wFormatTag != WAVE_FORMAT_PCM && pwfx->wFormatTag != WAVE_FORMAT_IEEE_FLOAT)
		{
			throw ValidationFailedException("Sound must be PCM or IEEE FLOAT when using DSBCAPS_CTRLFX","WaveFileValidator::IsValid");
		}

		wavefile.Close();

		success = true;
	}
	catch (exception& e)
	{
		success = false;	
	}
	return success;
}

WaveFileValidator* WaveFileValidator::Instance()
{
	if (!_instance)
	{
		_instance = new WaveFileValidator();
	}
	return _instance;
}

WORD WaveFileValidator::GetChannelCount( string filename )
{
	WORD channelCount = 0;

	try
	{
		CWaveFile waveFile;
		USES_CONVERSION;
		waveFile.Open( A2W(filename.c_str()), NULL, WAVEFILE_READ );
		WAVEFORMATEX* pwfx = waveFile.GetFormat();
		if( pwfx == NULL )
		{
			throw PlaybackException("Couldn't open wave file:" + filename, "WaveFileValidator::GetChannelCount");
		}
	
		channelCount = pwfx->nChannels;		
	}
	catch (exception& e)
	{
		channelCount = 0;
	}

	return channelCount;
}