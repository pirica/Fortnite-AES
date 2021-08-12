# =====Fortnite AES Grabber: NuGet=====

[![Nuget](https://img.shields.io/nuget/v/Fortnite.AES?style=flat-square)](https://www.nuget.org/packages/Fortnite.AES)

Grabs AES keys for Fortnite (The Video Game).

# Use

AESGrabber.GetKeys() -Grabs the latest AES keys.

AESGrabber.WriteKeysToFile(string path) -Grabs the latest AES keys and writes them to a path of your choice.

AESGrabber.GetMainKey() -Attempts to get the latest main AES key.

AESGrabber.GetKey(string FileName) -Gets an AES key for a specified Fortnite Pak file.

AESHistory.GetOldKeys(string version) -Grabs AES keys for a specified version of Fortnite.

AESHistory.WriteOldKeysToFile(string version, string path) -Grabs AES keys for a specified version of Fortnite and writes them to a path of your choice.

AESHistory.GetOldMainKey(string version) -Attempts to get the main AES key for a specified version of Fortnite.

AESHistory.GetOldKey(string version, string FileName) -Gets an AES key for a specified Pak file of a chosen Fortnite version.

#Notice

Fortnite is a trademark and is a copyrighted work of Epic Games, Inc. All rights reserved by Epic Games, Inc. This material is not official and is not
endorsed by Epic Games, Inc.

This tool uses https://benbot.app/api/v1/aes

Thanks!
