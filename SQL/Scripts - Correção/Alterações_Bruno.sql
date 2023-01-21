EXEC sp_rename tipo_projeto, TipoProjeto

EXEC sp_rename 'TipoProjeto.tipo_projeto_id', 'CodigoTipoProjeto','COLUMN'

--Foram realizadas devido a adesão de nomenclaturas padronizadas(PascalCase) tanto para as tabelas quanto para as colunas.
_______________________________________________________________________

EXEC sp_rename tipo_pessoa, TipoPessoa

EXEC sp_rename 'TipoPessoa.tipo_pessoa_id', 'CodigoTipoPessoa','COLUMN'

EXEC sp_rename 'TipoPessoa.descricao', 'Descricao','COLUMN'

EXEC sp_rename 'TipoPessoa.sigla', 'Sigla','COLUMN'

EXEC sp_rename 'TipoPessoa.Sigla', 'SiglaTipoPessoa', 'COLUMN'

ALTER TABLE TipoPessoa
ALTER COLUMN SiglaTipoPessoa CHAR(2) NOT NULL

--Foram realizadas mudanças devido a adesão de nomenclaturas padronizadas(PascalCase) tanto para as tabelas quanto para as colunas. Tambem foi realizada a mudança da coluna
--SiglaTipoPessoa de 'VARCHAR(2) NOT NULL' para 'CHAR(2) NOT NULL'.
______________________________________________________________________

EXEC sp_rename empresa, Empresa

EXEC sp_rename 'Empresa.empresa_id', 'CodigoEmpresa','COLUMN'

--Foram realizadas mudanças devido a adesão de nomenclaturas padronizadas(PascalCase) tanto para as tabelas quanto para as colunas.
________________________________________________________________________________________________

CREATE TABLE StatusProjeto(
	CodigoStatusProjeto INT IDENTITY(1,1) NOT NULL,
	Descricao VARCHAR(25) NOT NULL,
	SiglaStatusProjeto CHAR(2) NOT NULL,
	CONSTRAINT PK_StatusProjeto PRIMARY KEY (CodigoStatusProjeto)
)

--Criação da tabela 'StatusProjeto' para servir de apoio para a tabela 'Projeto'.