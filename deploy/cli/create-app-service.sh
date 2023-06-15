env=$1
grp=devops-intro
loc=westeurope
appPlan=configapp-$env
app=config-api-$env

az group create -n $grp -l $loc
az appservice plan create -n $appPlan -g $grp --sku FREE
az webapp create -n $app -g $grp --plan $appPlan --runtime "DOTNET|6.0"
