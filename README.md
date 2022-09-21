# Ethereal

//HELLO! <3

# Development Environment
You will need to have git installed on your computer. At a minimum you'll need the
git CLI. See lists below for GUI clients for your operating systems.

## Install git
See [Installing Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) or

  * Window users can use [chocolatey](https://chocolatey.org) to install [git](https://community.chocolatey.org/packages/git)
  * MacOS users can uses [brew](https://brew.sh) to install [git](https://formulae.brew.sh/formula/git#default)

### Windows GUI clients
  * XXX - looking for recommendations @basictheprogram in Discord

### MacOS GUI clients
  * XXX - looking for recommendations @basictheprogram in Discord

## Install Unity
You will need to have Unity installed on your computer.

The project is using Unity 2021.3.10f1 and you can install it from the
[Unity Hub](https://unity.com/download) or

  * Window users can download [2021.3.10f1](https://download.unity3d.com/download_unity/1c7d0df0160b/UnityDownloadAssistant-2021.3.10f1.exe)
  * MacOS users can download [2021.3.10f1](https://download.unity3d.com/download_unity/1c7d0df0160b/UnityDownloadAssistant-2021.3.10f1.dmg)

### MacOS
Can read the official
[How to activate a Unity license via command line on macOS](https://support.unity.com/hc/en-us/articles/5541533346068-How-to-activate-a-Unity-license-via-command-line-on-macOS-).
The default Unity installation trying to install Visual Studio Code. I recommend you
uncheck the component.

Here is my notes:
  1. Exit Unity
  1. cd ~/Downloads
  1. /Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -createManualActivationFile -logfile
  1. Open the [license.unity3d.com/manual](https://license.unity3d.com/manual) webpage
  1. Browse, navigate to ~/Download and upload the *.alf file
  1. Select Unity Personal Edition
  1. Download the license file
  1. /Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -manualLicenseFile Unity_v2021.x.ulf -logfile

## Install Discord
You will need to have [Discord](https://discord.com/download) installed on your computer or

  * Window users can use [chocolatey](https://chocolatey.org) to install [Discord](https://community.chocolatey.org/packages/discord)
  * MacOS users can use [brew](https://brew.sh) to install [Discord](https://formulae.brew.sh/cask/discord#default)

## Install Visual Studio Code (recommended)
You will need a text editor and we recommend [Visual Studio Code](https://code.visualstudio.com/download) or

  * Window users can use [chocolatey](https://chocolatey.org) to install [Visual Studio Code](https://community.chocolatey.org/packages/vscode)
  * MacOS users can use [brew](https://brew.sh) to install [Visual Studio Code](https://formulae.brew.sh/cask/visual-studio-code#default)

### VScode Extensions (recommended)
We recommend the following VScode Extensions. [Learn](https://code.visualstudio.com/docs/editor/extension-marketplace)
how to install extensions.

  * Better Comments from Aaron Bond
  * C# from Microsoft
  * Unity Tools from Tobiah Zarlez
  * Unity Code Snippets from Klever Silva

# Educate Yourself
  * [Learn Unity - Beginner's Game Development Tutorial](https://www.youtube.com/watch?v=gB1F9G0JXOo&t=509s)
