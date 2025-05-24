# Projeto de Testes para RealizarLoginUseCase

## Como rodar os testes localmente

### Pré-requisitos
- .NET SDK instalado (versão 6.0 ou superior)
- Visual Studio ou VS Code (opcional)

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/testes-pim-csharp.git
cd testes-pim-csharp
```

2. Instale os pacotes necessários:
```bash
dotnet add package xunit
dotnet add package Moq
```

3. Rode os testes:
```bash
dotnet test
```

---
## Estrutura do projeto

- `RealizarLoginUseCaseTests.cs` - Classe com os testes automatizados para o caso de uso de login.
- `LoginDTO.cs` - DTO usado para passar usuário e senha.
- `Usuario.cs` - Classe básica do usuário, com método de verificação de senha.
- `IUsuarioRepositorio.cs` - Interface do repositório de usuários, usada para mock.
- `RespostaPadrao.cs` - Classe genérica para padronizar respostas.