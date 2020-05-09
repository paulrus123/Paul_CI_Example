This is the dockerfile used to generate the DockerImage that is used for the local build. To build it, run 

docker build --tag paulunityimage:1.0 . --build-arg DOWNLOAD_URL=http://beta.unity3d.com/download/292b93d75a2c/UnitySetup-2019.1.0f2?_ga=2.105271808.2016554913.1588963839-840046434.1574823381

Where the build arg is the linux unity version you want to build (in this case 2019.1.0f2) taken from: 
https://forum.unity.com/threads/unity-on-linux-release-notes-and-known-issues.350256/
