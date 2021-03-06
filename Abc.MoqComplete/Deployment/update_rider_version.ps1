$BuildPropsFile = "Abc.MoqComplete\Directory.Build.props"
$PluginXmlFile = "Abc.MoqComplete\Abc.MoqComplete\Resources\plugin.xml"

# Get current version
if (Test-Path $BuildPropsFile) {
	$BuildProp = [xml] (Get-Content $BuildPropsFile)
	$Version = $BuildProp.SelectSingleNode(".//Project/PropertyGroup/Version").innerText
	Write-Host "Version is $Version"
}

Write-Host "Setting version $Version to plugin.xml"

# Adapt plugin.xml 
if (Test-Path $PluginXmlFile) {
	$PluginXml = [xml] (Get-Content $PluginXmlFile)
	$PluginXml.SelectSingleNode(".//idea-plugin/version").innerText = "$Version"
	$PluginXml.Save((Resolve-Path $PluginXmlFile))
}