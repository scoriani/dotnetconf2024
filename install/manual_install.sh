wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

chmod +x ./dotnet-install.sh


./dotnet-install.sh --version latest --architecture arm64

echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
source ~/.bashrc

echo 'export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools' >> ~/.bashrc
source ~/.bashrc