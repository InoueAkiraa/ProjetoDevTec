CREATE TABLE EnderecoPessoa(
	CodigoEnderecoPessoa INT NOT NULL,
	CodigoEndereco INT NOT NULL,
	CodigoPessoa INT NOT NULL,
	CONSTRAINT PK_EnderecoPessoa PRIMARY KEY(CodigoEnderecoPessoa),
	CONSTRAINT FK_Endereco_Pessoa_Endereco FOREIGN KEY(CodigoEndereco) REFERENCES Endereco(CodigoEndereco),
	CONSTRAINT FK_Endereco_Pessoa_Pessoa FOREIGN KEY(CodigoPessoa) REFERENCES Pessoa(CodigoPessoa)
)
GO