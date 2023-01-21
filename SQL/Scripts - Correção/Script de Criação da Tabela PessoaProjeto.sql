Create Table PessoaProjeto(
CodigoPessoaProjeto int identity(1,1) not null,
CodigoPessoa int not null,
CodigoProjeto int not null,
Constraint PK_PessoaProjeto Primary Key(CodigoPessoaProjeto),
Constraint FK_PessoaProjeto_Pessoa Foreign Key(CodigoPessoa) References Pessoa(CodigoPessoa),
Constraint FK_PessoaProjeto_Projeto Foreign Key(CodigoProjeto) References Projeto(CodigoProjeto)
)