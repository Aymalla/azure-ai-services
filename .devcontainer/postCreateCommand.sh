#!/bin/bash

# Install k6 CLI for load testing
sudo gpg -k
sudo gpg --no-default-keyring --keyring /usr/share/keyrings/k6-archive-keyring.gpg --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys C5AD17C747E3415A3642D57D77C6C491D6AC1D69
echo "deb [signed-by=/usr/share/keyrings/k6-archive-keyring.gpg] https://dl.k6.io/deb stable main" | sudo tee /etc/apt/sources.list.d/k6.list
sudo apt-get update
sudo apt-get install k6

# Install k9s CLI  to manage k8s clusters 
curl -sS https://webinstall.dev/k9s | bash

# Install httpyac CLI for API testing
npm install -g httpyac

# Inatall Microsoft speech dependencies
wget -O - https://www.openssl.org/source/openssl-1.1.1u.tar.gz | tar zxf -
cd openssl-1.1.1u
./config --prefix=/usr/local
make -j $(nproc)
sudo make install_sw install_ssldirs
sudo ldconfig -v
export SSL_CERT_DIR=/etc/ssl/certs
sudo apt-get update
sudo apt-get -y install libssl-dev libasound2

# Install the Vision SDK package
# using Vision SDK on Ubuntu 22.04 LTS: https://github.com/Azure-Samples/azure-ai-vision-sdk/blob/main/docs/ubuntu2204-notes.md
# https://github.com/Azure-Samples/azure-ai-vision-sdk/blob/main/samples/cpp/image-analysis/README-Linux.md
wget -O - https://www.openssl.org/source/openssl-1.1.1u.tar.gz | tar zxf -
cd openssl-1.1.1u
./config --prefix=/usr/local
make -j $(nproc)
sudo make install_sw install_ssldirs
sudo ldconfig -v
export SSL_CERT_DIR=/etc/ssl/certs
export LD_LIBRARY_PATH=/usr/local/lib:$LD_LIBRARY_PATH

sudo apt-get update
sudo apt-get install -y build-essential libssl-dev wget

sudo apt install wget dpkg
wget "https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb"
sudo dpkg -i packages-microsoft-prod.deb 

sudo apt update
sudo apt install -y azure-ai-vision-dev-image-analysis

echo "----------------------------------------------"
dotnet --version
