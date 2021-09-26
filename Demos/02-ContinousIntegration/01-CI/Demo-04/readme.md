# Custom Build Agent

- Execute `create-build-vm.azcli` to install the vm
- Execute `setup-devops-agent-vm.ps1` from inside the vm you created in the prev step to install Build Agent on VM
- Execute `configure-devops-agent.ps1` from inside the vm you created in the first step to install Build Agent on VM
- Complete the config:

> Note: Instead of copying you can also execute `setup-devops-agent-vm.ps1` from GitHub in an elevated PowerShell prompt:

```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force;
Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/ARambazamba/AZ-400/main/Demos/04-AzurePipelines/Demo-05/setup-devops-agent-vm.ps1'))
```

![config-agent.jpg](_images/config-agent.jpg)

## Readings

[Self-hosted Windows agents](https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/v2-windows?view=azure-devops)
