function Install-SteamCMD {
    <#
    .SYNOPSIS
    Installs SteamCMD
    
    .DESCRIPTION
    This function installs SteamCMD to the specified path.
    
    .PARAMETER InstallPath
    The path to install SteamCMD to, defaults to $HOME\.steamcmd
    #>
    
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [string]$InstallPath = "$HOME\.steamcmd"
    )
    
    begin {
        $TempPath = "$env:TEMP"
    }
    
    process {
        Invoke-WebRequest -Uri "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip" -OutFile "$TempPath\steamcmd.zip" -UseBasicParsing
        
        if (-not (Test-Path $InstallPath)) {
            Write-Verbose "Creating directory $InstallPath"
            New-Item -ItemType Directory -Path $InstallPath
            Expand-Archive -Path "$TempPath\steamcmd.zip" -DestinationPath $InstallPath
        }
        
        Write-Host -Object "Setting up SteamCMD for the first time"
        $SteamCMDProcess = Start-Process -FilePath "$InstallPath\steamcmd.exe" -ArgumentList "validate +quit" -Wait -PassThru -NoNewWindow
        if ($SteamCMDProcess.ExitCode -ne 0) {
            Write-Error "SteamCMD exited with code $($SteamCMDProcess.ExitCode)" -Category CloseError
        }
        
        Write-Host -Object "Done"
    }
    
    end {
        Remove-Item -Path "$TempPath\steamcmd.zip"
    }
}

function Install-SCPSL {
<#
    .SYNOPSIS
    Installs SCP: Secret Laboratory
    
    .DESCRIPTION
    This function installs SCP: Secret Laboratory to the specified path.
    
    .PARAMETER InstallPath
    The path to install SCP: Secret Laboratory to, defaults to $HOME\.scpsl
    
    .PARAMETER SteamCMDPath
    The path to SteamCMD, defaults to $HOME\.steamcmd
    #>
    
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [string]$InstallPath = "$HOME\.scpsl",
        
        [Parameter(Mandatory=$false)]
        [string]$SteamCMDPath = "$HOME\.steamcmd"
    )

    process {
        if (-not (Test-Path $InstallPath)) {
            Write-Verbose "Creating directory $InstallPath"
            New-Item -ItemType Directory -Path $InstallPath
        }
        
        Write-Host -Object "Installing SCP: Secret Laboratory to $InstallPath"
        $SteamCMDProcess = Start-Process -FilePath "$SteamCMDPath\steamcmd.exe" -ArgumentList "+force_install_dir `"$InstallPath`" +login anonymous +app_update 996560 validate +quit" -Wait -PassThru -NoNewWindow
        if ($SteamCMDProcess.ExitCode -ne 0) {
            Write-Error "SteamCMD exited with code $($SteamCMDProcess.ExitCode)" -Category CloseError
        }
        
        Write-Host -Object "Done"
    }
}

Install-SteamCMD
Install-SCPSL