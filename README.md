# 📚 Litly

Litly é uma aplicação de biblioteca digital desenvolvida em **C# com Windows Forms** e **SQL Server**, voltada para leitores que desejam organizar, compartilhar e discutir suas leituras. O projeto inclui funcionalidades sociais como **sistema de usuários, amizades, mensagens** e **postagens literárias**.

---

## 🚀 Funcionalidades Principais

- 👤 Cadastro e login de utilizadores  
- 📚 Registo e gestão de livros pessoais  
- 🔍 Pesquisa de livros, usuários e postagens  
- 🧑‍🤝‍🧑 Sistema de amizades entre usuários  
- 💬 Chat interno para mensagens entre amigos  
- 📝 Criação e visualização de postagens literárias  
- 🎨 Interface inspirada em tons *LemonChiffon* para uma experiência visual suave  

---

## 🧰 Tecnologias Utilizadas

- **Linguagem:** C#  
- **Interface gráfica:** Windows Forms  
- **Base de dados:** SQL Server (Microsoft.Data.SqlClient)  
- **Paradigma:** Programação Orientada a Objetos (POO)  
- **Arquitetura:** CRUD + Eventos com formulários dinâmicos

---

## 🗂 Estrutura do Projeto

```bash
Litly/
│
├── Forms/
│   ├── Login.cs
│   ├── Biblioteca.cs
│   ├── PerfilUtilizador.cs
│   ├── Chat.cs
│   └── Postagens.cs
│
├── Models/
│   ├── Utilizador.cs
│   ├── Livro.cs
│   ├── Mensagem.cs
│   └── Postagem.cs
│
├── Database/
│   ├── Conexao.cs
│   └── Queries.sql
│
├── Resources/
│   └── Imagens, Ícones, etc.
│
└── README.md
