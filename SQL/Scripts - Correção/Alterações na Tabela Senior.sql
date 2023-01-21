
exec sp_rename 'senior', 'Senior' -- Alteracao no nome da table 

exec sp_rename 'Senior.Sigla_Tipo_Pessoa', 'SiglaTipoPessoa', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.email', 'Email', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.telefone', 'Telefone', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.matricula', 'Matricula', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.ativo', 'Ativo', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.endereco_id', 'CodigoEndereco', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.tipo_pessoa_id', 'CodigoTipoPessoa', 'Column'; -- alteracao na coluna 

exec sp_rename 'Senior.projeto_id', 'CodigoProjeto', 'Column'; -- alteracao na coluna 





alter table Senior
alter column ativo bit null --Alterei a coluna ativo para aceitar nulo

alter table Senior
alter column Datainclusao datetime null --Alterei a coluna datainclusao para aceitar nulo

go

alter table Senior -- alteracao na tabela senior adicionando uma nova constraint  
ADD constraint FK_Senior_Projeto foreign key (projeto_id) references projeto (projeto_id)





