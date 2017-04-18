param ([string]$ip, [string]$destination)

& ".\publish-ubuntu.ps1"

& pscp.exe -r * ubuntu@${ip}:${destination}