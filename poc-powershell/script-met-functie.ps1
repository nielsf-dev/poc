function Write-Something-Cool {

    [CmdletBinding()]
    param(
        $cool
    )

    write $cool
    Write-Verbose 'verbosing mucnb info'   
    if($VerbosePreference -eq 'Continue'){
        write 'zo dus! zelf doen'
    }

}

(Get-Command -Name Write-Something-Cool).Parameters.Keys

Write-Something-Cool 'so cool' -verbose -debug
