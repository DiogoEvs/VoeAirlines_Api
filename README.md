# Projeto ASP.NET Core Web API para gerenciamento da VoeAirlines By Embraery

## Como executar o projeto

**Clonar o repositório**
```
git clone https://github.com/romulosilvestre/gabarito-api-dev-csharp.git
```

**Restaurar os pacotes**

Navegar para a pasta do projeto clonado e executar o seguinte comando:

```
dotnet restore
```

**Executar a aplicação**

Executar o seguinte comando ou utilizar a ferramenta de Debug do Visual Studio u Visual Studio Code (normalmente pressionando F5):
```
dotnet run
```

## Como testar a API

**Acessar a interface de teste do Swagger***
A UI do Swagger estará disponível na URL https://localhost:[porta]/swagger (a porta pode variar e deve ser observada no terminal ao executar o projeto).

**Consumir os endpoints**
Sugestão de ordem para testar a aplicação:

1) Criar, editar e excluir Aeronaves
2) Criar, editar e excluir Manutenção
3) Criar, editar e excluir Piloto
4) Criar, editar e excluir Voo
