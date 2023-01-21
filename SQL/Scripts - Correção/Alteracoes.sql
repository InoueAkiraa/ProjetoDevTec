EXEC sp_rename 'estado','Estado'
GO
EXEC sp_rename 'Estado.estado_id','CodigoEstado','COLUMN'
GO
EXEC sp_rename 'Estado.nome','Nome','COLUMN'
GO
EXEC sp_rename 'Estado.uf','UF','COLUMN'
GO

ALTER TABLE Estado
ALTER COLUMN UF CHAR(2) NOT NULL;
GO


EXEC sp_rename 'cidade','Cidade'
GO
EXEC sp_rename 'Cidade.cidade_id','CodigoCidade','COLUMN'
GO
EXEC sp_rename 'Cidade.nome','Nome','COLUMN'
GO
EXEC sp_rename 'Cidade.codigo_ibge7','CodigoIBGE7','COLUMN'
GO
EXEC sp_rename 'Cidade.estado_id','CodigoEstado','COLUMN'
GO

ALTER TABLE Cidade
DROP CONSTRAINT [FK_cidade_estado];
GO
ALTER TABLE Cidade
ADD CONSTRAINT FK_Cidade_Estado FOREIGN KEY(CodigoEstado) REFERENCES Estado(CodigoEstado)
GO


EXEC sp_rename 'endereco','Endereco'
GO
EXEC sp_rename 'Endereco.endereco_id','CodigoEndereco','COLUMN'
GO
EXEC sp_rename 'Endereco.rua','Rua','COLUMN'
GO
EXEC sp_rename 'Endereco.numero','Numero','COLUMN'
GO
EXEC sp_rename 'Endereco.complemento','Complemento','COLUMN'
GO
EXEC sp_rename 'Endereco.bairro','Bairro','COLUMN'
GO
EXEC sp_rename 'Endereco.cep','CEP','COLUMN'
GO

ALTER TABLE Endereco
DROP CONSTRAINT [FK_endereco_cidade_estado];
GO

ALTER TABLE Cidade
ADD CONSTRAINT FK_Endereco_Cidade FOREIGN KEY(CodigoCidade) REFERENCES Cidade(CodigoCidade)
GO