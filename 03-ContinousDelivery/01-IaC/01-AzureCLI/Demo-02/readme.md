# IaC using Azure CLI

Use [AzAutomation Script](https://github.com/ARambazamba/AzAutomation) hosted in Github

Execute your Script from Github

```
rnd=$RANDOM
loc=westeurope
grp=az400-M13-remotescript-$rnd
appPlan=remotescript-$rnd
web=mvc-remotescript-$rnd

az group create -n $grp -l $loc
az appservice plan create -n $appPlan -g $grp --sku FREE
az webapp create -n $web -g $grp --plan $appPlan
```
