#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "Position3d.h"
#pragma endregion

struct CustomVertex
{
	Position3d _position; // The position

	D3DCOLOR _color;

	// UV mapping coordinates
	float _textureU;
	float _textureV;
};
