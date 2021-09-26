# SharePoint Framework Build

[![Build Status](https://dev.azure.com/az-400-v2/M06-CI/_apis/build/status/SPFxWebPart%20Build%20Yaml?branchName=main)](https://dev.azure.com/az-400-v2/M06-CI/_build/latest?definitionId=13&branchName=main)

Sample SPFx repo available [here](https://github.com/ARambazamba/SPFxPipeline)

## Scaffolding & Basics

SPFx (SharePoint Framework) requires [Node 10+](https://nodejs.org/en/download/releases/), Yeoman, Gulp, SPFx Generator SharePoint

```
npm i -g yo gulp @microsoft/generator-sharepoint
```

> Note: Detailed Instructions for Env Setup [here](https://docs.microsoft.com/en-us/sharepoint/dev/spfx/set-up-your-development-environment)

Create proj:

```
yo @microsoft/sharepoint
```

Manual Build:

```
npm i
gulp bundle
gulp package-solution
```

> Note: You might have to switch to node version 10.x
