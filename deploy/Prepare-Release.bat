@echo off
setlocal enableextensions

mkdir ReformatUtils 2> NUL
copy /y ..\src\ReformatUtils\bin\Release\* ReformatUtils
