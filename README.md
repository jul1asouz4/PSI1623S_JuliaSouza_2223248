# 📚 Litly

**Uma plataforma social para leitores que combina funcionalidades de rede social com espaço para criatividade literária.**

---

## 📖 Sobre o Projeto

O Litly é uma aplicação desktop desenvolvida em **C# com Windows Forms** e **SQL Server**, projetada para ser um espaço interativo onde leitores podem organizar, partilhar e discutir as suas leituras. Os utilizadores podem publicar os livros que estão a ler, avaliar obras, comentar publicações e até escrever os seus próprios textos. O objetivo principal é incentivar o hábito da leitura e escrita através de uma aplicação moderna, intuitiva e funcional, desenvolvida com base nos princípios da programação orientada a objetos (POO) e utilizando SQL Server para gestão da base de dados.

---

## 🚀 Funcionalidades Principais

O Litly oferece um conjunto abrangente de funcionalidades para melhorar a experiência do utilizador:

* **Gestão de Utilizadores:**
    * Cadastro e login de utilizadores com verificação de email.
    * Gestão de perfil de utilizador, incluindo nome, email, biografia e foto de perfil personalizável.
* **Sistema de Amizades:**
    * Pesquisa de outros utilizadores para adicionar como amigos.
    * Envio e gestão de pedidos de amizade (aceitar, recusar).
    * Remoção de amigos da lista.
* **Mensagens Diretas (Chat):**
    * Chat interno para comunicação em tempo real entre amigos.
    * Visualização e envio de mensagens em conversas individuais.
    * Pesquisa de conversas existentes por nome de amigo.
* **Biblioteca Pessoal:**
    * Registo e gestão de livros pessoais na sua biblioteca digital.
    * Adicionar novos livros com título, autor, URL da capa, sinopse e data de publicação.
    * Visualização detalhada dos livros adicionados.
* **Publicações Literárias:**
    * Criação e visualização de postagens literárias com título, conteúdo, autor e data de criação.
    * Possibilidade de adicionar imagens às postagens.
    * Feed de publicações para descobrir novos conteúdos.
    * Sistema de gostos e comentários em publicações.
* **Pesquisa Abrangente:**
    * Funcionalidade de pesquisa para encontrar livros, utilizadores e postagens.
    * Resultados de pesquisa detalhados para facilitar a navegação.

---

## 🧰 Tecnologias Utilizadas

* **Linguagem de Programação:** C#
* **Interface Gráfica:** Windows Forms
* **Base de Dados:** SQL Server
* **Acesso a Dados:** ADO.NET (com `Microsoft.Data.SqlClient`)
* **Paradigma:** Programação Orientada a Objetos (POO)
* **Arquitetura:** CRUD (Create, Read, Update, Delete) e Eventos com formulários dinâmicos.

---

## 🗂 Estrutura do Projeto

A estrutura do projeto está organizada para facilitar o desenvolvimento e a manutenção:


```bash
Litly/
│
├──  Forms/ (Representam as interfaces de utilizador)
│   ├── Login.cs
│   │   ├── Resgistro.cs
│   │   ├── PaginaPrincipal.cs
│   │   ├── Biblioteca.cs
│   │   ├── AdicionarLivros.cs
│   │   ├── DetalhesLivros.cs
│   │   ├── DM.cs (FormChat)
│   │   ├── frmAmigos.cs
│   │   ├── PaginaPostagem.cs
│   │   └── PerfilUtilizador.cs
│
├── Models/  (Classes que representam entidades do domínio, e.g., Utilizador, ItemAmigo)
│   │   ├── Utilizador.cs
│   │   ├── ItemAmigo.cs
│   │   └── Sessao.cs (Gestão de sessão do utilizador logado)
│
├── Properties/ (Recursos, configurações de projeto)
│   │   ├── Resources.Designer.cs
│   │   ├── serviceDependencies.json
│   │   └── serviceDependencies.local.json
│
├── Program.cs (Ponto de entrada da aplicação)
│   └── (Outros ficheiros do projeto C# como .csproj, .sln, etc.)
|
├── Docs/
│   └── PSI1623S_ JuliaSouza_2223248_PropostaPreProjeto.pdf (Proposta de pré-projeto com detalhes e protótipos)
|
├── scriptbd/
│   └── SQLQuery1.sql (Scripts SQL para gestão e alterações da base de dados)
│
└── .gitignore (Ficheiro para ignorar itens no controlo de versão)

---

## 📊 Estrutura da Base de Dados

A base de dados `Litly` utiliza SQL Server e inclui as seguintes tabelas principais para suportar as funcionalidades da aplicação:

* **`Utilizadores`**: Armazena informações dos utilizadores (ID, Nome, Email, PalavraPasse, DataCriacao, ImagemPerfil).
* **`Livros`**: Contém detalhes sobre os livros adicionados pelos utilizadores (ID, Titulo, Autor, Genero, AnoPublicacao, CapaURL, Sinopse, IdUtilizador - FK para `Utilizadores`).
* **`Postagens`**: Relaciona o utilizador ao conteúdo literário publicado (Id, Titulo, Autor, Conteudo, DataCriacao, IdUtilizador - FK para `Utilizadores`, Imagem).
* **`Amizades`**: Regista as relações de amizade entre utilizadores (IdSolicitante, IdAceito, Status - 'Pendente' ou 'Aceite').
* **`Mensagens`**: Armazena as mensagens trocadas entre utilizadores (IdRemetente, IdDestinatario, Texto, DataEnvio).
* **`Comentários`**: Destina-se a armazenar comentários feitos nas publicações (ID, IdPublicacao - FK, IdUtilizador - FK, Texto, DataComentario).
* **`Gostos`**: Destina-se a registar as publicações curtidas pelos utilizadores.

---

## 🎨 Interface Gráfica (Protótipos)

Para uma visualização da interface e navegação da aplicação, consulte o documento de proposta de pré-projeto disponível em `Docs/PSI1623S_ JuliaSouza_2223248_PropostaPreProjeto.pdf`. Este documento inclui protótipos para as seguintes telas:

* **Página de Login**
* **Página de Registo (Inscrição)**
* **Página Principal (Home)**
* **Página de Mensagens (Chat)**

---

## 🛠 Como Executar o Projeto

1.  **Pré-requisitos:**
    * Visual Studio (com workload de desenvolvimento .NET desktop)
    * SQL Server LocalDB (ou uma instância de SQL Server configurada)
2.  **Configuração da Base de Dados:**
    * Crie uma base de dados chamada `Litly` no seu SQL Server (LocalDB).
    * Execute os scripts SQL disponíveis na pasta `scriptbd/` para criar as tabelas e aplicar quaisquer alterações necessárias.
3.  **Abrir no Visual Studio:**
    * Abra o ficheiro da solução `Litly.sln` (localizado na raiz do projeto) no Visual Studio.
4.  **Configurar Connection String:**
    * Verifique e ajuste a connection string nos ficheiros C# (`Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;`) para corresponder à sua configuração de SQL Server, se necessário.
5.  **Compilar e Executar:**
    * Compile o projeto (Build Solution).
    * Execute a aplicação a partir do Visual Studio.

## ✨ Contribuições

Contribuições são bem-vindas! Se tiver sugestões ou quiser melhorar o projeto, sinta-se à vontade para abrir uma *issue* ou enviar um *pull request*.

---

## ⚖️ Licença

Este projeto está licenciado sob a licença [inserir tipo de licença, e.g., MIT License]. (Se aplicável)

---

## 🔗 Referências

* [Microsoft Docs](https://learn.microsoft.com)
* [C# Windows Forms GUI Tutorial - GeeksforGeeks](https://www.geeksforgeeks.org/c-sharp-windows-forms-gui-tutorial/)
* [SQL Server Basics - W3Schools](https://www.w3schools.com/sql/)
* Artigo: "Como criar uma rede social com C#" - Medium
