# OA_backend_core
Backend Core do Open Academy

![Diagrama de Containeres](docs/images/OA_Level2.png)


## Como executar o projeto
Esse projeto depende de recursos que est�o provisionados em containers docker.
Para executar o projeto, siga os passos abaixo:

Com o docker instalado na maquina execute o comando abaixo na raiz do projeto:
```
docker compose up
```

Esse arquivo n�o deve de maneira alguma ser usado em produ��o, ele � apenas para facilitar o desenvolvimento.
E para facilitar ele j� conta com os dados de acesso pr�-configurados.

## User Secrets 
Para evitar problemas no deploy o lint ir� verificar se alguns dados est�o hardcoded no projeto, para isso � necess�rio configurar o User Secrets no projeto.
```
 "AllowedHosts": "*",
  "AppConfig": {
    "ConnectionString": "server=localhost;port=3307;user=OA;password=123456!Oa;database=oa_local"
  }
```

A string acima � a padr�o para a conex�o com o docker.