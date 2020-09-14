@echo off
set ClientDir=D:\AltV\Server\resources\FiveZ\Client
set TargetDir=C:\Users\Flash\source\repos\FiveZ\Client\bin
set ProjectDir=C:\Users\Flash\source\repos\FiveZ\Client

mkdir %ClientDir%
REM mkdir %ClientDir%\cef
REM mkdir %ClientDir%\lib
xcopy /E /Y %TargetDir%\client %ClientDir%
REM xcopy /E /Y %ProjectDir%\cef %ClientDir%\cef
REM xcopy /E /Y %ProjectDir%\lib %ClientDir%\lib