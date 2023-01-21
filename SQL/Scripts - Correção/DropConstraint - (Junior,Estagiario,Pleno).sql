--SCRIPT RESPONSÁVEL POR DROPAR AS CONSTRAINT DE JUNIOR
ALTER TABLE Junior
DROP CONSTRAINT FK_Junior_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Junior
DROP CONSTRAINT FK_Junior_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO

ALTER TABLE Junior
DROP CONSTRAINT FK_Junior_Junior FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO

--SCRIPT RESPONSÁVEL POR DROPAR AS CONSTRAINT DE PLENO
ALTER TABLE Pleno
DROP CONSTRAINT FK_Pleno_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Pleno
DROP CONSTRAINT FK_Pleno_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO

ALTER TABLE Pleno
DROP CONSTRAINT FK_Pleno_Pleno FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO


--SCRIPT RESPONSÁVEL POR DROPAR AS CONSTRAINT DE ESTAGIARIO
ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO

ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_Estagiario FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO
