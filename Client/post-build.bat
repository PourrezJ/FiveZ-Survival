@echo off
set ClientDir=C:\AltV\server-files\resources\fivez\client
set TargetDir=C:\Users\Flash\source\repos\FiveZ\Client\bin
set ProjectDir=C:\Users\Flash\source\repos\FiveZ\Client

del %TargetDir%\*.dll
del %TargetDir%\*.pdb
rmdir /S /Q %ClientDir%
mkdir %ClientDir%
mkdir %ClientDir%\cef
REM mkdir %ClientDir%\lib
REM mkdir %ClientDir%\NativeUIMenu
REM mkdir %ClientDir%\Streamer
xcopy /E /Y %TargetDir% %ClientDir%
xcopy /E /Y %ProjectDir%\cef %ClientDir%\cef
REM xcopy /E /Y %ProjectDir%\lib %ClientDir%\lib
REM xcopy /E /Y %ProjectDir%\client\NativeUIMenu %ClientDir%\NativeUIMenu
REM xcopy /E /Y %ProjectDir%\client\Streamer %ClientDir%\Streamer