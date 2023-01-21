INSERT INTO Estado(UF, Nome) VALUES
('RO', 'RONDÔNIA'),
('AC', 'ACRE'),
('AM', 'AMAZONAS'),
('RR', 'RORAIMA'),
('PA', 'PARÁ'),
('AP', 'AMAPÁ'),
('TO', 'TOCANTINS'),
('MA', 'MARANHÃO'),
('PI', 'PIAUÍ'),
('CE', 'CEARÁ'),
('RN', 'RIO GRANDE DO NORTE'),
('PB', 'PARAÍBA'),
('PE', 'PERNAMBUCO'),
('AL', 'ALAGOAS'),
('SE', 'SERGIPE'),
('BA', 'BAHIA'),
('MG', 'MINAS GERAIS'),
('ES', 'ESPIRITO SANTO'),
('RJ', 'RIO DE JANEIRO'),
('SP', 'SÃO PAULO'),
('PR', 'PARANÁ'),
('SC', 'SANTA CATARINA'),
('RS', 'RIO GRANDE DO SUL'),
('MS', 'MATO GROSSO DO SUL'),
('MT', 'MATO GROSSO'),
('GO', 'GOIÁS'),
('DF', 'DESTRITO FEDERAL')
GO

---------------------------------------------

INSERT INTO Cidade(Nome, CodigoIBGE7, CodigoEstado)
SELECT 
       [nome]
      ,[codigo_ibge7]
      ,[id_estado]
FROM [ViajeFacilDB].[dbo].[cidade]
GO

----------------------------------------------

INSERT INTO Endereco(Rua, Numero, Bairro, CEP, CodigoCidade)
SELECT [RUA]
      ,[numero]
      ,[bairro]
      ,[CEP]
      ,[CodigoCidade]
  FROM [DevTecDB].[dbo].[RAW_Endereco]
GO