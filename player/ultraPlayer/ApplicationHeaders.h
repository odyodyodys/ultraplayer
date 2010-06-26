#pragma once

// Enable extra D3D debugging in debug builds if using the debug DirectX runtime.  
#if defined(DEBUG) | defined(_DEBUG)
#define D3D_DEBUG_INFO
#endif


// standard input/output
#include <stdio.h>

// winsock ver2
#include <WinSock2.h>

// windows types
#include <Windows.h>


// lists, strings
#include <vector>
#include <list>
#include <string>
#include <map>

// streams
#include <iostream>
#include <sstream>

// standard exceptions
#include <exception>

// atl
#include <atlbase.h>
#include <atlconv.h>
#include <atlcomcli.h>

// direct X
#include <D3D9.h>
#include <d3dx9.h>
#include <dxerr9.h>

// direct show
#include <DShow.h>
#include <Vmr9.h>

// direct sound
#include <mmsystem.h>
#include <mmreg.h>
#include <dsound.h>

// direct music
#include <dmusicc.h>
#include <dmusici.h>
#include <dmksctrl.h>

// math, algorithms
#include <math.h>

// Dshow base classes
#include <Streams.h>

// Helper headers
#include "dxstdafx.h"