Use Litly

ALTER TABLE Livros
ADD IdUtilizador INT;


ALTER TABLE Livros
ADD CONSTRAINT FK_Livros_Utilizadores
FOREIGN KEY (IdUtilizador)
REFERENCES Utilizadores(IdUtilizador);


SELECT * FROM Utilizadores

SELECT * FROM Utilizadores WHERE IdUtilizador = 1;

SELECT * FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Utilizadores';

ALTER TABLE Livros 
DROP CONSTRAINT FK_Livros_Utilizadores;

EXEC sp_rename 'Livros.IdUtilizador', 'IdUtilizadores', 'COLUMN';

ALTER TABLE Livros DROP CONSTRAINT FK_Livros_Utilizadores;

EXEC sp_rename 'Livros.IdUtilizadores', 'IdUtilizador', 'COLUMN';

ALTER TABLE Livros
ADD CONSTRAINT FK_Livros_Utilizadores
FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);


SELECT DISTINCT IdUtilizador
FROM Livros
WHERE IdUtilizador IS NOT NULL
AND IdUtilizador NOT IN (SELECT IdUtilizador FROM Utilizadores);

DELETE FROM Livros
WHERE IdUtilizador NOT IN (SELECT IdUtilizador FROM Utilizadores);

ALTER TABLE Livros
ADD CONSTRAINT FK_Livros_Utilizadores
FOREIGN KEY (IdUtilizador) REFERENCES Utilizadores(IdUtilizador);


SELECT * FROM Livros


DELETE  FROM Livros


