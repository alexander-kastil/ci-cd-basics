# Implement & Use a Self-hosted Docker Linux Agent

A production ready version of this agent is published at [DockerHub](https://hub.docker.com/repository/docker/arambazamba/aciagentlinux)

## Configure Agent Container

### Examine the dockerfile

The dockerfile basically executes these steps:

- Install tooling (wget, curl, ...)
- Download `vstsagentpackage-xxx` with the default software. 
- Execute default software installation from extracted `vstsagentpackage-xxx` using `start.sh` which executes `run.sh`
- Add custom software using optional installer scripts

The dockerfile contains the `AGENT_VERSION` which is `2.185.1` in this case. You can get the current version from the [azure-pipelines-agen](https://github.com/Microsoft/azure-pipelines-agent/releases) repo. 

```bash
ARG TARGETARCH=amd64
ARG AGENT_VERSION=2.185.1
```

This information is used to decide thich package of the agent to download and install:

```
AZP_AGENTPACKAGE_URL=https://vstsagentpackage.azureedge.net/agent/${AGENT_VERSION}/vsts-agent-linux-x64-${AGENT_VERSION}.tar.gz;
```

To add capabilities you have to add setup scripts to `/installers/` and update the `Dockerfile` to install the required software

```docker
COPY installers /installers

RUN /installers/netcore.sh
RUN /installers/node.sh
RUN /installers/m365-cli.sh
```

Build Linux Agent:

```bash
docker build -t aciagentlinux .
```

>Note: Local testing can be done using: `docker run -it --rm aciagentlinux -e AZP_URL=$org -e AZP_TOKEN=$token -e AZP_POOL=$pool`

Upload Linux Agent:

```
docker tag aciagentlinux arambazamba/aciagentlinux
docker push arambazamba/aciagentlinux
```
## Use Container

Create a custom agent pool - ie: `aci-pool`

![aci-pool](_images/aci-pool.png)

Get Azure DevOps token:

![devops-token](_images/devops-token.png)

Export token to env or add it to script:

```
export token=ae3ypool6mvpf7624it7j4smbveyrics4rnpu...
```

Execute `creat-linux-agent-on-ci.azcli` to upload agent and create Container Instance. Update Environment Vars:

```bash
az container create -g $grp -l $loc -n $agent --image $img --cpu 1 --memory 1 --dns-name-label $agent --port 80 --environment-variables 'AZP_URL'=$org 'AZP_TOKEN'=$token 'AZP_AGENT_NAME'=$agent 'AZP_POOL'=$pool
```

Check if agent was registered in your DevOps orga:

![agent-up](_images/agent-up.png)

## Build using Custom Agent

### Functional Test

Simple Agent Test `../test-agent.yml`:

```yaml
trigger:
    - main

pool:
    name: aci-pool

steps:
    - script: echo Hello, world!
      displayName: "Run a one-line script"

    - script: |
          echo Add other tasks to build, test, and deploy your project.
          echo See https://aka.ms/yaml
      displayName: "Run a multi-line script"
```

### .NET Core Test

Test a .NET 5 Build from [https://github.com/arambazamba/simple-mvc](https://github.com/arambazamba/simple-mvc) using `../test-agent-net.yml`

To reference you custom pool in yaml use [pool](https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser#choosing-a-pool-and-agent-in-your-pipeline)

```
name: test-agent-net
trigger:
  branches:
    include:
      - master

pool:
    name: aci-pool
```

### Microsoft 365 Stack Test

This sample is using `../test-agent-spfx.yml` [https://github.com/arambazamba/spfx-devops](https://github.com/arambazamba/spfx-devops/blob/main/az-pipelines/test-agent-spfx.yml)

Notice the line `RUN /installers/node.sh` in `dockerfile`. It installes Node 14.x, [Gulp](https://gulpjs.com/) that is used to build a [SharePoint Framework Webpart](https://docs.microsoft.com/en-us/sharepoint/dev/spfx/sharepoint-framework-overview) and the [CLI for Microsoft 365](https://pnp.github.io/cli-microsoft365/) that can be used to publish this WebPart later on. By preinstalling this software you can remove the steps from your `*.yaml` and speed up your DevOps.

```bash
curl -sL https://deb.nodesource.com/setup_14.x | sudo -E bash -
sudo apt install nodejs

echo "NODE Version:" && node --version
echo "NPM Version:" && npm --version

sudo npm i -g gulp
sudo npm i -g @pnp/cli-microsoft365
```
