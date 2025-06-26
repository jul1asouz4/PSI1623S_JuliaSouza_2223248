USE Litly

-- *************************************************************************
-- SCRIPT DE RECRIAÇÃO COMPLETA DA ESTRUTURA PARA ALINHAMENTO COM C#
-- *************************************************************************
-- Caso ja tenham uma tabela feita.
-- PASSO 1: REMOVER TODAS AS CHAVES ESTRANGEIRAS EXISTENTES
PRINT 'Gerando e removendo todas as chaves estrangeiras...';
DECLARE @sql_drop_all_fks NVARCHAR(MAX) = N'';

SELECT @sql_drop_all_fks += N'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(fk.parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(fk.parent_object_id)) +
                             ' DROP CONSTRAINT ' + QUOTENAME(fk.name) + ';' + CHAR(13) + CHAR(10)
FROM sys.foreign_keys AS fk;

EXEC sp_executesql @sql_drop_all_fks;
PRINT 'Todas as chaves estrangeiras foram removidas.';


-- PASSO 2: REMOVER TODAS AS TABELAS NA ORDEM INVERSA DE DEPENDÊNCIA OU USANDO DROP IF EXISTS
PRINT 'Removendo tabelas existentes (se houver)...';
IF OBJECT_ID('Gostos', 'U') IS NOT NULL DROP TABLE Gostos;
IF OBJECT_ID('Comentarios', 'U') IS NOT NULL DROP TABLE Comentarios;
IF OBJECT_ID('Amizades', 'U') IS NOT NULL DROP TABLE Amizades;
IF OBJECT_ID('Mensagens', 'U') IS NOT NULL DROP TABLE Mensagens;
IF OBJECT_ID('Postagens', 'U') IS NOT NULL DROP TABLE Postagens;
IF OBJECT_ID('Livros', 'U') IS NOT NULL DROP TABLE Livros;
IF OBJECT_ID('Utilizadores', 'U') IS NOT NULL DROP TABLE Utilizadores;
PRINT 'Tabelas existentes removidas.';

-- CRIAÇÃO CASO NÃO TENHA NADA FEITO

CREATE DATABASE Litly
-- PASSO 3: CRIAR TODAS AS TABELAS COM AS DEFINIÇÕES CORRETAS
PRINT 'Criando todas as tabelas...';

CREATE TABLE Utilizadores (
    IdUtilizador INT PRIMARY KEY IDENTITY(1,1), -- AGORA COM IDENTITY (AUTO-INCREMENTO)
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PalavraPasse VARCHAR(200) NOT NULL,
    Bio VARCHAR(350) NULL,
    DataCriacao DATETIME DEFAULT GETDATE(),
    ImagemPerfil VARBINARY(MAX) NULL
);
PRINT 'Tabela Utilizadores criada com sucesso.';

CREATE TABLE Livros (
    IdLivro INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NOT NULL,
    Autor NVARCHAR(100) NOT NULL,
    Sinopse NVARCHAR(MAX) NULL,
    Imagem VARBINARY(MAX) NULL,
    DataPublicacao DATETIME DEFAULT GETDATE(), -- Adicionado DataPublicacao
    IdUtilizador INT -- Será FK para Utilizadores
);
PRINT 'Tabela Livros criada com sucesso.';

CREATE TABLE Postagens (
    IdPostagem INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NOT NULL,
    Autor NVARCHAR(100) NOT NULL,
    Conteudo NVARCHAR(MAX) NULL,
    DataCriacao DATETIME DEFAULT GETDATE(),
    Imagem VARBINARY(MAX) NULL,
    IdUtilizador INT NOT NULL, -- FK para Utilizadores
    IdLivro INT NULL, -- FK para Livros (Opcional, para posts sobre livros)
    Nota INT NULL
);
PRINT 'Tabela Postagens criada com sucesso.';

CREATE TABLE Comentarios (
    IdComentario INT PRIMARY KEY IDENTITY(1,1),
    Conteudo NVARCHAR(MAX) NOT NULL,
    DataComentario DATETIME DEFAULT GETDATE(),
    IdUtilizador INT NOT NULL, -- FK para Utilizadores
    IdPostagem INT NOT NULL -- FK para Postagens
);
PRINT 'Tabela Comentarios criada com sucesso.';

CREATE TABLE Gostos (
    IdGosto INT PRIMARY KEY IDENTITY(1,1),
    DataGosto DATETIME DEFAULT GETDATE(),
    IdUtilizador INT NOT NULL, -- FK para Utilizadores
    IdPostagem INT NOT NULL -- FK para Postagens
);
PRINT 'Tabela Gostos criada com sucesso.';

CREATE TABLE Amizades (
    IdAmizade INT PRIMARY KEY IDENTITY(1,1),
    IdSolicitante INT NOT NULL, -- FK para Utilizadores
    IdAceito INT NOT NULL, -- FK para Utilizadores
    Status VARCHAR(50) NOT NULL, -- Ex: 'Pendente', 'Aceite', 'Recusado'
    DataAmizade DATETIME DEFAULT GETDATE()
);
PRINT 'Tabela Amizades criada com sucesso.';

CREATE TABLE Mensagens (
    IdMensagem INT PRIMARY KEY IDENTITY(1,1),
    Conteudo NVARCHAR(MAX) NOT NULL,
    DataEnvio DATETIME DEFAULT GETDATE(),
    IdRemetente INT NOT NULL, -- FK para Utilizadores
    IdDestinatario INT NOT NULL -- FK para Utilizadores
);
PRINT 'Tabela Mensagens criada com sucesso.';

-- PASSO 4: RECRIAR TODAS AS CHAVES ESTRANGEIRAS
PRINT 'Recriando chaves estrangeiras...';

ALTER TABLE Livros ADD CONSTRAINT FK_Livros_Utilizadores FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);

ALTER TABLE Postagens ADD CONSTRAINT FK_Postagens_Utilizador FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);
ALTER TABLE Postagens ADD CONSTRAINT FK_Postagens_Livro FOREIGN KEY (IdLivro) REFERENCES Livros(IdLivro);

ALTER TABLE Comentarios ADD CONSTRAINT FK_Comentarios_Utilizador FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);
ALTER TABLE Comentarios ADD CONSTRAINT FK_Comentarios_Postagem FOREIGN KEY (IdPostagem) REFERENCES Postagens(IdPostagem);

ALTER TABLE Gostos ADD CONSTRAINT FK_Gostos_Utilizador FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);
ALTER TABLE Gostos ADD CONSTRAINT FK_Gostos_Postagem FOREIGN KEY (IdPostagem) REFERENCES Postagens(IdPostagem);

ALTER TABLE Amizades ADD CONSTRAINT FK_Amizades_Solicitante_Utilizadores FOREIGN KEY (IdSolicitante) REFERENCES Utilizadores(IdUtilizador);
ALTER TABLE Amizades ADD CONSTRAINT FK_Amizades_Aceito_Utilizadores FOREIGN KEY (IdAceito) REFERENCES Utilizadores(IdUtilizador);

ALTER TABLE Mensagens ADD CONSTRAINT FK_Mensagens_Remetente FOREIGN KEY (IdRemetente) REFERENCES Utilizadores(IdUtilizador);
ALTER TABLE Mensagens ADD CONSTRAINT FK_Mensagens_Destinatario FOREIGN KEY (IdDestinatario) REFERENCES Utilizadores(IdUtilizador);

PRINT 'Chaves estrangeiras recriadas com sucesso.';
PRINT 'Configuração da base de dados concluída. Tente executar a aplicação novamente.';
