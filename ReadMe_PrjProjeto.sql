--Criando o banco de dados SQL-Server:
CREATE DATABASE PrjProcessoDB;
GO

--Usando o banco:
USE PrjProcessoDB;
GO

--Criando a tabela Processo:
CREATE TABLE Processo (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- Chave primária do tipo GUID
    NomeProcesso NVARCHAR(300) NOT NULL,      -- Nome do processo, máximo 300 caracteres
    NPU NVARCHAR(25) NOT NULL,                -- Número único do processo (com máscara)
    DataCadastro DATETIME NOT NULL,           -- Data de cadastro, Não permite NULL pois será preenchido Automaticamente durante o cadastro e não será mais modificado 
    DataVisualizacao DATETIME NULL,           -- Data de visualização, Permite NULL pois durante o cadastro este campo ficará NULL
    UF CHAR(2) NOT NULL,                      -- Unidade Federativa, 2 caracteres
    Municipio NVARCHAR(300) NOT NULL          -- Município, máximo 300 caracteres
);
GO
