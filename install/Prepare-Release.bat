@echo off
setlocal enableextensions

mkdir ReformatUtils 2> NUL
copy /y ..\src\resharper-reformatutils\bin\Release\* ReformatUtils
