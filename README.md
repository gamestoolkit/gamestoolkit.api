# gamestoolkit.api

## Windows

1. Install [Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/).
2. Run the project and trust SSL certificates and restart your machine.
3. You're ready to go!

### Docker development (with Visual Studio)

1. Install [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/) and configure it for **Linux Containers**.
2. Run these commands (you may need to enable CPU virtualization on your BIOS):

   ```sh
   dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart
   dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart

   # If update fails, try to install: wsl.exe --install
   wsl.exe --update

   wsl --set-default-version 2
   ```

3. Restart. Accept SSL certificates and Re-restart your machine.
4. You're ready to go!

* Problems? [Check this guide](https://learn.microsoft.com/en-us/windows/wsl/install-manual)