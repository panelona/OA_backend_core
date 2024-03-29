# Script para apagar bin e obj de todos o projeto .net
$acao = Read-Host "Este script irá remover todos os diretórios 'bin' e 'obj' no diretório atual e subdiretórios. Escolha uma opção: (S)im, (N)ão, (W)hatIf para simulação"
switch ($acao) {
    'S' {
        # Encontra e remove os diretórios 'bin' e 'obj'
        Get-ChildItem .\ -include bin,obj -Recurse  | ForEach-Object {
            Remove-Item $_.fullname -Force -Recurse -Verbose
        }
        Write-Host "Diretórios 'bin' e 'obj' removidos com sucesso."
    }
    'W' {
        # Simula a remoção dos diretórios 'bin' e 'obj'
        Get-ChildItem .\ -include bin,obj -Recurse | ForEach-Object {
            Remove-Item $_.fullname -Force -Recurse -WhatIf -Verbose
        }
    }
    Default {
        Write-Host "Operação cancelada pelo usuário."
    }
}
