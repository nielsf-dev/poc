- variabelen
	* Je heb kennelijk een $profile variabele, wat zijn variabelen. GLobal? Local?
	  je heb scopes voor variabelen
	
- parameters
	* Default parameters worden aangegeven in de help
		Get-ChildItem [[-Filter] <System.String>]
		Get-Content [-Path] <System.String[]>
		
	  zodoende kan je gewoon doen get-content c:\work
	  
	* CmdletBinding
		vaagste shit ever, voegt parameters toe??? word het een advanced function
		.. Een advanced function is hetzelfde als een CmdLet. Alleen dan niet in c# geschreven maar in powershell zelf
		
		Die parameters worden dus geimplemeteerd door PowerShell... niet door je functie zelf. -Verbose opgeven verandert bv $VerbosePreference
		
		https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_commonparameters?view=powershell-7.3
		
		Die $VerbosePreference.. is een preference variabele
		https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_preference_variables?view=powershell-7.3	
		
- CmdLets	
	* Wat zijn dat precies?
		Commands for PowerShell are known as cmdlets (pronounced command-lets). In addition to cmdlets, PowerShell allows you to run any command available on your system.
	
		 
- scripts
	* Mja gewoon in een .ps1 file
	
- functies
	* Syntax is kennelijk zo:
	
	function Write-Something-Cool {
		param(
			$cool
		)
		write $cool
	}

	Write-Something-Cool 'so cool'


- profiles
- modules