-- SCRIPT DE ADICIONAR CONSTRAINT EM JUNIOR
ALTER TABLE Junior
ADD CONSTRAINT FK_Junior_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Junior
ADD CONSTRAINT FK_Junior_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO

ALTER TABLE Junior
ADD CONSTRAINT FK_Junior_Projeto FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO

-- SCRIPT DE ADICIONAR CONSTRAINT EM PLENO
ALTER TABLE Pleno
ADD CONSTRAINT FK_Pleno_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Pleno
ADD CONSTRAINT FK_Pleno_Projeto FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO

ALTER TABLE Pleno
ADD CONSTRAINT FK_Pleno_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO

-- SCRIPT DE ADICIONAR CONSTRAINT EM ESTAGIARIO
ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_Endereco FOREIGN KEY (CodigoEndereco) REFERENCES Endereco (CodigoEndereco)
GO

ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_Projeto FOREIGN KEY (CodigoProjeto) References Projeto (CodigoProjeto)
GO

ALTER TABLE Estagiario
ADD CONSTRAINT FK_Estagiario_TipoPessoa FOREIGN KEY (CodigoTipoPessoa) REFERENCES TipoPessoa (CodigoTipoPessoa)
GO