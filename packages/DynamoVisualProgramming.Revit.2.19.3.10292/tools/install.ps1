param($installPath, $toolsPath, $package, $project)

$asm_root_folder_name = [System.IO.Path]::Combine($installPath,`
"lib");

$net_folders = [System.IO.Directory]::GetDirectories(`
$asm_root_folder_name, 'net*', 'TopDirectoryOnly');

$file_names = New-Object `
'System.Collections.Generic.HashSet[string]';

foreach ($net in $net_folders) {

    $files = [System.IO.Directory]::EnumerateFiles($net,"*.dll"`
    ,"AllDirectories");

        foreach ($file in $files) {

            $file_name = [System.IO.Path]::`
            GetFileNameWithoutExtension($file);

            $file_names.Add($file_name);
    }
}

foreach ($reference in $project.Object.References) {

    if($file_names.Contains($reference.Name)) {

        $reference.CopyLocal = $false;
        $reference.SpecificVersion = $false;
    }
}