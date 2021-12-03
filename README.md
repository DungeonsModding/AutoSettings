# AutoSettings
Tool for Minecraft Dungeons that Automatically locates and writes your editor directory and package output

# How to use

It's pretty simple, **make sure it is under Mod-Kit/Tools or else it will not work.** Once it is in that folder, you run it then it will ask you for the Mod name. **Make sure .pak is not included in the name** then press enter, it will print out the 2 values and you can close it. It should automatically fill it.

# Editor Directory Incorrect

If the directory is incorrect that means your registry is messed up.

You will need to open RegEdit and navigate to

**HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\\Unreal Engine\\4.22**

Double click on the *InstalledDirectory* Key and edit the value to the correct path. Once you run it again, it should have the correct directory
