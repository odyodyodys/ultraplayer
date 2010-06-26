#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

struct Position3d
{
private:
	float _x, _y, _z;

public:
	Position3d()
	{
		_x = 0.0f;
		_y = 0.0f;
		_z = 0.0f;
	};
	Position3d(float x, float y, float z)
	{
		_x = x;
		_y = y;
		_z = z;
	}
};