# SMAE - Sistema de Monitoramento de Áreas de Risco

![Status](https://img.shields.io/badge/status-concluído-brightgreen)

## Tabela de Conteúdos

1. [Descrição do Projeto](#1-descrição-do-projeto)
2. [Funcionalidades](#2-funcionalidades)
3. [Arquitetura da Solução](#3-arquitetura-da-solução)
4. [Tecnologias e Componentes](#4-tecnologias-e-componentes)
5. [Guia de Execução](#5-guia-de-execução)
6. [Demonstração (Evidências)](#6-demonstração-evidências)
7. [Autores](#7-autores)
8. [Licença](#8-licença)

---

## 1. Descrição do Projeto

O **SMAE** é um sistema voltado para o **monitoramento de áreas de risco ambiental**, com foco na prevenção de desastres naturais. A solução permite o cadastro de sensores em locais vulneráveis, leitura de dados em tempo real, disparo de alertas automatizados e envio de notificações a usuários inscritos.

Este projeto foi desenvolvido como parte da disciplina **Advanced Business Development with .NET**, com o objetivo de entregar uma aplicação robusta utilizando tecnologias modernas do ecossistema Microsoft.

---

## 2. Funcionalidades

* ✅ **Gestão de Usuários:** cadastro, edição e exclusão.
* ✅ **Cadastro de Sensores:** dispositivos que captam dados ambientais.
* ✅ **Áreas de Risco:** definição de regiões críticas e monitoradas.
* ✅ **Alertas Automatizados:** disparados com base em leituras fora dos parâmetros.
* ✅ **Inscrição em Alertas:** usuários escolhem que tipos de notificações receber.
* ✅ **Notificações em Tempo Real:** geração e registro de mensagens de alerta.
* ✅ **Leituras Ambientais:** registro contínuo dos sensores (ex: temperatura, umidade).

---

## 3. Arquitetura da Solução

```text
Usuário ↔ API ASP.NET Core ↔ Banco de Dados SQL Server
                          ↓
                     Sistema de Alertas
                          ↓
                  Notificações por Evento
```

* A aplicação segue a arquitetura em **camadas** (Presentation, Application, Domain, Infrastructure).
* Utiliza **EF Core** para persistência de dados.
* **Swagger** para visualização e teste da API.

---

## 4. Tecnologias e Componentes

### Backend

* [.NET 8 / ASP.NET Core](https://dotnet.microsoft.com/)
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI

### Infraestrutura

* Docker (opcional)
* Visual Studio 2022

### Organização do Projeto

```
├── Application/       → Serviços e lógica de aplicação
├── Domain/            → Entidades e regras de domínio
├── Infrastructure/    → Repositórios e banco de dados
├── Presentation/      → API Controllers (.NET)
├── Views/             → Interface web (MVC)
├── wwwroot/           → Arquivos estáticos (CSS, JS, imagens)
├── Program.cs         → Configuração de inicialização
└── appsettings.json   → Configurações de ambiente
```

---

## 5. Guia de Execução

### 5.1 Clonando o Repositório

```bash
git clone https://github.com/Pablo0703/DotNet_global_solution.git
```

### 5.2 Executando Localmente

1. Abra o projeto no **Visual Studio 2022**
2. Atualize a `ConnectionString` no arquivo `appsettings.json`
3. Execute as migrações do banco:

```bash
dotnet ef database update
```

4. Inicie a aplicação:

```bash
dotnet run
```

5. Acesse via navegador:

```
http://localhost:7203/swagger
```

### 5.3 Executando com Docker (Opcional)

```bash
docker build -t global-solution .
docker run -d -p 5000:80 global-solution
```

---

## 6. Demonstração (Evidências)

### 6.1 Endpoints da API (Swagger)

| Controller                | Imagem                                         |
| ------------------------- | ---------------------------------------------- |
| ControllerUsuario         | ![image](https://github.com/user-attachments/assets/6a7f9237-c95e-4262-bcf3-75a3903fad90)
      |
| ControllerSensor          | ![](./imagens/controller-sensor.png)           |
| ControllerNotificacao     | ![](./imagens/controller-notificacao.png)      |
| ControllerLeituraSensor   | ![](./imagens/controller-leitura-sensor.png)   |
| ControllerInscricaoAlerta | ![](./imagens/controller-inscricao-alerta.png) |
| ControllerAreaRisco       | ![](./imagens/controller-area-risco.png)       |
| ControllerAlerta          | ![](./imagens/controller-alerta.png)           |

---

## 7. Autores

| RM     | Nome                            |
| ------ | ------------------------------- |
| 556834 | Pablo Lopes Doria de Andrade    |
| 557047 | Vinicius Leopoldino de Oliveira |
| 558711 | Diego Santos Cardoso            |

---

## 8. Licença

Distribuído sob a licença [MIT](LICENSE).
