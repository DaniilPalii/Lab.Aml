param([string]$MigrationName)

$project = "$PSScriptRoot\..\Lab.Aml.DatabaseDesign.csproj"

dotnet ef migrations has-pending-model-changes `
	--project $project `
	| Tee-Object -Variable modelChangesStatus

if (-not ($modelChangesStatus -contains 'Changes have been made to the model since the last migration. Add a new migration.')) {
	return
}

if (-not $MigrationName) {
	Write-Host 'Migration name: ' -NoNewline
	$MigrationName = Read-Host
}

dotnet ef migrations add $MigrationName `
	--project $project `
	--output-dir .\Migrations\ `
	--no-build

dotnet build $project `
	--verbosity quiet `
	--nologo

$migrations = dotnet ef migrations list `
	--project $project `
	--no-connect `
	--json `
	--no-build `
	| ConvertFrom-Json `
	| Sort-Object -Property id

dotnet ef migrations script ($migrations[-2]?.id ?? 0) $migrations[-1].id `
	--project $project `
	--output "$PSScriptRoot\..\SqlMigrations\$($migrations[-1].id).sql" `
	--idempotent `
	--no-build

dotnet ef migrations script `
	--project $project `
	--output "$PSScriptRoot\..\SqlMigrations\CombinedMigration.sql" `
	--idempotent `
	--no-build
