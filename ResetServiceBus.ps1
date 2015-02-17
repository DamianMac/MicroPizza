$localUser = [Environment]::UserName

$namespaces = Get-SBClientConfiguration
$namespaces = $namespaces -like "*micropizza-local*"
IF($namespaces -eq $FALSE -or $namespaces.Count -eq 0)
{
	Write-Host "Namespace doesn't exist. Creating it."
	New-SBNamespace -Name micropizza-local -ManageUsers $localUser
}
ELSE
{
	Write-Host "Namespace already exists. Nothing to see here."
}