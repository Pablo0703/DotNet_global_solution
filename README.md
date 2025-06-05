
# Global Solution - SMAE (.NET)

Este repositório contém o projeto **SMAE - Sistema de Monitoramento de Áreas de Risco**, desenvolvido como parte da disciplina *Advanced Business Development with .NET*. A aplicação visa monitorar áreas de risco ambiental, utilizando sensores e alertas automatizados.

## 📚 Descrição

O **SMAE** é um sistema completo para gestão de usuários, sensores e áreas de risco. Ele permite o cadastro e o monitoramento contínuo de dados sensoriais, com emissão de alertas e notificações automatizadas em casos de perigo detectado.

O sistema pode ser utilizado por órgãos públicos, empresas privadas ou ONGs com o objetivo de prevenir desastres e mitigar riscos em áreas vulneráveis.

## 🧩 Funcionalidades

- **Usuários**
  - Cadastro, edição e remoção de usuários do sistema
- **Sensores**
  - Cadastro de sensores responsáveis pela leitura ambiental
- **Áreas de Risco**
  - Registro de áreas críticas e suas informações geográficas
- **Alertas**
  - Definição de condições de risco e regras de disparo de alerta
- **Inscrição em Alertas**
  - Mecanismo para que usuários possam receber notificações específicas
- **Notificações**
  - Registro e envio de alertas automatizados para usuários
- **Leituras de Sensores**
  - Armazenamento e visualização de dados sensoriais em tempo real
 
  🔄 Sequência de Funcionamento do Sistema
Cadastro de Usuário

Inicie criando os usuários que irão interagir com o sistema, como operadores ou responsáveis por áreas monitoradas.

Cadastro da Área de Risco

Registre as áreas que serão monitoradas. Cada área pode conter sensores associados e será base para alertas futuros.

Cadastro de Sensor

Adicione sensores que serão posicionados nas áreas de risco. Esses sensores serão responsáveis por enviar leituras ambientais (temperatura, umidade, etc.).

Registro de Leitura do Sensor

As leituras dos sensores são registradas no sistema, indicando os valores detectados em tempo real ou por intervalo.

Criação de Alerta

Configure alertas com base em condições específicas (ex: temperatura acima de 40°C). Esses alertas serão ativados quando leituras excederem os limites definidos.

Inscrição em Alerta

Usuários podem se inscrever para receber alertas de áreas específicas ou tipos de risco. Isso garante que apenas interessados sejam notificados.

Geração de Notificação

Quando um alerta é ativado, o sistema gera automaticamente uma notificação para os usuários inscritos, alertando sobre o risco detectado.

## 🚀 Tecnologias Utilizadas

- .NET 8 / ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Docker (opcional)
- Visual Studio 2022

## 📦 Estrutura do Projeto

- **Application/** – Serviços de aplicação e regras de negócio
- **Domain/** – Entidades, interfaces e lógica de domínio
- **Infrastructure/** – Repositórios, contexto do banco e integrações
- **Presentation/** – API Controllers
- **Views/** – Interface web (MVC)
- **wwwroot/** – Arquivos estáticos (CSS, JS, imagens)
- **Program.cs** – Configuração de inicialização
- **appsettings.json** – Configurações da aplicação

## 🛠️ Como Rodar o Projeto

1. Clone este repositório:
   ```bash
   git clone [https://github.com/Pablo0703/global-solution.git](https://github.com/Pablo0703/DotNet_global_solution)
   ```

2. Abra o projeto com o Visual Studio 2022.

3. Atualize a connection string no arquivo `appsettings.json`.

4. Execute as migrações (caso necessário):
   ```bash
   dotnet ef database update
   ```

5. Rode a aplicação:
   ```bash
   dotnet run
   ```

6. Acesse a API no navegador:
   ```
   http://localhost:<7203>/swagger
   ```

## 🐳 Rodando com Docker

```bash
docker build -t global-solution .
docker run -d -p 5000:80 global-solution
```

## 👨‍💻 Autores

- Diego Santos Cardoso
- Pablo Lopes Doria de Andrade
- Vinicius Leopoldino de Oliveira
- FIAP - Global Solution 2025/1

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

