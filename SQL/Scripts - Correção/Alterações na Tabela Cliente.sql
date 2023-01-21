exec sp_rename 'cliente', 'Cliente' -- Alteracao no nome da table 

exec sp_rename 'cliente.cliente_id', 'CodigoCliente', 'Column'; -- alteracao na coluna 

exec sp_rename 'cliente.primeiro_nome', 'PrimeiroNome', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.sobre_nome', 'Sobrenome', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.telefone', 'Telefone', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.email', 'Email', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.endereco_id', 'CodigoEndereco', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.tipo_pessoa_id', 'CodigoTipoPessoa', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.sigla_tipo_pessoa', 'SiglaTipoPessoa', 'Column';-- alteracao na coluna 

exec sp_rename 'cliente.ativo', 'Ativo', 'Column';-- alteracao na coluna 


alter table Cliente -- ativo passou a aceitar nulo
alter column ativo bit null

alter table Cliente -- nova coluna de documento para identificar cliente 
add Documento varchar(20) unique not null

go

alter table Senior -- alteracao no tamanho da coluna 
alter column PrimeiroNome varchar(255) not null

go

alter table Senior -- alteracao no tamanho da coluna 
alter column Sobrenome varchar(255) not null

go

alter table Cliente -- alteracao na tabela cliente adicionando uma coluna 
add DataInclusao datetime default getdate () null