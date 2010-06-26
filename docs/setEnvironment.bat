@echo off

rem Clear variables
echo 1/5 clearing variables
set projectDir=
set microsoftSdkDir=
set directxSdkDir=
set projectDrive=
set microsoftSdkDrive=
set directxSdkDrive=

rem Set paths
echo 2/5 setting paths
set projectDir="c:\dev\depot\Odys_Odys-Pc"
set microsoftSdkDir="C:\Program Files\Microsoft SDKs\Windows\v7.1"
set directxSdkDir="C:\Program Files (x86)\Microsoft DirectX 9.0 SDK (Summer 2004)"

rem Set drives to be used
echo 3/5 setting drive letters
set projectDrive=r:
set microsoftSdkDrive=s:
set directxSdkDrive=t:

rem Remove virtual drives if exist
echo 4/5 removing virtual drives if exist
subst %projectDrive% /D
subst %microsoftSdkDrive% /D
subst %directxSdkDrive% /D

rem Set new drives
echo 5/5 creating virtual drives
subst %projectDrive% %projectDir%
subst %microsoftSdkDrive% %microsoftSdkDir%
subst %directxSdkDrive% %directxSdkDir%

echo done.
@echo on