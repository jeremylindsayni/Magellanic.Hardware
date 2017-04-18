param ([string]$ip, [string]$destination)

& ".\publish-ubuntu.ps1"

& pscp.exe -r .\bin\Debug\netcoreapp2.0\ubuntu.16.04-arm\publish\* ubuntu@${ip}:${destination}