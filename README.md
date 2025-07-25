# SMAE - Sistema de Monitoramento de Áreas de Risco

![Status](https://img.shields.io/badge/status-concluído-brightgreen)

## Tabela de Conteúdos

1. [Descrição do Projeto](#1-descrição-do-projeto)
2. [Funcionalidades](#2-funcionalidades)
3. [Arquitetura da Solução](#3-arquitetura-da-solução)
4. [Tecnologias e Componentes](#4-tecnologias-e-componentes)
5. [Guia de Execução](#5-guia-de-execução)
6. [Demonstração (Evidências)](#6-demonstração-evidências)
7. [Ordem de Teste via JSON](#7-ordem-de-teste-via-json)
8. [Autores](#8-autores)
9. [Licença](#9-licença)

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
| ControllerUsuario         | ![image](https://github.com/user-attachments/assets/88befdf5-5bc8-43d9-bb5d-8be1581281d0)|
| ------------------------- | ---------------------------------------------- |
| ControllerSensor          | ![image](https://github.com/user-attachments/assets/1c5dca52-2a3a-4363-8296-9fccb862e40b)|
| ------------------------- | ---------------------------------------------- |
| ControllerNotificacao     | ![image](https://github.com/user-attachments/assets/5966bc79-d2fd-4466-84f9-b23e801ed77b)|
| ------------------------- | ---------------------------------------------- |
| ControllerLeituraSensor   | ![image](https://github.com/user-attachments/assets/a524a410-7385-46a3-97d5-3c50503abdf5)|
| ------------------------- | ---------------------------------------------- |
| ControllerInscricaoAlerta | ![image](https://github.com/user-attachments/assets/0cc9dee6-5237-4ab9-924a-718b312b9be7)|
| ------------------------- | ---------------------------------------------- |
| ControllerAreaRisco       | ![image](https://github.com/user-attachments/assets/8bfb6afe-c515-457f-89f5-97d040b8641f)|
| ------------------------- | ---------------------------------------------- |
| ControllerAlerta          | ![image](https://github.com/user-attachments/assets/9846ab31-ef4e-4116-af50-dd4b01e425af)|

---

## 7. Ordem de Teste via JSON
Para testar corretamente a aplicação via Swagger ou via API, siga a seguinte ordem de cadastro dos dados com base no JSON abaixo:

Endpoints (via MVC)

https://localhost:7203/Usuario

https://localhost:7203/AreaRisco

https://localhost:7203/Sensor

https://localhost:7203/LeituraSensor

https://localhost:7203/Alerta

https://localhost:7203/InscricaoAlerta

https://localhost:7203/Notificacao

Para testar corretamente a aplicação via Swagger ou via API, siga a seguinte ordem de cadastro dos dados com base no JSON abaixo:

```json
{
  "usuario": {
    "NOME_USUARIO": "Joana Mendes",
    "EMAIL": "joana@email.com",
    "SENHA_HASH": "senhaSegura123",
    "TELEFONE": "11988887777",
    "TIPO_USUARIO": "CIDADAO"
  },
  "sensor": {
    "ID_SENSOR": "SENSOR001",
    "ID_AREA": 1,
    "TIPO_SENSOR": "NIVEL_AGUA",
    "MODELO": "Modelo-X",
    "ULTIMA_MANUTENCAO": "2025-06-01",
    "STATUS_SENSOR": "ATIVO"
  },
  "notificacao": {
    "ID_ALERTA": 100,
    "ID_USUARIO": 1,
    "CANAL_ENVIO": "EMAIL"
  },
  "leituraSensor": {
    "ID_SENSOR": "SENSOR001",
    "VALOR_LEITURA": 2.8,
    "UNIDADE_MEDIDA": "m"
  },
  "inscricaoAlerta": {
    "ID_USUARIO": 1,
    "ID_AREA": 1,
    "RECEBER_EMAIL": 1,
    "RECEBER_SMS": 0,
    "RECEBER_PUSH": 1
  },
  "areaRisco": {
    "NOME_AREA": "Bairro do Centro",
    "LATITUDE": -23.5505,
    "LONGITUDE": -46.6333,
    "NIVEL_NORMAL_ESTACAO_SECA": 1.2,
    "NIVEL_NORMAL_ESTACAO_CHUVA": 2.0,
    "NIVEL_ALERTA_PREVENTIVO": 2.5,
    "NIVEL_ALERTA_EMERGENCIA": 3.0,
    "NIVEL_EVACUACAO": 3.5,
    "AREA_ALAGADA_ALERTA": 1.5,
    "AREA_ALAGADA_EMERGENCIA": 2.5,
    "METODO_MEDICAO_NIVEL": "Sensor IoT",
    "METODO_MEDICAO_EXTENSAO": "LIDAR",
    "FONTE_DADOS": "Sistema Integrado",
    "RESPONSAVEL_ATUALIZACAO": "Equipe Técnica",
    "DESCRICAO": "Área próxima ao rio com alto risco em época de chuvas"
  },
  "alerta": {
    "ID_AREA": 1,
    "ID_LEITURA_GATILHO": 10,
    "TIPO_ALERTA": "EMERGENCIA",
    "MENSAGEM_ALERTA": "Nível crítico atingido, evacuação necessária."
  }
}
```

Para testar corretamente a aplicação via Swagger ou via API, siga a seguinte ordem de cadastro dos dados com base no arquivo `json_teste_dotnet.json`:

1. **Cadastrar Usuário**
   Endpoint: `POST /api/Usuario`

2. **Cadastrar Área de Risco**
   Endpoint: `POST /api/AreaRisco`

3. **Cadastrar Sensor**
   Endpoint: `POST /api/Sensor`

4. **Cadastrar Leitura do Sensor**
   Endpoint: `POST /api/LeituraSensor`

5. **Cadastrar Alerta**
   Endpoint: `POST /api/Alerta`

6. **Inscrição em Alerta**
   Endpoint: `POST /api/InscricaoAlerta`

7. **Cadastrar Notificação**
   Endpoint: `POST /api/Notificacao`

Essa ordem garante que todas as relações de chave estrangeira estejam corretamente criadas.

---

## 8. Autores

| RM     | Nome                            |
| ------ | ------------------------------- |
| 556834 | Pablo Lopes Doria de Andrade    |
| 557047 | Vinicius Leopoldino de Oliveira |
| 558711 | Diego Santos Cardoso            |

---

## 9. Licença

Distribuído sob a licença [MIT](LICENSE).
