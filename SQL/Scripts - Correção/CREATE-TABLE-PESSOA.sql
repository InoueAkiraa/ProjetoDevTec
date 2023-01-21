CREATE TABLE Pessoa(
	CodigoPessoa INT NOT NULL IDENTITY(1,1),
	Nome VARCHAR(255) NOT NULL,
	Sobrenome VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Telefone VARCHAR(25) NOT NULL,
	Matricula INT NULL,
	Documento VARCHAR(20) NOT NULL,
	CodigoTipoPessoa INT NOT NULL,
	SiglaTipoPessoa CHAR(2) NOT NULL,
	Ativo BIT DEFAULT(1)NULL,
	DataInclusao DATETIME DEFAULT GETDATE() NULL,
	DataContratacao DATETIME NULL,
	CONSTRAINT PK_Pessoa PRIMARY KEY(CodigoPessoa),
	CONSTRAINT FK_Pessoa_Tipo_Pessoa FOREIGN KEY(CodigoTipoPessoa) REFERENCES TipoPessoa(CodigoTipoPessoa)
)
GO
