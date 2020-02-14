@echo off
set ClientDir=C:\AltV\server-files\resources\fivez\client
set TargetDir=C:\Users\Flash\source\repos\FiveZ\Client\bin
set ProjectDir=C:\Users\Flash\source\repos\FiveZ\Client

REM del %TargetDir%\*.dll
REM del %TargetDir%\*.pdb
REM rmdir /S /Q %ClientDir%
REM mkdir %ClientDir%
REM mkdir %ClientDir%\cef
REM mkdir %ClientDir%\lib
REM mkdir %ClientDir%\NativeUIMenu
REM mkdir %ClientDir%\Streamer
REM xcopy /E /Y %TargetDir% %ClientDir%
REM 
REM xcopy /E /Y %ProjectDir%\client\NativeUIMenu %ClientDir%\NativeUIMenu
REM xcopy /E /Y %ProjectDir%\client\Streamer %ClientDir%\Streamer

mkdir %ClientDir%
mkdir %ClientDir%\cef
mkdir %ClientDir%\lib
xcopy /E /Y %TargetDir%\client %ClientDir%
xcopy /E /Y %ProjectDir%\cef %ClientDir%\cef
xcopy /E /Y %ProjectDir%\lib %ClientDir%\lib