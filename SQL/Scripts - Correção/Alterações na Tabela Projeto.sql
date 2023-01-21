exec sp_rename 'projeto', 'Projeto' -- Alteracao no nome da table 

exec sp_rename 'Projeto.projeto_empresa', 'CodigoProjeto', 'Column';  -- alteracao na coluna 

exec sp_rename 'Projeto.projeto_nome', 'Nome', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.empresa_id', 'CodigoEmpresa', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.tipo_projeto_id', 'CodigoTipoProjeto', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.descricao', 'Descricao', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.preco_listado', 'PrecoListado', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.ativo', 'Ativo', 'Column'; -- alteracao na coluna 

exec sp_rename 'Projeto.projeto_id', 'CodigoProjeto', 'Column'; -- alteracao na coluna 


alter table Projeto  -- ativo passou a aceitar nulo
alter column ativo bit null

go

alter table Projeto --alteracao na tabela projeto adicionando uma nova coluna 
add SiglaStatusProjeto char(2) not null

go

alter table Projeto -- alteracao na tabela projeto adicionando uma coluna 
add DataInclusao datetime default getdate() null
go

alter table Projeto -- alteracao na tabela projeto adicionando uma nova coluna 
add DataInicio datetime  null
go

alter table Projeto -- alteracao na tabela projeto adicionando uma nova coluna 
add DataFinalzada datetime null
go

alter table Projeto -- alteracao na tabela projeto adicionando uma nova coluna 
add DataEntregaPrevista datetime not null

alter Table Projeto -- alteracao na tabela projeto adicionando uma nova coluna 
add CodigoStatusProjeto int not null

alter table Projeto -- alteracao na tabela projeto adicionando uma nova constraint  
add constraint FK_Projeto_StatusProjeto foreign key (CodigoStatusProjeto) references StatusProjeto (CodigoStatusProjeto)
go