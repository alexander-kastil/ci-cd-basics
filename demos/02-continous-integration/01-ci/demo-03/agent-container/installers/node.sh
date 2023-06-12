curl -sL https://deb.nodesource.com/setup_16.x | sudo -E bash -
sudo apt install nodejs

echo "NODE Version:" && node --version
echo "NPM Version:" && npm --version

sudo npm i -g gulp
sudo npm i -g @pnp/cli-microsoft365