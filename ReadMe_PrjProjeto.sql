--Criando o banco de dados SQL-Server:
CREATE DATABASE PrjProcessoDB;
GO

--Usando o banco:
USE PrjProcessoDB;
GO

--Criando a tabela Processo:
CREATE TABLE Processo (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- Chave prim�ria do tipo GUID
    NomeProcesso NVARCHAR(300) NOT NULL,      -- Nome do processo, m�ximo 300 caracteres
    NPU NVARCHAR(25) NOT NULL,                -- N�mero �nico do processo (com m�scara)
    DataCadastro DATETIME NOT NULL,           -- Data de cadastro, N�o permite NULL pois ser� preenchido Automaticamente durante o cadastro e n�o ser� mais modificado 
    DataVisualizacao DATETIME NULL,           -- Data de visualiza��o, Permite NULL pois durante o cadastro este campo ficar� NULL
    UF CHAR(2) NOT NULL,                      -- Unidade Federativa, 2 caracteres
    Municipio NVARCHAR(300) NOT NULL          -- Munic�pio, m�ximo 300 caracteres
);
GO
