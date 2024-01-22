#!/bin/bash

# Install httpyac CLI for API testing
npm install -g httpyac

# Microsoft speech SDK Installation
sudo apt-get update
sudo apt-get install -y build-essential libssl-dev ca-certificates libasound2 wget

# Vision SDK Installation
## Install the required dependencies
sudo apt-get update
sudo apt-get install -y build-essential libssl-dev wget
## Download the Vision SDK package
sudo apt install -y wget dpkg
wget "https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb"
sudo dpkg -i packages-microsoft-prod.deb 
## Install the Vision SDK package
sudo apt update
sudo apt install -y azure-ai-vision-dev-image-analysis



echo "----------------------------------------------"
dotnet --version
