# Enable Hyper-V

choco install docker-desktop

Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All

Restart-Computer

Enable-WindowsOptionalFeature -Online -FeatureName $("VirtualMachinePlatform", "Microsoft-Windows-Subsystem-Linux")

