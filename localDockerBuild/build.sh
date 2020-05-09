#!/usr/bin/env sh

#Make sure that following environment vars are set locally (but not pushed to GIT!)
#export UNITY_USERNAME="johndoeATgmail.com"
#export UNITY_PASSWORD="myPassword"
#export UNITY_SERIAL="mySerialNumber"

#Make sure to build the dockerfile first:
#docker build --tag paulunityimage:1.0 . --build-arg DOWNLOAD_URL=http://beta.unity3d.com/download/292b93d75a2c/UnitySetup-2019.1.0f2?_ga=2.105271808.2016554913.1588963839-840046434.1574823381

export IMAGE_NAME=paulunityimage:1.0

#Generate Unity.lic.ulf
UNITY_VERSION=2019.1.0f2
docker run -it --rm \
-e UNITY_USERNAME=$UNITY_USERNAME \
-e UNITY_PASSWORD=$UNITY_PASSWORD \
-e UNITY_SERIAL=$UNITY_SERIAL \
-e "TEST_PLATFORM=linux" \
-e "WORKDIR=/root/project" \
-v "$(pwd):/root/project" \
$IMAGE_NAME \
bash -c ./root/project/generateLicense.sh

#Copy Unity.lic.ulf into your environment variable
export UNITY_LICENSE_CONTENT="$(cat Unity_lic.ulf)"

export BUILD_NAME=${BUILD_NAME:-"ExampleProjectName"}

cd ../

#Build for linux
BUILD_TARGET=StandaloneLinux64 ./ci/docker_build.sh

#Build for Mac
#export IMAGE_NAME=gableroux/unity3d:2019.3.7f1-mac
#docker pull $IMAGE_NAME
#BUILD_TARGET=StandaloneOSX ./ci/docker_build.sh

cd localDockerBuild/
