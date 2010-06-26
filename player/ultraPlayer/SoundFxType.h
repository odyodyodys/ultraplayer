#pragma once

class SoundFxType 
{
public:
	enum Type
	{
		Chorus,
		Compressor,
		Distortion,
		Echo,
		Flanger,
		Gargle,
		ParamEq,
		Reverb,

		// number of enumerated effects
		SoundFxCount
	};
};